using Blog.Data;
using Blog.Models;

using (var context = new BlogDataContext())
{
    //context.Users.Add(new User
    //{
    //    Bio = "My Bio",
    //    Name = "Thiago Maturana",
    //    Email = "thiago@test.com",
    //    Image = "https://test.com",
    //    PasswordHash = "1234",
    //    Slug = "thiago-maturana"
    //});

    //context.SaveChanges();

    var user = context.Users.FirstOrDefault();
    var tags = context.Tags.ToList();
    var category = context.Categories.FirstOrDefault();

    var post = new Post
    {
        Author = user,
        Body = "My article 2",
        Category = category,
        Tags = tags,
        CreateDate = DateTime.UtcNow,
        Slug = "my-article-2",
        Summary = "On this article we'llbe doing this and that...",
        Title = "My Article 2"
    };

    context.Posts.Add(post);
    context.SaveChanges();

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
