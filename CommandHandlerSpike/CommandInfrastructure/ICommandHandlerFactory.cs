using System;

namespace CommandHandlerSpike.CommandInfrastructure
{
    public interface ICommandHandlerFactory
    {
        ICommandHandler Get(Type commandHandlerType);
    }
}