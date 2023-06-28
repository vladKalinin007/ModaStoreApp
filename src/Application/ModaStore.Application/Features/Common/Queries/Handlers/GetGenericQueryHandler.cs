using System.Linq.Expressions;
using AutoMapper;
using AutoMapper.QueryableExtensions;
using MediatR;
using Microsoft.EntityFrameworkCore;
using ModaStore.Application.DTOs.Catalog;
using ModaStore.Application.Extensions;
using ModaStore.Application.Extensions.Mapper;
using ModaStore.Application.Features.Common.Queries.Models;
using ModaStore.Application.Mapping.Config;
using ModaStore.Domain.Entities.Catalog;
using ModaStore.Domain.Entities.Common;
using ModaStore.Domain.Interfaces.Catalog;
using ModaStore.Domain.Interfaces.Data;
using ModaStore.Domain.Specifications;
using ModaStore.Infrastructure.Data;

namespace ModaStore.Application.Features.Common.Queries.Handlers;

public class GetGenericQueryHandler<D,E> : IRequestHandler<GetGenericQuery<D,E>, IQueryable<D>> 
    where D : BaseDto
    where E : BaseEntity
{
    private readonly StoreContext _dbContext;
    private readonly IRepository<Product> _productRepository;
    private readonly IMapper _mapper;

    public GetGenericQueryHandler(
        StoreContext dbContext,
        IRepository<Product> productRepository,
        IMapper mapper
        )
    {
        _dbContext = dbContext;
        _productRepository = productRepository;
        _mapper = mapper;
    }

    public async Task<IQueryable<D>> Handle(GetGenericQuery<D, E> request, CancellationToken cancellationToken)
    {
        
        if (typeof(E) == typeof(Product))
        {

            if (string.IsNullOrEmpty(request.Id))
            {
                var specs = new ProductsWithTypesAndBrandsSpecification(request.productParams);
                var countSpec = new ProductWithFiltersForCountSpecification(request.productParams);
                var products = await _productRepository.GetAllWithSpecAsync(specs);
                // var totalItems = await _productRepository.CountAsync(countSpec);
                var productsDto = products.AsQueryable().ToDto<D>();
                return productsDto;
            }
        
            var spec = new ProductsWithTypesAndBrandsSpecification(request.Id);
            Product product = await _productRepository.GetEntityWithSpec(spec);
            var productDto = product.ToDtoQuery<D>();
            return productDto;
            
        }
        
        // don't write code here
        var query = _dbContext.Set<E>().AsQueryable();
        
        if (string.IsNullOrEmpty(request.Id))
        {
            var dtoQuery = query.ToDto<D>();        

            return dtoQuery;
        }
        
        return query.Where(x => x.Id == request.Id).ToDto<D>();
        
    }
}