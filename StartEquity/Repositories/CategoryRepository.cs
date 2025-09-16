using System;
using System.Collections.Generic;
using System.Linq;
using StartEquity.Models;

namespace StartEquity.Repositories
{
    public class CategoryRepository : ICategoryRepository
    {
        private readonly AppDbContext _context;

        public CategoryRepository(AppDbContext context)
        {
            _context = context;
        }

        public List<Category> GetAll() => _context.Categories.ToList();

        public Category GetById(string id) => _context.Categories.FirstOrDefault(c => c.Id == id);

        public void Insert(Category c)
        {
            c.Id = Guid.NewGuid().ToString();
            _context.Categories.Add(c);
        }

        public void Update(Category c) => _context.Categories.Update(c);

        public void Delete(Category c) => _context.Categories.Remove(c);
    }
}
