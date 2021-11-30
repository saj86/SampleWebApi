using Application.Validator;
using Domain.Entities.BookEntity;
using Infrastructure.Persistence.Contexts;
using Infrastructure.Persistence.Repositories;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Linq;
using Xunit;

namespace TestWebApi
{
    public class BookTest: BookBase
    {


        [Theory]
        [InlineData("C++", "Persman", "C++ have lower code", 4.2)]
        public void GetList(string title, string autor, string description, decimal price)
        {
            var cnt=_book.GetAllAsync().Result.Count();
            Assert.Equal(3, cnt);
            var row = new Book()
            {
                Description = description,
                Title = title,
                Author = autor,
                Price = price,
                Id = Guid.NewGuid(),
            };
            _book.AddAsync(row);
            
            Assert.NotNull(row);

            var cntAfter = _book.GetAllAsync().Result.Count();
            cnt++;

            Assert.Equal(cnt, cntAfter);

        }

        [Theory]
        [InlineData("C++","Persman","C++ have lower code",4.2)]
        [InlineData("A","Test","Test Description",1.2)]
        public void InsertBook(string title,string autor, string description,decimal price)
        {
            var row=new Book() { 
            Description= description,  
            Title= title,
            Author= autor,
            Price= price,
            Id= Guid.NewGuid(),
            };

            CheckError(new BookValidator(), row);
            var result=_book.AddAsync(row).Result;
            Assert.NotNull(result);

        }

        [Theory]
        [InlineData("C++", "Persman", "C++ have lower code", 4.2,"C63FD052-39BE-414F-92FB-01FA084B9C2C")]
        [InlineData("A++", "Test", "Test Description", 1.2, "441A4389-59AF-4A2B-AFDB-4E5769490848")]
        public void UpdateInsert(string title, string autor, string description, decimal price,Guid id)
        {
            var row = new Book()
            {
                Description = description,
                Title = title,
                Author = autor,
                Price = price,
                Id = id,
            };

            CheckError(new BookValidator(), row);
            var oldRow=_book.GetBookWithId(id).Result;
            Assert.NotNull(oldRow);
            var result = _book.UpdateAsync(row);
            Assert.NotNull(result);

        }
        [Theory]
        [InlineData("C63FD052-39BE-414F-92FB-01FA084B9C2C")]
        [InlineData( "441A4389-59AF-4A2B-AFDB-4E5769490848")]
        public void DeleteInsert(Guid id)
        {
           
            var row = _book.GetBookWithId(id).Result;
            Assert.NotNull(row);
            var result = _book.DeleteAsync(row);
            Assert.NotNull(result);

        }
    }
}
