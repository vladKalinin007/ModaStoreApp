using API.Application.Queries.Models.Common;
using API.Models;
using AutoMapper;
using Core;
using Core.Interfaces;
using Core.Models;
using Infrastructure.Data;
using Infrastructure.Data.temp;
using MediatR;

namespace API.Application.Queries.Handlers.Common;

// public class GetGenericQueryHandler<D,M> : IRequestHandler<GetGenericQuery<D,M>, IReadOnlyList<D>> 
//     where D : BaseApiEntityModel
//     where M : BasicEntity
// {
//     private readonly IUnitOfWorks _unitOfWork;
//     private readonly IMapper _mapper;
//
//     public GetGenericQueryHandler(IUnitOfWorks unitOfWork, IMapper mapper)
//     {
//         _unitOfWork = unitOfWork;
//         _mapper = mapper;
//     }
//
//     public async Task<IReadOnlyList<D>> Handle(GetGenericQuery<D,M> request, CancellationToken cancellationToken)
//     {
//         var entities = await _unitOfWork.Repository<M>().ListAllAsync();
//         return _mapper.Map<IReadOnlyList<M>, IReadOnlyList<D>>(entities);
//     }
// }

public class GetGenericQueryHandler<D,M> : IRequestHandler<GetGenericQuery<D,M>, IReadOnlyList<D>> 
    where D : BaseApiEntityModel
    where M : BaseEntity
{
    private readonly IUnitOfWork _unitOfWork;
    private readonly IMapper _mapper;

    public GetGenericQueryHandler(IUnitOfWork unitOfWork, IMapper mapper)
    {
        _unitOfWork = unitOfWork;
        _mapper = mapper;
    }

    public async Task<IReadOnlyList<D>> Handle(GetGenericQuery<D,M> request, CancellationToken cancellationToken)
    {
        var entities = await _unitOfWork.Repository<M>().ListAllAsync();
        return _mapper.Map<IReadOnlyList<M>, IReadOnlyList<D>>(entities);
    }
}

// public class GetGenericQueryHandler<D,M> : IRequestHandler<GetGenericQuery<D,M>, IQueryable<D>> 
//     where D : BaseApiEntityModel
//     where M : BaseEntity
// {
//     private readonly IUnitOfWork _unitOfWork;
//     private readonly IMapper _mapper;
//
//     public GetGenericQueryHandler(IUnitOfWork unitOfWork, IMapper mapper)
//     {
//         _unitOfWork = unitOfWork;
//         _mapper = mapper;
//     }
//
//     public async Task<IQueryable<D>> Handle(GetGenericQuery<D,M> request, CancellationToken cancellationToken)
//     {
//         var entities = await _unitOfWork.Repository<M>().ListAllAsync();
//         return _mapper.Map<IQueryable<M>, IQueryable<D>>(entities);
//     }
// }

