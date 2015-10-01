using System;
using System.Diagnostics;
using System.Linq.Expressions;
using System.Reflection;
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
            Stopwatch sw = new Stopwatch();
            sw.Start();
            var handlerType = _commandRegistry.GetHandlerForCommand<TCommand>();
            var handler = (ICommandHandler<TCommand>)_commandHandlerFactory.Get(handlerType);
            await handler.Execute(command);

            sw.Stop();
            Console.WriteLine(sw.ElapsedMilliseconds);
        }

        
        [DebuggerStepThrough]
        public async Task<TResult> ExecuteQuery<TResult>(IQuery<TResult> query)
        {
            Stopwatch sw = new Stopwatch();
            sw.Start();
            MethodInfo getHandlerForCommandMethod = GetMethod<ICommandRegistry>(x => x.GetHandlerForCommand<ICommand>()).MakeGenericMethod(query.GetType());
            var handlerType = (Type)getHandlerForCommandMethod.Invoke(_commandRegistry, null);
            dynamic handler = _commandHandlerFactory.Get(handlerType);

            
            
            await handler.Execute((dynamic)query);

            sw.Stop();
            Console.WriteLine(sw.ElapsedMilliseconds);

            return query.Result;
        }

        public static MethodInfo GetMethod<T>(Expression<Action<T>> expr)
        {
            return((MethodCallExpression)expr.Body)
                .Method
                .GetGenericMethodDefinition();
        }
    }
}