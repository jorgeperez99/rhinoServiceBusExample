using System;
using Messages;
using Rhino.ServiceBus;
using Rhino.ServiceBus.Hosting;

namespace Backend {
    public class HelloWorldConsumer : ConsumerOf<HelloWorldMessage> {
        private IServiceBus serviceBus;
        public HelloWorldConsumer(IServiceBus serviceBus) {
            this.serviceBus = serviceBus;
        }

        public void Consume(HelloWorldMessage message) {
            // Step 2: server receive message from client
            Console.WriteLine("BACKEND-" + message.Content);

            // Step 3: send back to client
            MessagingService.SendMessageToClients(serviceBus, message.Content);
        }
    }
}