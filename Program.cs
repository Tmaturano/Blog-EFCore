using Blog.Data;
using Blog.Models;
using Microsoft.EntityFrameworkCore;

using (var context = new BlogDataContext())
{
    //lazy loading:
    //var posts = context.Posts; //Tags will not be loaded here
    //foreach (var post in posts)
    //{
    //    foreach (var tag in post.Tags)
    //    {
    //        //EF will load the Tags by using Lazy Loading (only when needed, Tags will be loaded)
    //    }
    //}


    //eager loading (default):
    //The sample above will thrown an error if you want to use it, because Tags will be null 
    //var postsEager = context.Posts.Include(x => x.Tags).Select(x => new
    //{
    //    Id = x.Id,
    //    OtherName = x.Title
    //}); //will do an Inner Join with Tags


    //pagination:
    var users = GetUsers(context, 1, 25);
    users = GetUsers(context, 2, 25);
    users = GetUsers(context, 3, 25);

    //Create
    //var tag = new Tag
    //{
    //    Name = "ASP.NET",
    //    Slug = "aspnet"
    //};

    //context.Tags.Add(tag);
    //context.SaveChanges();


    //Update
    //metadata, EF will get the latest version from the database and compare with this changed version
    //EF is smart enought to update only what has been changed.
    //var tag = context.Tags.FirstOrDefault(x => x.Id == 1);
    //tag.Name = ".NET";
    //tag.Slug = "dotnet";

    //context.Update(tag);
    //context.SaveChanges();

    //Delete
    //var tag = context.Tags.FirstOrDefault(x => x.Id == 1);
    //context.Remove(tag);
    //context.SaveChanges();

    //if you are not going to Update or Remove, you can say to EF to not bring the metadata with .AsNoTracking() (Performance perspective)

    //var tags = context.Tags.AsNoTracking(); //not executed in database yet
    //if you want to execute in database right here, you can call .ToList()

    //foreach (var tag in tags) //executed in database
    //{
    //    Console.WriteLine(tag.Name);
    //}
}

//Pagination sample with EF
static List<User> GetUsers(BlogDataContext context, int pageNumber = 0, int pageSize = 25)
{
    var users = context
        .Users
        .AsNoTracking()
        .Skip((pageNumber - 1) * pageSize)
        .Take(pageSize)
        .ToList();

    return users;
}
