using System.Threading.Tasks;

namespace CommandHandlerSpike.CommandInfrastructure
{
    public interface ICommandHandler<in TCommand> : ICommandHandler where TCommand : ICommand
    {
        Task Execute(TCommand command);       
    }

    public interface ICommandHandler
    {
          
    }
}