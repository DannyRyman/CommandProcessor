using System.Threading.Tasks;
using CommandHandlerSpike.CommandInfrastructure;

namespace CommandHandlerSpike
{
    public class SayHelloQueryHandler : ICommandHandler<SayHelloQuery>
    {
        public async Task Execute(SayHelloQuery command)
        {
            command.Result = string.Format("Hello {0}", command.Name);
        }
    }
}