using System;

namespace FindCombsApi.Models
{
    public class CombinationsDatabaseSettings : ICombinationsDatabaseSettings
    {
        public string RequestsCollectionName { get; set; }
        public string ConnectionString { get; set; }
        public string DatabaseName { get; set; }
    }

    public interface ICombinationsDatabaseSettings
    {
        string RequestsCollectionName { get; set; }
        string ConnectionString { get; set; }
        string DatabaseName { get; set; }
    }
}
