using System;
using System.Collections.Generic;
using System.Linq;
using StartEquity.Models;

namespace StartEquity.Repositories
{
    public class RoundRepository : IRoundRepository
    {
        private readonly AppDbContext _context;

        public RoundRepository(AppDbContext context)
        {
            _context = context;
        }

        public List<Round> GetAll() => _context.Rounds.ToList();

        public Round GetById(string id) => _context.Rounds.FirstOrDefault(r => r.Id == id);

        public void Insert(Round r)
        {
            r.Id = Guid.NewGuid().ToString();
            _context.Rounds.Add(r);
        }

        public void Update(Round r) => _context.Rounds.Update(r);

        public void Delete(Round r) => _context.Rounds.Remove(r);
    }
}
