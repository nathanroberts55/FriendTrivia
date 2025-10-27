using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Security.Claims;
using System.Security.Cryptography.Pkcs;
using Humanizer;

namespace FriendTrivia.Models;

public class User
{
    public int Id { get; set; }
    public DateTime CreatedOn { get; set; } = DateTime.UtcNow;
    public DateTime ModifiedOn { get; set; } = DateTime.UtcNow;

    [Required]
    [MinLength(3)]
    [MaxLength(50)]
    public string Username { get; set; } = null!;

    [Required]
    public string PasswordHash { get; set; } = null!;

    public int Streak { get; set; } = 0;
    public int QuestionsCreated { get; set; } = 0;
    public DateTime? LastAnswerDate { get; set; } = null;

    // Navigation properties
    public ICollection<Question> CreatedQuestions { get; set; } = new List<Question>();
    public ICollection<UserAnswer> Answers { get; set; } = new List<UserAnswer>();

    public ClaimsPrincipal ToClaimsPrincipal() => new(
        new ClaimsIdentity(new Claim[]
        {
            new (ClaimTypes.Name, Username),
            new (ClaimTypes.Hash, PasswordHash),
            new (nameof(Streak), Streak.ToString()),
            new (nameof(QuestionsCreated), QuestionsCreated.ToString()),
            new (nameof(LastAnswerDate), LastAnswerDate?.ToString() ?? string.Empty),
        }, "FriendTrivia"
    ));

    public static User FromClaimsPrincipal(ClaimsPrincipal principal) => new()
    {
        Username = principal.FindFirstValue(ClaimTypes.Name),
        PasswordHash = principal.FindFirstValue(ClaimTypes.Hash),
        Streak = int.Parse(principal.FindFirstValue(nameof(Streak))),
        QuestionsCreated = int.Parse(principal.FindFirstValue(nameof(QuestionsCreated))),
        // LastAnswerDate = DateTime.Parse(principal.FindFirstValue(nameof(LastAnswerDate)) ?? DateTime.UtcNow.ToString())
    };
}