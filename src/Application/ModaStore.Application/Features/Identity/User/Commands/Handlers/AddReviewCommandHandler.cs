using MediatR;
using Microsoft.AspNetCore.Identity;
using ModaStore.Application.DTOs.Catalog;
using ModaStore.Application.Extensions;
using ModaStore.Application.Extensions.Mapper;
using ModaStore.Application.Features.Identity.User.Commands.Models;
using ModaStore.Domain.Entities.Identity;
using ModaStore.Domain.Interfaces.Customer;
using ModaStore.Domain.Interfaces.Identity.Authentication;

namespace ModaStore.Application.Features.Identity.User.Commands.Handlers;

public class AddReviewCommandHandler : IRequestHandler<AddReviewCommand, ReviewDto>
{
    private readonly UserManager<AppUser> _userManager;
    private readonly ICurrentUserService _currentUserService;
    private readonly IReviewService _reviewService;
    
    public AddReviewCommandHandler(UserManager<AppUser> userManager, ICurrentUserService currentUserService, IReviewService reviewService)
    {
        _userManager = userManager;
        _currentUserService = currentUserService;
        _reviewService = reviewService;
    }
        
    public async Task<ReviewDto> Handle(AddReviewCommand request, CancellationToken cancellationToken)
    {
        var userId = _userManager.FindByEmaiWithAdressAsync(_currentUserService.User).Result.Id;
        
        var review = request.ReviewDto.ToEntity();
        
        review.UserId = userId;
        
        var createdReview = await _reviewService.AddReviewAsync(review);
        
        return createdReview.ToDto();
    }
}