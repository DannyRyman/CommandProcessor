using System;

namespace CommandHandlerSpike.CommandInfrastructure
{
    public interface ICommandRegistry
    {
        Type GetHandlerForCommand<TCommand>() where TCommand : class, ICommand;

        void Register<TCommand, TCommandHandler>() where TCommand : class where TCommandHandler : class, ICommandHandler;
    }
}