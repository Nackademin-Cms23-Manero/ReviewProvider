using ReviewProvider.Data.Entities;
using ReviewProvider.Models;

namespace ReviewProvider.Factories;

public class RatingFactory
{
    public static RatingEntity Create(UserReviewRequest request)
    {
        return new RatingEntity
        {
            StarRating = request.StarRating,
        };
    }
}
