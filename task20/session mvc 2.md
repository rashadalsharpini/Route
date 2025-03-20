### Routing
The process of mapping incoming HTTP requests to specific controller actions or endpoints
- Conventional Routing
-  Attribute Routing
`http://baseUrl/segment/{segment}/x{segment}`
`---------------static---variable - mixed`

```cs
app.MapGet("/Hamda", () => "Hello World!");
```
```cs
app.MapGet("/{name}", async context =>  
{  
    await context.Response.WriteAsync($"Hello {context.GetRouteValue("name")}!");  
});
```
```cs
app.MapGet("/X{name}", async context =>  
{  
    await context.Response.WriteAsync($"Hello {context.GetRouteValue("name")}!");  
});
```
```cs
app.MapControllerRoute(  
    name: "default",  
    pattern: "{controller=Home}/{action=Index}/{id?}"  
    );
    // the id is the default value
```
```cs
app.MapControllerRoute(  
    name: "default",  
    pattern: "{controller=Movies}/{action=Index}/{id:regex(^\\d{{2}}$)?}"  
    // defaults: new { Controller= "Movies", action = "Index" },  
    // constraints: new{Id = @"\d{2}"}    );

// http://localhost:5172/movies/getmovies/12?name=rashad  
// http://localhost:5172/movies/getmovies?id=12&name=rashad
```
### route constraints
![[Pasted image 20250318043315.png]]
### actions
Is a method must meet certain requirements
- The method must be public.
- The method cannot be a static method.
- The method cannot be an extension method.
- The method cannot be a constructor, getter, or setter.
- The method cannot have open generic types.
- The method is not a method of the controller base class.
- The method cannot contain ref or out parameters.

### Types of action results:

- ViewResult - Represents HTML and markup.
- EmptyResult - Represents no result.
- RedirectResult - Represents a redirection to a new URL.
- JsonResult - Represents a JavaScript Object Notation result that can be used in an ATAX application.
- JavaScriptResult - Represents a JavaScript script.
- ContentResult - Represents a text result.
- FileContentResult - Represents a downloadable file (with the binary content).
- FilePathResult - Represents a downloadable file (with a path).
- FileStreamResult - Represents a downloadable file (with a file stream)
```cs
using Microsoft.AspNetCore.Mvc;  
  
namespace WebApplication1.Controllers;  
  
public class MoviesController : Controller  
{  
    public string Index()  
    {        return "welcome MTF from movies index";  
    }  
    // http://localhost:5172/movies/getmovies/12?name=rashad  
    // http://localhost:5172/movies/getmovies?id=12&name=rashad    
    // [HttpGet]    
    // public string getMovies(int? id, string name)    
    // {    
    //     if (id == null)   
     //         return "id is null";    
     //     return $"WTF {id} {name}";    
     // }    
     [HttpGet]  
    public IActionResult getMovies(int? id, string name)  
    {        
	    // ContentResult result = new ContentResult();  
        // result.Content = $"Movie With Name = {name} </br> And Id = {id}";        
        // result.ContentType = "text/html";        
        // result.StatusCode = 700;        
        // return result;        
        if (id == null)  
            return Content("id is null");  
        else if (id == 0)  
            return BadRequest();  
        else if (id < 10)  
            return NotFound();  
        return Content($"movies {id} {name}", "text/plain");  
    }  
    public IActionResult testRedirectionAction()  
    {        
	    return RedirectToAction("getMovies", "Movies", new { id = 10, name = "test" });  
    }
}
```
### model binding
Is the Process of automatically mapping incoming HTTP request data to action method parameters or model properties

### value providers [in order]
1. form
2. route data
3. query string
4. request body
5. request header -> doesn't work for complex data

### views
View handles the app's data presentation and user interaction. A view is an
HTML template with embedded Razor markup
- to add a controller
`dotnet aspnet-codegenerator controller -name HomeController -outDir Controllers`
- to add a controller with a view
`dotnet aspnet-codegenerator controller -name HomeController -m YourModel -dc YourDbContext --relativeFolderPath Controllers --useDefaultLayout`



### tag helpers
A powerful feature that allows you to add server-side logic to your HTML in a clean, HTML-like syntax.
- HTML tags — When content is static and doesn't need server-side logic
- HTML helpers — When you need dynamic routing, forms, or model binding but are in ASP.NET Framework MVC projects.
- Tag helpers — Recommended for modern ASP.NET Core projects