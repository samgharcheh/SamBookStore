using System.Collections.Generic;
using System.Threading.Tasks;
using AutoMapper;
using BookStore.API.Dtos.Author;
using BookStore.Domain.Interfaces;
using BookStore.Domain.Models;
using Microsoft.AspNetCore.Mvc;

namespace BookStore.API.Controllers
{
    [Route("api/[controller]")]
    public class AuthorsController : MainController
    {
        private readonly IAuthorService _authorService;
        private readonly IMapper _mapper;

        public AuthorsController(IMapper mapper,
                                    IAuthorService authorService)
        {
            _mapper = mapper;
            _authorService = authorService;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var authors = await _authorService.GetAll();

            return Ok(_mapper.Map<IEnumerable<AuthorResultDto>>(authors));
        }

        [HttpGet("{id:int}")]
        public async Task<IActionResult> GetById(int id)
        {
            var author = await _authorService.GetById(id);

            if (author == null) return NotFound();

            return Ok(_mapper.Map<AuthorResultDto>(author));
        }

        [HttpPost]
        public async Task<IActionResult> Add(AuthorAddDto authorDto)
        {
            if (!ModelState.IsValid) return BadRequest();

            var author = _mapper.Map<Author>(authorDto);
            var authorResult = await _authorService.Add(author);

            if (authorResult == null) return BadRequest();

            return Ok(_mapper.Map<AuthorResultDto>(authorResult));
        }

        [HttpPut("{id:int}")]
        public async Task<IActionResult> Update(int id, AuthorEditDto authorDto)
        {
            if (id != authorDto.Id) return BadRequest();

            if (!ModelState.IsValid) return BadRequest();

            await _authorService.Update(_mapper.Map<Author>(authorDto));

            return Ok(authorDto);
        }

        [HttpDelete("{id:int}")]
        public async Task<IActionResult> Remove(int id)
        {
            var author = await _authorService.GetById(id);
            if (author == null) return NotFound();

            var result = await _authorService.Remove(author);

            if (!result) return BadRequest();

            return Ok();
        }

        [Route("search/{author}")]
        [HttpGet]
        public async Task<ActionResult<List<Author>>> Search(string author)
        {
            var authors = _mapper.Map<List<Author>>(await _authorService.Search(author));

            if (authors == null || authors.Count == 0)
                return NotFound("None author was founded");

            return Ok(authors);
        }
    }
}