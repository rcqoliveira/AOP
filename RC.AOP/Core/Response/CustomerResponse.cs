using System;
using System.Collections.Generic;

namespace RC.AOP
{
    public class CustomerResponse
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public DateTime CreatedDate { get; set; }
        public IEnumerable<RulesResponse> RulesResponses { get; set; }
    }
}