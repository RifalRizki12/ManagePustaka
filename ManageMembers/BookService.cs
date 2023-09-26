using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ManagePustaka;
public class BookService
{
    private List<Book> books;

    public BookService()
    {
        books = new List<Book>();
    }

    public void AddBook(Book book)
    {
        book.Id = books.Count + 1;
        books.Add(book);
        Console.WriteLine("Buku berhasil ditambahkan.");
    }

    public void EditBook(int id, Book updatedBook)
    {
        var existingBook = books.Find(b => b.Id == id);
        if (existingBook != null)
        {
            existingBook.Title = updatedBook.Title;
            existingBook.Author = updatedBook.Author;
            existingBook.ISBN = updatedBook.ISBN;
            Console.WriteLine("Buku berhasil diubah.");
        }
        else
        {
            Console.WriteLine("Buku tidak ditemukan.");
        }
    }

    public void DeleteBook(int id)
    {
        var existingBook = books.Find(b => b.Id == id);
        if (existingBook != null)
        {
            books.Remove(existingBook);
            Console.WriteLine("Buku berhasil dihapus.");
        }
        else
        {
            Console.WriteLine("Buku tidak ditemukan.");
        }
    }

    public List<Book> GetAllBooks()
    {
        return books;
    }

    public Book GetBookById(int bookId)
    {
        return books.FirstOrDefault(book => book.Id == bookId);
    }
}
