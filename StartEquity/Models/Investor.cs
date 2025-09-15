using System;
using System.Collections.Generic;

namespace StartEquity.Models
{
	public class Investor
	{
        public int InvestorId { get; set; }
        public string FullName { get; set; }
        public string Email { get; set; }

        public decimal Balance { get; set; } = 10000; // dummy money

        // navigation
        public List<Investment> Investments { get; set; }
    }
}

