using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using FindCombsApi.Infrastructure.Interfaces;
using FindCombsApi.Models;
using MongoDB.Driver;

namespace FindCombsApi.Infrastructure.Repositories
{
    public class RequestRepository : IRequestRepository
    {
        private readonly IMongoCollection<Request> _requestsCollection;
        public RequestRepository(ICombinationsDatabaseSettings settings)
        {
            var client = new MongoClient(settings.ConnectionString);
            var database = client.GetDatabase(settings.DatabaseName);

            _requestsCollection = database.GetCollection<Request>(settings.RequestsCollectionName);
        }
        public async Task<Request> Create(IList<int> values, int key, IList<int> sols)
        {
            var request = new Request { Date = DateTime.Now, Values = values, Key = key, Combination = sols };
            await _requestsCollection.InsertOneAsync(request);
            return request;
        }
    }
}
