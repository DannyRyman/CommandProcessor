using System.Threading.Tasks;

namespace CommandHandlerSpike.CommandInfrastructure
{
    public class CommandProcessor
    {
        private readonly ICommandRegistry _commandRegistry;
        private readonly ICommandHandlerFactory _commandHandlerFactory;

        public CommandProcessor(
            ICommandRegistry commandRegistry,
            ICommandHandlerFactory commandHandlerFactory)
        {
            _commandRegistry = commandRegistry;
            _commandHandlerFactory = commandHandlerFactory;
        }

        public async Task Execute<TCommand>(TCommand command) where TCommand : class, ICommand
        {
            var handlerType = _commandRegistry.GetHandlerForCommand<TCommand>();
            var handler = (ICommandHandler<TCommand>)_commandHandlerFactory.Get(handlerType);
            await handler.Execute(command);
        }
    }
}