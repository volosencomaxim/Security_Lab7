using MongoDB.Bson;
using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Security_Lab7
{
    class MongoDBConnector
    {
        MongoClient client;
        IMongoDatabase database;
        IMongoCollection<People> collection;

        public void ConnectToCloudDB()
        {
            client = new MongoClient("mongodb+srv://security:securitypass@cluster0.w5nv5.mongodb.net/<dbname>?retryWrites=true&w=majority");
            database = client.GetDatabase("security_db");
            collection = database.GetCollection<People>("people");

            var data = collection.Find(s => s.Name.Length > 0).ToList();

            foreach (var item in data)
            {
                Console.WriteLine(item.Mail);
            }
        }

        public void ConnectToLocalDB()
        {
            client = new MongoClient("mongodb://localhost:27017/?readPreference=primary&appname=MongoDB%20Compass&ssl=false");
            database = client.GetDatabase("securitydb");
            collection = database.GetCollection<People>("people");

            var data = collection.Find(s => s.Name.Length > 0).ToList();

            PrintOriginalData(data);

            PrintDecryptedData(data);
        }

        private void PrintOriginalData(List<People> data)
        {

            Console.WriteLine("Original Data : ");
            foreach (var item in data)
            {
                Console.WriteLine($"{item.Name} | {item.Mail} | {item.Token}");
            }
        }

        private void PrintDecryptedData(List<People> data)
        {
            string decryptedMail;
            string decryptedToken;

            Console.WriteLine("\n\nDecrypted Data : ");
            foreach (var item in data)
            {
                decryptedMail = CryptoEngine.Decrypt(item.Mail);
                decryptedToken = CryptoEngine.Decrypt(item.Token);

                Console.WriteLine($"{item.Name} | {decryptedMail} | {decryptedToken}");
            }
        }
    }
}
