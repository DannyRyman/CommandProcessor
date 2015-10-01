using System;
using Autofac;
using CommandHandlerSpike.CommandInfrastructure;

namespace CommandHandlerSpike.Autofac
{
    public class AutofacCommandHandlerFactory : ICommandHandlerFactory
    {
        private readonly IContainer _container;

        public AutofacCommandHandlerFactory(IContainer container)
        {
            _container = container;
        }
        public ICommandHandler Get(Type commandHandlerType)
        {
            return (ICommandHandler)_container.Resolve(commandHandlerType);
        }

    }
}
