namespace ReviewProvider.Data.Entities;

public class UserReviewEntity
{
    public string Email { get; set; } = null!;
    public string ProductId { get; set; } = null!;
    public int RatingId { get; set; }
    public RatingEntity Rating { get; set; } = null!;
    public int? ReviewId { get; set; }
    public ReviewEntity? Review { get; set; }
}
