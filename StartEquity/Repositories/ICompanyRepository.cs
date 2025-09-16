using System.Collections.Generic;
using StartEquity.Models;

namespace StartEquity.Repositories
{
    public interface ICompanyRepository
    {
        List<Company> GetAll();
        Company GetById(string id);
        void Insert(Company c);
        void Update(Company c);
        void Delete(Company c);
    }

}
