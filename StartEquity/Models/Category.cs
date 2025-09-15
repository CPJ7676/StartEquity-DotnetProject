using System;
using System.Collections.Generic;

namespace StartEquity.Models
{
	public class Category
	{
        public int CategoryId { get; set; }
        public string Name { get; set; }

        public List<Startup> Startups { get; set; }
    }
}

