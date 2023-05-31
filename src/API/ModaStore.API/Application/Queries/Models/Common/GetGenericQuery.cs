using MediatR;
using ModaStore.API.Models;
using ModaStore.Domain.Models;

namespace ModaStore.API.Application.Queries.Models.Common;

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




