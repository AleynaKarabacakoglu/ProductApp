using AutoMapper;
using MediatR;
using ProductApp.Application.DTOs;
using ProductApp.Application.Interfaces.Repository;
using ProductApp.Application.Wrappers;
using System.Collections.Generic;

namespace ProductApp.Application.Features.Queries
{
    public class GetAllProductsQuery : IRequest<ServiceResponse<List<ProductViewDto>>>
    {

        public class GetAllProductsQueryHandler : IRequestHandler<GetAllProductsQuery, ServiceResponse<List<ProductViewDto>>>
        {
            private readonly IProductRepository _productRepository;
            private readonly IMapper _mapper;
            public GetAllProductsQueryHandler(IProductRepository productRepository, IMapper mapper)
            {
                _productRepository = productRepository;
                _mapper = mapper;
            }

            public async  Task<ServiceResponse<List<ProductViewDto>>> Handle(GetAllProductsQuery request, CancellationToken cancellationToken)
            {
                var products = await _productRepository.GetAllAsync();
                var model = _mapper.Map<List<ProductViewDto>>(products);
                return new ServiceResponse<List<ProductViewDto>>(model);
            }
        }
    }
}
