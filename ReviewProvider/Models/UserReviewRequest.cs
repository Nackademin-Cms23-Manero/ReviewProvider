namespace ReviewProvider.Models;

public class UserReviewRequest
{
    public string Email { get; set; } = null!;
    public string ProductId { get; set; } = null!;
    public int StarRating { get; set; }
    public string? Comment { get; set; }
}
