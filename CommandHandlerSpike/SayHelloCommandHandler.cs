using System;
using System.Threading.Tasks;
using CommandHandlerSpike.CommandInfrastructure;

namespace CommandHandlerSpike
{
    public class SayHelloCommandHandler : ICommandHandler<SayHelloCommand>
    {
        public async Task Execute(SayHelloCommand command)
        {
            Console.WriteLine("Hello {0}", command.Name);
        }
    }
}