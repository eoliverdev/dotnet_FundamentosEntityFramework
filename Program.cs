using Blog.Data;
using Blog.Models;
using Microsoft.EntityFrameworkCore;


namespace Blog
{
    class Program
    {
        static void Main(string[] args)
        {
            using var context = new BlogDataContext();

            //CREATE USER
            // context.Users.Add(new User
            // {
            //     Bio = "9x Microsoft MVP",
            //     Email = "andre@balto.io",
            //     Image = "https://balta.io",
            //     Name = "André Baltieri",
            //     PasswordHash = "1234",
            //     Slug = "andre-baltieri"
            // });
            // context.SaveChanges();

            var user = context.Users.FirstOrDefault();
            var post = new Post
            {
                Author = user,
                Body = "Meu artigo",
                Category = new Category
                {
                    Name = "Backend",
                    Slug = "backend"
                },
                CreateDate = System.DateTime.Now,
                Slug = "meu-artigo",
                Summary = "Neste artigo vamos conferir ...",
                Title = "Meu artigo"
            };
            context.Posts.Add(post);
            context.SaveChanges();
        }
    }
}