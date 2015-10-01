using System;
using System.Collections.Generic;


namespace CommandHandlerSpike.CommandInfrastructure
{
    public class CommandRegistry : ICommandRegistry
    {
        // Command, CommandHandler
        private readonly Dictionary<Type, Type> _handlerRegistry;

        public CommandRegistry()
        {
            this._handlerRegistry = new Dictionary<Type, Type>();
        }

        public Type GetHandlerForCommand<TCommand>() where TCommand : class, ICommand
        {
            return _handlerRegistry[typeof (TCommand)];
        }

        public void Register<TCommand, TCommandHandler>() where TCommand : class where TCommandHandler : class, ICommandHandler
        {
            if (_handlerRegistry.ContainsKey(typeof(TCommand)))
            {
                throw new InvalidOperationException(string.Format("Already registered a command for handler of type {0}", typeof(TCommand).Name));
            }

            _handlerRegistry.Add(typeof(TCommand), typeof(TCommandHandler));
        }
    }
}
