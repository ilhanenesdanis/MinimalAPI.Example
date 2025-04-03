using MinimalAPI.Example.Models;

namespace MinimalAPI.Example.Services.Abstract
{
    public interface IBookService
    {
        List<Book> GetBooks();
        Book GetBook(Guid id);
    }
}
