using MediatR;
using ModaStore.API.Models;
using ModaStore.Domain.Models;

namespace ModaStore.API.Application.Queries.Models.Common;

public record GetQueryById<D, M>(int Id) : IRequest<D> 
    where D : BaseApiEntityModel 
    where M : BaseEntity;