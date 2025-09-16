using System;
using System.Collections.Generic;
using System.Linq;
using StartEquity.Models;
using StartEquity.Repositories;

namespace StartEquity.Repositories
{
    public class CompanyRepository : ICompanyRepository
    {
        private readonly AppDbContext _context;

        public CompanyRepository(AppDbContext context) => _context = context;

        public List<Company> GetAll() => _context.Companies.ToList();

        public Company GetById(string id) => _context.Companies.FirstOrDefault(x => x.Id == id);

        public void Insert(Company c)
        {
            c.Id = Guid.NewGuid().ToString();
            _context.Companies.Add(c);
        }

        public void Update(Company c) => _context.Companies.Update(c);

        public void Delete(Company c) => _context.Companies.Remove(c);
    }

}
