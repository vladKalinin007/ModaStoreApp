using MediatR;
using ModaStore.Application.DTOs.Catalog;

namespace ModaStore.Application.Features.Identity.User.Queries.Models;

public class GetUserReviewsQuery : IRequest<List<ReviewDto>>
{
    
}