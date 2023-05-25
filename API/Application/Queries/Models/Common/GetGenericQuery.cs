using API.Models;
using Core;
using Core.Models;
using MediatR;

namespace API.Application.Queries.Models.Common;

// public class GetGenericQuery<TModel, TEntity> : IRequest<IReadOnlyList<TModel>>
// {
//     
// }

// public record GetGenericQuery<D, M>(string Id = null) : IRequest<IReadOnlyList<D>> 
//     where D : BaseApiEntityModel 
//     where M : BasicEntity;

public record GetGenericQuery<D, M>(string Id = null) : IRequest<IReadOnlyList<D>> 
    where D : BaseApiEntityModel 
    where M : BaseEntity;




