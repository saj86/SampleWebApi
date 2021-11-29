using Application.Interfaces.Repositories.EmployeeIRepo;
using Application.Wrappers;
using AutoMapper;
using BusinessService.Services.EmployeeServices.Queries;
using MediatR;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace BusinessService.Services.Devextreme
{
    public class GetLoadOptions : IRequest<PagedResponse<IEnumerable<GetAllEmployeesDto>>>
    {
        public List<String> LoadOption { get; set; }
        public List<String> Source { get; set; }

    }
    public class GetAllEmployeeQueryHandler : IRequestHandler<GetLoadOptions, PagedResponse<IEnumerable<GetAllEmployeesDto>>>
    {
        private readonly IEmployeeRepositoryAsync _productRepository;
        private readonly IMapper _mapper;
        public GetAllEmployeeQueryHandler(IEmployeeRepositoryAsync productRepository, IMapper mapper)
        {
            _productRepository = productRepository;
            _mapper = mapper;
        }

        public Task<PagedResponse<IEnumerable<GetAllEmployeesDto>>> Handle(GetLoadOptions request, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }
    }

}