using Blog.Models;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Blog.Data.Mappings 
{
    public class PostMap : IEntityTypeConfiguration<Post>
    {
        public void Configure(EntityTypeBuilder<Post> builder)
        {
            //Table
            builder.ToTable("Post");
            //Primary Key
            builder.HasKey(x=>x.Id);
            //Identity
            builder
                .Property(x=>x.Id)
                .ValueGeneratedOnAdd()
                .UseIdentityColumn(); // Primary Key IDENTITY(1,1)

            //Properties
            builder
                .Property(x=>x.LastUpdateDate)
                .IsRequired()
                .HasColumnName("LastUpdateDate")
                .HasColumnType("SMALLDATETIME")
                .HasDefaultValueSql("GETDATE()"); //NOT NULL
                //.HasDefaultValue(DateTime.Now.ToUniversalTime()); NO .NETx
            
            //Indexes
            builder
                .HasIndex(x=>x.Slug, "IX_Post_Slug")
                .IsUnique();
            
            //Relationship (one to many)
            builder
                .HasOne(x=>x.Author)
                .WithMany(x=>x.Posts)
                .HasConstraintName("FK_Post_Author")
                .OnDelete(DeleteBehavior.Cascade);
            
            builder
                .HasOne(x=>x.Category)
                .WithMany(x=>x.Posts)
                .HasConstraintName("FK_Post_Category")
                .OnDelete(DeleteBehavior.Cascade);
            
            //Relationship (many to many)
            builder
                .HasMany(x=>x.Tags)
                .WithMany(x=>x.Posts)
                .UsingEntity<Dictionary<string, object>>(
                    "PostTag",
                    post => post
                        .HasOne<Tag>()
                        .WithMany()
                        .HasForeignKey("PostId")
                        .HasConstraintName("FK_PostTag_PostId")
                        .OnDelete(DeleteBehavior.Cascade),
                    tag => tag
                        .HasOne<Post>()
                        .WithMany()
                        .HasForeignKey("TagId")
                        .HasConstraintName("FK_PostTag_TagId")
                        .OnDelete(DeleteBehavior.Cascade));
        }
    }
}