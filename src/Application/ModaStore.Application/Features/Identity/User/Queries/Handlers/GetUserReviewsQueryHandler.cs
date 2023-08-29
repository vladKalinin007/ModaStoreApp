using MediatR;
using Microsoft.AspNetCore.Identity;
using ModaStore.Application.DTOs.Catalog;
using ModaStore.Application.Extensions;
using ModaStore.Application.Extensions.Mapper;
using ModaStore.Application.Features.Identity.User.Queries.Models;
using ModaStore.Domain.Entities.Identity;
using ModaStore.Domain.Interfaces.Customer;
using ModaStore.Domain.Interfaces.Identity.Authentication;

namespace ModaStore.Application.Features.Identity.User.Queries.Handlers;

public class GetUserReviewsQueryHandler : IRequestHandler<GetUserReviewsQuery, List<ReviewDto>>
{
    private readonly IReviewService _reviewService;
    private readonly ICurrentUserService _currentUserService;
    private readonly UserManager<AppUser> _userManager;
    
    public GetUserReviewsQueryHandler(IReviewService reviewService, ICurrentUserService currentUserService, UserManager<AppUser> userManager)
    {
        _reviewService = reviewService;
        _currentUserService = currentUserService;
        _userManager = userManager;
    }
    
    public async Task<List<ReviewDto>> Handle(GetUserReviewsQuery request, CancellationToken cancellationToken)
    {
        var user = await _userManager.FindByEmaiWithAdressAsync(_currentUserService.User);
        
        var currentUserId = user.Id;
        
        var reviews = _reviewService.GetCurrentUserReviews(currentUserId);

        return await reviews.ToDtoList();
    }
}