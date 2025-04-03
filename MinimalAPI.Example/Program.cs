using Microsoft.OpenApi.Models;
using MinimalAPI.Example.Services.Abstract;
using MinimalAPI.Example.Services.Concrete;

var builder = WebApplication.CreateBuilder(args);


builder.Services.AddOpenApi();

builder.Services.AddSingleton<IBookService, BookService>();


var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.MapOpenApi();
}

app.UseHttpsRedirection();

app.MapGet("/books", (IBookService bookService) => TypedResults.Ok(bookService.GetBooks()))
    .WithName("GetBooks")
    .WithOpenApi(x => new OpenApiOperation(x)
    {
        Summary = "Get All Books",
        Description = "Returns get all books",
        Tags = new List<OpenApiTag> { new OpenApiTag() { Name = "Example" } }
    });


app.Run();
