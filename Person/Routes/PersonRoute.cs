using Microsoft.AspNetCore.Routing;
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


    }
}

