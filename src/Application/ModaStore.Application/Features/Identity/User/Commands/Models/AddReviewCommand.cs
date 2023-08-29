using MediatR;
using ModaStore.Application.DTOs.Catalog;

namespace ModaStore.Application.Features.Identity.User.Commands.Models;

public class AddReviewCommand : IRequest<ReviewDto>
{
    public AddReviewCommand(ReviewDto review)
    {
        ReviewDto = review;
    }
    
    public ReviewDto ReviewDto { get; set; }
}
