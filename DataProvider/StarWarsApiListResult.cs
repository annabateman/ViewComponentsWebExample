using System.Collections.Generic;

namespace DataProvider
{
    public class StarWarsApiListResult<T>
    {
        public int Count { get; set; }
        public string Next { get; set; }
        public string Previous { get; set; }
        public IList<T> Results { get; set; }
    }
}
