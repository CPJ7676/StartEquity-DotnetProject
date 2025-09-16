using System;
using System.Collections.Generic;
using System.Linq;
using StartEquity.Models;

namespace StartEquity.Repositories
{
    public class TransferRepository : ITransferRepository
    {
        private readonly AppDbContext _context;

        public TransferRepository(AppDbContext context)
        {
            _context = context;
        }

        public List<Transfer> GetAll() => _context.Transfers.ToList();

        public Transfer GetById(string id) => _context.Transfers.FirstOrDefault(t => t.Id == id);

        public void Insert(Transfer t)
        {
            t.Id = Guid.NewGuid().ToString();
            _context.Transfers.Add(t);
        }

        public void Update(Transfer t) => _context.Transfers.Update(t);

        public void Delete(Transfer t) => _context.Transfers.Remove(t);
    }
}
