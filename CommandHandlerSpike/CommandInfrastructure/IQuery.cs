namespace CommandHandlerSpike.CommandInfrastructure
{
    public interface IQuery<out TResultType> : ICommand
    {
        TResultType Result { get; }
    }
}
