namespace FriendTrivia.Models;

public class UserAnswer
{
    public int Id { get; set; }
    public int UserId { get; set; }
    public int QuestionId { get; set; }
    public string? SubmittedAnswer { get; set; }
    public bool IsCorrect { get; set; }
    public DateTime AnsweredOn { get; set; } = DateTime.UtcNow;

    // Navigation properties
    public required User User { get; set; }
    public required Question Question { get; set; }
}