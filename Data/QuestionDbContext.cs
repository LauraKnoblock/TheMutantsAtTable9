using Microsoft.EntityFrameworkCore;
using TheMutantsAtTable9.Models;

namespace TheMutantsAtTable9.Data
{
    public class QuestionDbContext : DbContext
    {
        public DbSet<Question> Questions { get; set; }
        public QuestionDbContext(DbContextOptions<QuestionDbContext> options) : base(options)
        {
        }
    }
}
