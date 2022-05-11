using System;
using System.ServiceModel;
using System.ServiceModel.Channels;

namespace SoapClient
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("___________________________________________________________________________________________");
            Random numGen = new Random();
            double x = numGen.NextDouble() * 20;
            double y = numGen.NextDouble() * 20;

            var serviceAddress = "http://localhost:1001/CalculatorService.svc";

            var client = new CalculatorServiceClient(new BasicHttpBinding(), new EndpointAddress(serviceAddress));
            Console.WriteLine($"{x} + {y} == {client.Add(x, y)}");
            Console.WriteLine($"{x} - {y} == {client.Subtract(x, y)}");
            Console.WriteLine($"{x} * {y} == {client.Multiply(x, y)}");
            Console.WriteLine($"{x} / {y} == {client.Divide(x, y)}");
            client.Get("Client");
            Console.WriteLine("___________________________________________________________________________________________");
            Console.Read();
        }
    }

    class CalculatorServiceClient : ClientBase<ICalculatorService>
    {
        public CalculatorServiceClient(Binding binding, EndpointAddress remoteAddress) : base(binding, remoteAddress) { }
        public double Add(double x, double y) => Channel.Add(x, y);
        public double Subtract(double x, double y) => Channel.Subtract(x, y);
        public double Multiply(double x, double y) => Channel.Multiply(x, y);
        public double Divide(double x, double y) => Channel.Divide(x, y);

        public void Get(string str)
        {
            Console.WriteLine(Channel.Get(str));
        }
    }

    [ServiceContract]
    public interface ICalculatorService
    {
        [OperationContract]
        double Add(double x, double y);
        [OperationContract]
        double Subtract(double x, double y);
        [OperationContract]
        double Multiply(double x, double y);
        [OperationContract]
        double Divide(double x, double y);
        [OperationContract]
        string Get(string str);
    }
}
