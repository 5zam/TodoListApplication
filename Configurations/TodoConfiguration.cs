using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using ToDoListApplication.Models;

namespace ToDoListApplication.Configurations
{
    public class TodoConfiguration : IEntityTypeConfiguration<Todo>
    {
        void IEntityTypeConfiguration<Todo>.Configure(EntityTypeBuilder<Todo> builder)
        {
            //throw new NotImplementedException();
            builder.ToTable("Todos");
            builder.HasKey(t => t.Id);
        }
    }
}
