using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BookStore.Domain.Interfaces;
using BookStore.Domain.Models;

namespace BookStore.Domain.Services
{
    public class AuthorService : IAuthorService
    {
        private readonly IAuthorRepository _authorRepository;
        private readonly IBookService _bookService;

        public AuthorService(IAuthorRepository authorRepository, IBookService bookService)
        {
            _authorRepository = authorRepository;
            _bookService = bookService;
        }

        public async Task<IEnumerable<Author>> GetAll()
        {
            return await _authorRepository.GetAll();
        }

        public async Task<Author> GetById(int id)
        {
            return await _authorRepository.GetById(id);
        }

        public async Task<Author> Add(Author author)
        {
            if (_authorRepository.Search(p => p.Name == author.Name).Result.Any())
                return null;

            await _authorRepository.Add(author);
            return author;
        }

        public async Task<Author> Update(Author author)
        {
            if (_authorRepository.Search(p => p.Name == author.Name && p.Id != author.Id).Result.Any())
                return null;
            author.ModifiedDateTime = DateTime.UtcNow;
            await _authorRepository.Update(author);
            return author;
        }

        public async Task<bool> Remove(Author author)
        {
            var books = await _bookService.GetBooksByAuthor(author.Id);
            if (books.Any()) return false;

            await _authorRepository.Remove(author);
            return true;
        }

        public async Task<IEnumerable<Author>> Search(string authorName)
        {
            return await _authorRepository.Search(p => p.Name.Contains(authorName));
        }

        public async Task<List<Author>> GetByIds(List<int> authorIds)
        {
            return await _authorRepository.GetByIdS(authorIds);
        }

        public void Dispose()
        {
            _authorRepository?.Dispose();
        }
    }
}