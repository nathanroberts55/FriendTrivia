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
    public string Role { get; set; } = "User";

    public int Streak { get; set; } = 0;
    public int QuestionsCreated { get; set; } = 0;
    public DateTime? LastAnswerDate { get; set; } = null;

    // Navigation properties
    public ICollection<Question> CreatedQuestions { get; set; } = new List<Question>();
    public ICollection<UserAnswer> Answers { get; set; } = new List<UserAnswer>();

}