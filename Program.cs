using Blog.Data;
using Blog.Models;
using Microsoft.EntityFrameworkCore;

    using var context = new BlogDataContext();

    //CREATE
    context.Users.Add(new User
    {
        Bio = "9x Microsoft MVP",
        Email = "andre@balto.io",
        Image = "https://balta.io",
        Name = "André Baltieri",
        PasswordHash = "1234",
        Slug = "andre-baltieri"
    });
    context.SaveChanges();
 


