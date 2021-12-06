using Blog.Data;

using (var context = new BlogDataContext())
{
    

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
