using MinimalAPI.Example.Models;
using MinimalAPI.Example.Services.Abstract;

namespace MinimalAPI.Example.Services.Concrete;

public sealed class BookService : IBookService
{
    private List<Book> _books;
    public BookService()
    {
        _books = new List<Book>()
        {
            new Book(Guid.NewGuid(),"Kuyucaklı Yusuf","Sebahattin Ali"),
            new Book(Guid.NewGuid(),"Olağan Üstü Bir Gece","Stefan Zweıg"),
            new Book(Guid.NewGuid(),"Martin Eden","Jack London"),
        };
    }

    public bool CreateBook(Book book)
    {
        _books.Add(book);
        return true;
    }

    public Book GetBook(Guid id)
    {
        return _books.Find(x => x.id == id) ?? throw new Exception("Book not found");
    }

    public List<Book> GetBooks()
    {
        return _books;
    }
}
