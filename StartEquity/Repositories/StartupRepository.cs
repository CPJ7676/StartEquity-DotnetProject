using System;
using System.Collections.Generic;
using System.Linq;

namespace StartEquity.Models
{
    public class StartupRepository : IStartupRepository
    {
        private readonly AppDbContext _context;
        public StartupRepository(AppDbContext context) { _context = context; }

        public List<Startup> GetAll() => _context.Startups.ToList();

        public Startup GetById(string id) => _context.Startups
            .FirstOrDefault(x => x.Id == id);

        public void Insert(Startup s)
        {
            s.Id = Guid.NewGuid().ToString();
            _context.Startups.Add(s);
        }

        public void Update(Startup s) => _context.Startups.Update(s);

        public void Delete(Startup s) => _context.Startups.Remove(s);
    }
}
