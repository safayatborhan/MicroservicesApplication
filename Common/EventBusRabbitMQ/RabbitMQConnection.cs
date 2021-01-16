using RabbitMQ.Client;
using RabbitMQ.Client.Exceptions;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;

namespace EventBusRabbitMQ
{
    public class RabbitMqConnection : IRabbitMqConnection
    {
        private readonly IConnectionFactory _connectionFactory;

        private IConnection _connection;

        private bool _disposed;

        public RabbitMqConnection(IConnectionFactory connectionFactory)
        {
            _connectionFactory = connectionFactory ?? throw new ArgumentNullException(nameof(connectionFactory));

            if (!IsConnected)
            {
                TryConnect();
            }
        }

        public void Dispose()
        {
            if (_disposed)
            {
                return;
            }

            try
            {
                _connection.Dispose();
            }
            catch (Exception)
            {
                throw;
            }
        }

        public bool IsConnected
        {
            get
            {
                return _connection != null
                       && _connection.IsOpen
                       && !_disposed;
            }
        }
        public bool TryConnect()
        {
            try
            {
                _connection = _connectionFactory.CreateConnection();
            }
            catch (BrokerUnreachableException)
            {
                Thread.Sleep(2000); // If it gets this exception, it will wait 2 sec and try to connect again.
                _connection = _connectionFactory.CreateConnection();
            }

            if (IsConnected)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public IModel CreateModel()
        {
            if (!IsConnected)
            {
                throw new InvalidOperationException("No rabbit connection");
            }

            return _connection.CreateModel();
        }
    }
}
