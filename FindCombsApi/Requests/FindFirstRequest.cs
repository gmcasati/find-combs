using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace FindCombsApi.Requests
{
    public class FindFirstRequest
    {
        [Required]
        public List<int> Values { get; set; }
        [Required]
        public int Key { get; set; }
    }
}
