using ModaStore.Domain.Entities.Catalog;

namespace ModaStore.Domain.Interfaces.Customer;

public interface IReviewService
{
    IQueryable<ProductReview> GetAllAsync();
    Task<List<ProductReview>> GetCurrentUserReviews(string userId);
    Task<ProductReview> AddReviewAsync(ProductReview review);
}
