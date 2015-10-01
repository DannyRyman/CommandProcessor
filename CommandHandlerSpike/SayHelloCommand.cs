using System;
using CommandHandlerSpike.CommandInfrastructure;

namespace CommandHandlerSpike
{
    public class SayHelloCommand : ICommand
    {
        public string Name { get; private set; }

        public SayHelloCommand(string name)
        {
            Name = name;
        }
    }
}