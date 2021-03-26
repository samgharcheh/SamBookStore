using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using BookStore.Domain.Models;

namespace BookStore.Domain.Interfaces
{
    public interface IAuthorService : IDisposable
    {
        Task<IEnumerable<Author>> GetAll();
        Task<Author> GetById(int id);
        Task<Author> Add(Author category);
        Task<Author> Update(Author category);
        Task<bool> Remove(Author category);
        Task<IEnumerable<Author>> Search(string categoryName);
        Task<List<Author>> GetByIds(List<int> authorIds);
    }
}