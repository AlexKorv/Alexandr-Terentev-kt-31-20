using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using terentevalexandrKt_31_20.Database.Helpers;
using terentevalexandrKt_31_20.Models;

namespace terentevalexandrKt_31_20.Database.Configurations
{
    public class ProfessorConfiguration : IEntityTypeConfiguration<Professor>
    {
        private const string TableName = "professor";

        public void Configure(EntityTypeBuilder<Professor> builder)
        {
            builder
                .HasKey(e => e.Id)
                .HasName($"pk_{TableName}_id");

            builder.Property(e => e.Id)
                .ValueGeneratedOnAdd();

            builder.Property(e => e.Id)
                .HasColumnName("id")
                .HasComment("Идентификатор преподавателя");

            builder.Property(e => e.FirstName)
                .IsRequired()
                .HasColumnName("firstname")
                .HasColumnType(ColumnType.String).HasMaxLength(100)
                .HasComment("Имя преподавателя");

            builder.Property(e => e.LastName)
                .IsRequired()
                .HasColumnName("lastname")
                .HasColumnType(ColumnType.String).HasMaxLength(100)
                .HasComment("Фамилия преподавателя");

            builder.Property(e => e.MiddleName)
                .IsRequired()
                .HasColumnName("middlename")
                .HasColumnType(ColumnType.String).HasMaxLength(100)
                .HasComment("Отчество преподавателя");

            builder.ToTable(TableName);
        }
    }
}
