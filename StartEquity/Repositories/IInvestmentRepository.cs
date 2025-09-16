using System.Collections.Generic;
using StartEquity.Models;

namespace StartEquity.Repositories
{
    public interface IInvestmentRepository
    {
        List<Investment> GetAll();
        Investment GetById(string id);
        void Insert(Investment inv);
        void Update(Investment inv);
        void Delete(Investment inv);
    }
}
