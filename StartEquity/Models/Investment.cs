using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System.ComponentModel.DataAnnotations.Schema;

namespace StartEquity.Models
{
    public class Investment
    {
        public string Id { get; set; }

        public string RoundId { get; set; }
        public Round Round { get; set; }

        public string CompanyId { get; set; } // duplicate for easy queries
        public Company Company { get; set; }

        public string InvestorId { get; set; }
        public Investor Investor { get; set; }

        [Column(TypeName = "decimal(18,2)")]
        public decimal Amount { get; set; } // money invested

        // percent of whole company (e.g. 0.75 = 0.75%)
        [Column(TypeName = "decimal(12,6)")]
        public decimal EquityPercent { get; set; }

        public DateTime InvestedAt { get; set; } = DateTime.UtcNow;

        public bool IsSecondary { get; set; } = false; // if created from transfer
    }

}

