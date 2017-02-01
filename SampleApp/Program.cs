using System;
using MongoDB.Bson;
using MongoLayer;
class Program
{
    public class Test : IEntity
    {
        public DateTime CreatedOn => DateTime.Now;
        public string Content { get; set; }
        public string Id { get; set; }

        public DateTime ModifiedOn => DateTime.Now;

        public ObjectId ObjectId => ObjectId.GenerateNewId();
    }
    static void Main(string[] args)
    {
        Repository<Test> _testRepository = new Repository<Test>("mongodb://127.0.0.1:27017/test");
        string id = Guid.NewGuid().ToString();

        _testRepository.Insert(new Test { Content = "Hello World!", Id = id });

        Console.WriteLine(_testRepository.Get(id).Content);

        Console.Read();
    }
}