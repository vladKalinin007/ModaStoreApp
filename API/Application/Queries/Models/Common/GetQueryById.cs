using API.Models;
using Core.Models;
using MediatR;

namespace API.Application.Queries.Models.Common;

public record GetQueryById<D, M>(int Id) : IRequest<D> 
    where D : BaseApiEntityModel 
    where M : BaseEntity;