using Domain.Entities.BookEntity;
using FluentValidation;
using Infrastructure.Persistence.Contexts;
using Infrastructure.Persistence.Repositories;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Text;
using Xunit;

namespace TestWebApi
{
    public  class BookBase
    {
        protected DataBaseContext ctx;
        protected BookRepositoryAsync _book;
        public BookBase(DataBaseContext ctx = null)
        {
            this.ctx = ctx ?? GetInMemoryDBContext();
            _book = new BookRepositoryAsync(this.ctx);
            _book.AddAsync(new Book() {Title = "The Four Winds: A Novel", Author = "Kristin Hannah", Description = "From the number-one bestselling author of The Nightingale and The Great Alone comes a powerful American epic about love and heroism and hope, set during the Great Depression, a time when the country was in crisis and at war with itself, when millions were out of work and even the land seemed to have turned against them", Id = new Guid("C63FD052-39BE-414F-92FB-01FA084B9C2C"),  Price = (decimal)4.99 });
            _book.AddAsync(new Book() {Title = "The Fifth Season (The Broken Earth Book 1)", Author = "N.K.Jemisin", Description = "At the end of the world, a woman must hide her secret power and find her kidnapped daughter in this \"intricate and extraordinary\" Hugo Award winning novel of power, oppression, and revolution. (The New York Times)", Id = Guid.NewGuid(),  Price = (decimal)3.4 });
            _book.AddAsync(new Book() {Title = "The Rose Code: A Novel", Author = "Kate Quinn", Description = "The New York Times and USA Today bestselling author of The Huntress and The Alice Network returns with another heart-stopping World War II story of three female code breakers at Bletchley Park and the spy they must root out after the war is over.", Id = Guid.NewGuid(),  Price = (decimal)6.5 });
        }
        protected DataBaseContext GetInMemoryDBContext()
        {
            var serviceProvider = new ServiceCollection()
                .AddEntityFrameworkInMemoryDatabase()
                .BuildServiceProvider();
            var builder = new DbContextOptionsBuilder<DataBaseContext>();
            var options = builder.UseInMemoryDatabase("booktest").UseInternalServiceProvider(serviceProvider).Options;
            DataBaseContext dbContext = new DataBaseContext(options);
            dbContext.Database.EnsureDeleted();
            dbContext.Database.EnsureCreated();
            return dbContext;
        }
        protected void CheckError<T>(AbstractValidator<T> validator, T vm)
        {
            var val = validator.Validate(vm);
            Assert.True(val.IsValid);

        }
    }
}
