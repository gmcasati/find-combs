using System;
using System.Collections.Generic;
using FindCombsApi.Models;
using MongoDB.Driver;

namespace FindCombsApi.Repositories
{
    public class RequestRepository
    {
        private readonly IMongoCollection<Request> _requests;
        public RequestRepository(ICombinationsDatabaseSettings settings)
        {
            var client = new MongoClient(settings.ConnectionString);
            var database = client.GetDatabase(settings.DatabaseName);

            _requests = database.GetCollection<Request>(settings.RequestsCollectionName);
        }
        public Request Create(IEnumerable<int> values, int key, IEnumerable<int> sols)
        {
            var request = new Request { Date = DateTime.Now, Values = values, Key = key, Combination = sols };
            _requests.InsertOne(request);
            return request;
        }
    }
}
