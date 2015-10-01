using CommandHandlerSpike.CommandInfrastructure;

namespace CommandHandlerSpike
{
    public class SayHelloQuery : IQuery<string>
    {
        private readonly string _name;

        public SayHelloQuery(string name)
        {
            _name = name;
        }

        public string Result { get; set; }

        public string Name
        {
            get { return _name; }
        }
    }
}
