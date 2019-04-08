using amweek.messaging.Messages;
using NATS.Client;

namespace amweek.messaging
{
    public static class MessageQueue
    {

        public static void Publish<TMessage>(TMessage message)
            where TMessage : Message
        {
            using (var connection = CreateConnection())
            {
                var data = MessageHelper.ToData(message);
                connection.Publish(message.Subject, data);
            }
        }

        public static IConnection CreateConnection()
        {
            return new ConnectionFactory().CreateConnection("10.0.75.1:4222");
        }
    }
}
