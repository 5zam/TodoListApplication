using System.Reflection.Emit;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using ToDoListApplication.Models;

namespace ToDoListApplication.Configurations
{
    public class CategoryConfigurtion : IEntityTypeConfiguration<Category>
    {
        void IEntityTypeConfiguration<Category>.Configure(EntityTypeBuilder<Category> builder)
        {
            //throw new NotImplementedException();
            builder.ToTable("Categories");
            builder.HasKey(c => c.Id);

            builder.HasMany(c => c.TodoList)
              .WithOne(t => t.Category)
              .HasForeignKey(t => t.CategoryId)
              .OnDelete(DeleteBehavior.Cascade);
        }
    }
}
