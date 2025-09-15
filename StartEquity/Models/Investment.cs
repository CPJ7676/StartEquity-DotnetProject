using System;
using System.Collections.Generic;

namespace StartEquity.Models
{
	public class Investment //// join table (many-to-many)
    {
        public int InvestmentId { get; set; }

        public int StartupId { get; set; }
        public Startup Startup { get; set; }

        public int InvestorId { get; set; }
        public Investor Investor { get; set; }

        public decimal Amount { get; set; }           // money invested
        public decimal EquityPercent { get; set; }    // how much % of startup this gives
    }
}

