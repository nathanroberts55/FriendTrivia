using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Security.Cryptography.Pkcs;
using Humanizer;

namespace FriendTrivia.Models;

public class Question
{
    public int Id { get; set; }
    public DateTime CreatedOn { get; set; } = DateTime.UtcNow;
    public DateTime ModifiedOn { get; set; } = DateTime.UtcNow;
    public required string QuestionText { get; set; } = "";
    public required string Answer { get; set; } = "";
    public User Author { get; set; } = null!;

    // Foreign key for Author
    public int AuthorId { get; set; }

    // Navigation properties
    public ICollection<UserAnswer> Answers { get; set; } = new List<UserAnswer>();

}