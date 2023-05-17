using API.Application.Queries.Models.Common;
using AutoMapper;
using Core.Interfaces;
using Core.Models;
using Infrastructure.Data;
using MediatR;

namespace API.Application.Queries.Handlers.Common;

public class GetGenericQueryHandler<TModel, TEntity> : IRequestHandler<GetGenericQuery<TModel, TEntity>, IReadOnlyList<TModel>>
    // where TModel : BaseEntity
    where TEntity : BaseEntity
{
    private readonly IUnitOfWork _unitOfWork;
    private readonly IMapper _mapper;

    public GetGenericQueryHandler(IUnitOfWork unitOfWork, IMapper mapper)
    {
        _unitOfWork = unitOfWork;
        _mapper = mapper;
    }

    public async Task<IReadOnlyList<TModel>> Handle(GetGenericQuery<TModel, TEntity> request, CancellationToken cancellationToken)
    {
        var entities = await _unitOfWork.Repository<TEntity>().ListAllAsync();
        var dtos = _mapper.Map<IReadOnlyList<TEntity>, IReadOnlyList<TModel>>(entities);
        return dtos;
    }
}

