using System.Linq;
using System.Security.Cryptography.X509Certificates;
using AutoMapper;
using BookStore.API.Dtos.Author;
using BookStore.API.Dtos.Book;
using BookStore.API.Dtos.Category;
using BookStore.Domain.Models;

namespace BookStore.API.Configuration
{
    public class AutomapperConfig : Profile
    {
        public AutomapperConfig()
        {
            CreateMap<Category, CategoryAddDto>().ReverseMap();
            CreateMap<Category, CategoryEditDto>().ReverseMap();
            CreateMap<Category, CategoryResultDto>().ReverseMap();


            CreateMap<Book, BookEditDto>().ReverseMap();
            CreateMap<Book, BookResultDto>().ReverseMap();


            CreateMap<Book, BookAddDto>().ForMember(dto =>
                dto.AuthorIds, opt =>
                opt.MapFrom(x => x.Authors.Select(a => a.Id).ToList()));
            CreateMap<BookAddDto, Book>();

            CreateMap<Book, BookEditDto>().IncludeMembers(s => s.Authors).ForMember(dto =>
                dto.AuthorIds, opt => opt.MapFrom(x => x.Authors.Select(a => a.Id).ToList()));


            CreateMap<Book, BookResultDto>().ForMember(dto =>
                    dto.AuthorIds, opt =>
                    opt.MapFrom(x => x.Authors.Select(a => a.Id).ToList()))
                .ForMember(dto => dto.AuthorName,
                    opt =>
                        opt.MapFrom(x => x.Authors.Select(a => a.Name).ToList()));

            //CreateMap<BookResultDto, Book>().ForMember(b => b.Authors,
            //    opt => opt.MapFrom(x => x.AuthorIds));


            CreateMap<Author, AuthorAddDto>().ReverseMap();
            CreateMap<Author, AuthorEditDto>().ReverseMap();
            CreateMap<Author, AuthorResultDto>().ReverseMap();
        }
    }
}