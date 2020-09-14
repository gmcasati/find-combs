using System;
using System.Collections.Generic;

namespace FindCombsApi.Commons.DTO
{
    public class RequestDTO
    {
        public IList<int> Values { get; set; }
        public int Key { get; set; }
        public IList<int> Combination { get; set; }
        public DateTime RequestTime { get; set; }
    }
}
