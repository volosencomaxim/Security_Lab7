using System;
using System.Collections.Generic;

namespace Security_Lab7
{
    class Program
    {
        static void Main(string[] args)
        {
            var mongo = new MongoDBConnector();

            mongo.ConnectToLocalDB();

            Console.ReadKey();
        }
    }
}
