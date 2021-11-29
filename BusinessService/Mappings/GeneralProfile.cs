using Application.DTOs.Book;
using Application.DTOs.Book.CreateDTO;
using Application.DTOs.Book.UpdateDTO;
using AutoMapper;
//using BusinessService.Services.OrgPositionServices.Commands.CreateOrgPosition;
using Domain.Entities.BookEntity;
using System.Collections.Generic;

namespace BusinessService.Mappings
{
    public class GeneralProfileLayer : Profile
    {
        public GeneralProfileLayer()
        {


            //BasicData
            CreateMap<Book, BookDTO>();
            CreateMap<List<Book>, List<BookDTO>>();
            //CreateMap<BookDTO, Book>();
            CreateMap<RequestCreateBookDTO, Book>();
            CreateMap<Book,RequestCreateBookDTO>();
            CreateMap<RequestUpdateBookDTO, Book>();
            CreateMap<Book, RequestUpdateBookDTO>();




        }
    }
}
