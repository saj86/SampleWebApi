using Application.Interfaces;
using Application.Interfaces.Services.IBook.Commands.CreateBookService;
using Application.Interfaces.Services.IBook.Commands.DeleteBookService;
using Application.Interfaces.Services.IBook.Commands.UpdateBookService;
using Application.Interfaces.Services.IBook.Queries;
using BusinessService.Services.BookServices.Commands.CreateBookService;
using BusinessService.Services.BookServices.Commands.DeleteBookService;
using BusinessService.Services.BookServices.Commands.UpdateBookService;
using BusinessService.Services.BookServices.Queries;
using Domain.Settings;
using Infrastructure.BusinessService.Services;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Infrastructure.BusinessService
{
    public static class ServiceRegistration
    {
        public static void AddSharedInfrastructure(this IServiceCollection services, IConfiguration _config)
        {
            services.AddTransient<IDateTimeService, DateTimeService>();
            

            //Register Get Book List
            services.AddTransient<IGetBookService, GetBookService>();
            // Register Create book Service
            services.AddTransient<ICreateBookService, CreateBookService>();
            // Register Delete book Service
            services.AddTransient<IDeleteBookService, DeleteBookService>();
            // Register Update book Service
            services.AddTransient<IUpdateBookService, UpdateBookService>();




        }
    }
}
