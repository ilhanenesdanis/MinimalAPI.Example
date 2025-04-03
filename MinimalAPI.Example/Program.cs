using Microsoft.OpenApi.Models;
using MinimalAPI.Example.Models;
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
app.MapGet("/books/{id:guid}", (Guid id, IBookService bookService) =>
{
    var result = bookService.GetBook(id);
    return result is not null ? Results.Ok(result) : Results.NotFound();
}).WithName("GetBooksById");

app.MapPost("/books", (Book book, IBookService bookService) =>
{
    var result = bookService.CreateBook(book);

    return result ? Results.Created($"/books/{book.id}", book) : Results.BadRequest();

}).WithName("CreateBook");


app.Run();
