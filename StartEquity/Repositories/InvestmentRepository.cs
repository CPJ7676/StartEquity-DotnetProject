using System;
using System.Collections.Generic;
using System.Linq;
using StartEquity.Models;

namespace StartEquity.Repositories
{
    public class InvestmentRepository : IInvestmentRepository
    {
        private readonly AppDbContext _context;

        public InvestmentRepository(AppDbContext context)
        {
            _context = context;
        }

        public List<Investment> GetAll() => _context.Investments.ToList();

        public Investment GetById(string id) => _context.Investments.FirstOrDefault(i => i.Id == id);

        public void Insert(Investment inv)
        {
            inv.Id = Guid.NewGuid().ToString();
            _context.Investments.Add(inv);
        }

        public void Update(Investment inv) => _context.Investments.Update(inv);

        public void Delete(Investment inv) => _context.Investments.Remove(inv);
    }
}
