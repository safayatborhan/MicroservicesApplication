using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Text;
using System.Text.Json.Serialization;
using EventBusRabbitMQ.Events;
using RabbitMQ.Client;

namespace EventBusRabbitMQ.Producer
{
    public class EventBusRabbitMqProducer
    {
        private readonly IRabbitMqConnection _connection;

        public EventBusRabbitMqProducer(IRabbitMqConnection connection)
        {
            _connection = connection ?? throw new ArgumentNullException(nameof(connection));
        }

        public void PublishBasketCheckout(string queueName, BasketCheckoutEvent publishModel)
        {
            using (var channel = _connection.CreateModel())
            {
                channel.QueueDeclare(queue: queueName, durable: false, // durable means if it is stored in in-memory or disk
                    exclusive: false, autoDelete: false, arguments: null);

                var message = JsonConvert.SerializeObject(publishModel);

                var body = Encoding.UTF8.GetBytes(message);

                IBasicProperties properties = channel.CreateBasicProperties();

                properties.Persistent = true;

                properties.DeliveryMode = 2;

                channel.ConfirmSelect();

                channel.BasicPublish(exchange: "", routingKey: queueName, mandatory: true,
                    basicProperties: properties, body: body);

                channel.WaitForConfirmsOrDie();

                channel.BasicAcks += (sender, EventArgs) =>
                {
                    Console.WriteLine("Sent RabbitMQ");
                    // implement ack handle
                };

                channel.ConfirmSelect();
            }
        }
    }
}
