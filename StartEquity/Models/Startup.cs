using System;
using System.Collections.Generic;

namespace StartEquity.Models
{
	public class Startup
	{
        public int StartupId { get; set; }
        [Required]
        public string Name { get; set; }
        public string Industry { get; set; }

        // fundraising details
        public decimal Valuation { get; set; }         // e.g. 1,000,000
        public decimal EquityToDilute { get; set; }    // e.g. 10% (for this round)
        public decimal TargetAmount { get; set; }      // Valuation * (EquityToDilute / 100)
        public decimal RaisedAmount { get; set; } = 0; // track sum of investments
        public bool IsClosed { get; set; } = false;    // true if fully funded

        // relationships
        public int CategoryId { get; set; }
        public Category Category { get; set; }
        public List<Investment> Investments { get; set; }
    }
}

