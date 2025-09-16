using System;
using System.Collections.Generic;
using System.Linq;
using StartEquity.Models;

namespace StartEquity.Repositories
{
    public class InvestorRepository : IInvestorRepository
    {
        private readonly AppDbContext _context;

        public InvestorRepository(AppDbContext context)
        {
            _context = context;
        }

        public List<Investor> GetAll() => _context.Investors.ToList();

        public Investor GetById(string id) => _context.Investors.FirstOrDefault(i => i.Id == id);

        public void Insert(Investor i)
        {
            i.Id = Guid.NewGuid().ToString();
            _context.Investors.Add(i);
        }

        public void Update(Investor i) => _context.Investors.Update(i);

        public void Delete(Investor i) => _context.Investors.Remove(i);
    }
}
