using AutoMapper;
using BookStore.Application.Models;
using BookStore.Core.Entities;

namespace BookStore.Application.Mapper
{
    public class Profiler : Profile
    {
        public Profiler()
        {
            CreateMap<Book, BookModel>()
                .ForMember(dest => dest.AuthorsName, opt => opt.MapFrom(src => src.AuthorsLink.Select(al => al.Author.Name).ToList()));
        }
    }
}