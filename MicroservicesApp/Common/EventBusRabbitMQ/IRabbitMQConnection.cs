using RabbitMQ.Client;
using System;
using System.Collections.Generic;
using System.Text;

namespace EventBusRabbitMQ
{
    public interface IRabbitMqConnection : IDisposable  // Use IDisposable for disposing connection type classes
    {
        bool IsConnected { get; }

        bool TryConnect();

        /// <summary>
        /// Create a queue and perform queue operation by returning IModel
        /// </summary>
        /// <returns></returns>
        IModel CreateModel();
    }
}
