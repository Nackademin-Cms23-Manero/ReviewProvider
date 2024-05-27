using ReviewProvider.Data.Entities;
using ReviewProvider.Models;

namespace ReviewProvider.Factories;

public class UserReviewFactory
{
    public static UserReviewEntity Create(UserReviewRequest request, int ratingId)
    {
        return new UserReviewEntity
        {
            Email = request.Email,
            ProductId = request.ProductId,
            RatingId = ratingId,
            Comment = request.Comment,
        };
    }
}
