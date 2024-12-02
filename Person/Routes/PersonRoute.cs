using Microsoft.AspNetCore.Routing;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.FileSystemGlobbing.Internal.Patterns;
using Person.Data;
using Person.models;



namespace Person.Routes;
public static class PersonRoute
{
    public static void PersonRoutes(this WebApplication app)
    {
        var route = app.MapGroup(prefix: "person");

        route.MapPost(pattern: "",

          async (PersonRequest req, PersonContext context) =>
          {

              var person = new PersonModels(req.name);
              await context.AddAsync(person);
              await context.SaveChangesAsync();
          });

        route.MapGet("", async (PersonContext context) =>


        {

            var people = await context.People.ToListAsync();



            return Results.Ok(people);

        });
        route.MapPut(pattern: "{id:guid}",
            async (Guid id, PersonRequest req, PersonContext context) =>

         {
             var person = await context.People.FirstOrDefaultAsync(p => p.Id == id);


             if (person == null)

                 return Results.NotFound();


             person.ChangeName(req.name);
             await context.SaveChangesAsync();
             return Results.Ok(person);

         });
        route.MapDelete(pattern: "{id:guid}",
        async (Guid id, PersonContext context) =>
        {
            var person = await context.People.FirstOrDefaultAsync(p => p.Id == id);

            if (person == null)
                return Results.NotFound();


            
            person.SetInactive("");
            await context.SaveChangesAsync();
            return Results.Ok(person);

        });


    }
}

