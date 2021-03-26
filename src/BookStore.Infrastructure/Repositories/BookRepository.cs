﻿using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BookStore.Domain.Interfaces;
using BookStore.Domain.Models;
using BookStore.Infrastructure.Context;
using Microsoft.EntityFrameworkCore;

namespace BookStore.Infrastructure.Repositories
{
    public class BookRepository : Repository<Book>, IBookRepository
    {
        public BookRepository(BookStoreDbContext context) : base(context)
        {
        }

        public override async Task<List<Book>> GetAll()
        {
            return await Db.Books.AsNoTracking()
                .Include(b => b.Category)
                .Include(a => a.Authors)
                .OrderBy(b => b.Name)
                .ToListAsync();
        }

        public override async Task<Book> GetById(int id)
        {
            return await Db.Books.AsNoTracking()
                .Include(b => b.Category)
                .Include(a => a.Authors)
                .Where(b => b.Id == id)
                .FirstOrDefaultAsync();
        }

        public async Task<IEnumerable<Book>> GetBooksByCategory(int categoryId)
        {
            return await Search(b => b.CategoryId == categoryId);
        }

        public async Task<IEnumerable<Book>> SearchBookWithCategory(string searchedValue)
        {
            return await Db.Books.AsNoTracking()
                .Include(b => b.Category)
                .Where(b => b.Name.Contains(searchedValue) ||
                            b.Description.Contains(searchedValue) ||
                            b.Category.Name.Contains(searchedValue))
                .ToListAsync();
        }

        public async Task<IEnumerable<Book>> GetBooksByAuthors(int authorId)
        {
            return await Db.Books.AsNoTracking()
                .Include(a => a.Authors)
                .Where(x => x.Id == authorId)
                .ToListAsync();
        }

        public async Task<IEnumerable<Book>> SearchBookWithAuthors(string searchedValue)
        {
            return await Db.Books.AsNoTracking()
                .Include(a => a.Authors)
                .Where(b => b.Name.Contains(searchedValue) ||
                            b.Description.Contains(searchedValue) ||
                            b.Authors.Any(x => x.Name.Contains(searchedValue)))
                .ToListAsync();
        }
    }
}