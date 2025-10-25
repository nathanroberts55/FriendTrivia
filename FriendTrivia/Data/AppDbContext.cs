using Microsoft.EntityFrameworkCore;
using FriendTrivia.Models;

namespace FriendTrivia.Data;

public class AppDbContext : DbContext
{
    public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }

    public DbSet<Question> Questions { get; set; } = null!;
    public DbSet<User> Users { get; set; } = null!;
    public DbSet<UserAnswer> Answers { get; set; } = null!;

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);

        // Configure User entity
        modelBuilder.Entity<User>()
            .HasIndex(u => u.Username)
            .IsUnique();

        // Configure Question entity
        modelBuilder.Entity<Question>()
            .HasOne(q => q.Author)
            .WithMany(u => u.CreatedQuestions)
            .HasForeignKey(q => q.AuthorId)
            .OnDelete(DeleteBehavior.Cascade);

        // Configure UserAnswer entity
        modelBuilder.Entity<UserAnswer>()
            .HasOne(ua => ua.User)
            .WithMany(u => u.Answers)
            .HasForeignKey(ua => ua.UserId)
            .OnDelete(DeleteBehavior.Cascade);

        modelBuilder.Entity<UserAnswer>()
            .HasOne(ua => ua.Question)
            .WithMany(q => q.Answers)
            .HasForeignKey(ua => ua.QuestionId)
            .OnDelete(DeleteBehavior.Cascade);
    }
}