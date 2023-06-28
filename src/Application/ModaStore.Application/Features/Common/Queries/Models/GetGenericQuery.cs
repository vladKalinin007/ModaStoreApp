using MediatR;
using ModaStore.Domain.Entities.Common;
using ModaStore.Domain.Specifications;

namespace ModaStore.Application.Features.Common.Queries.Models;

public record GetGenericQuery<D, E>(string? Id = null, ProductSpecParams? productParams = null) : IRequest<IQueryable<D>> 
    where D : BaseDto 
    where E : BaseEntity;