using Microsoft.EntityFrameworkCore;
using ModaStore.Domain.Entities.Catalog;
using ModaStore.Domain.Interfaces.Customer;
using ModaStore.Domain.Interfaces.Data;

namespace ModaStore.Infrastructure.Services.Customer;

public class ReviewService : IReviewService
{
    private readonly IRepository<ProductReview> _reviewRepository;
    
    public ReviewService(IRepository<ProductReview> reviewRepository)
    {
        _reviewRepository = reviewRepository;
    }
    
    public IQueryable<ProductReview> GetAllAsync()
    {
        return _reviewRepository.GetAllQueryAsync();
    }
    
    public Task<List<ProductReview>> GetCurrentUserReviews(string userId)
    {
        return GetAllAsync()
            .Where(x => x.UserId == userId)
            .ToListAsync();
    }
    
    public async Task<ProductReview> AddReviewAsync(ProductReview review)
    {
        return await _reviewRepository.InsertAsync(review);
    }
}