using System;
using System.Linq;
using System.Reflection;
using Autofac;
using CommandHandlerSpike.Autofac;
using CommandHandlerSpike.CommandInfrastructure;

namespace CommandHandlerSpike
{
    class Program
    {
        private static CommandProcessor _commandProcessor;


        static void Main(string[] args)
        {
            ICommandRegistry commandRegistry = new CommandRegistry();            
            commandRegistry.Register<SayHelloQuery, SayHelloQueryHandler>();
            commandRegistry.Register<SayHelloCommand, SayHelloCommandHandler>();          
  
            ContainerBuilder container = new ContainerBuilder();            
            RegisterHandlers(container);

            AutofacCommandHandlerFactory autofacCommandHandlerFactory = new AutofacCommandHandlerFactory(container.Build());

            _commandProcessor = new CommandProcessor(commandRegistry, autofacCommandHandlerFactory);

            ExecuteCommand(_commandProcessor);
            ExecuteCommand(_commandProcessor);
            ExecuteQuery(_commandProcessor);

            Console.ReadLine();
        }

        private static void ExecuteCommand(CommandProcessor commandProcessor)
        {
            Console.WriteLine("Executing command");
            var command = new SayHelloCommand("Dan");
            commandProcessor.Execute(command).Wait();            
        }

        private static void ExecuteQuery(CommandProcessor commandProcessor)
        {
            Console.WriteLine("Executing query");
            var query = new SayHelloQuery("Dan");
            commandProcessor.Execute(query).Wait();
            Console.WriteLine(query.Result);
        }

        private static void RegisterHandlers(ContainerBuilder container)
        {
            container.RegisterAssemblyTypes(Assembly.GetExecutingAssembly())
                .Where(t => t.GetInterfaces()
                    .Any(i => i.IsAssignableFrom(typeof (ICommandHandler))))
                .AsSelf()
                .InstancePerDependency();
        }
    }
}
