using System;
using System.Collections.Generic;

class Program
{
    /*
	*Nama Perogram: Aplikasi Perpustakaan
	*Penulis : Gusli Yanza
	*Tahun : 2024
	*Deskipsi: program ini ditujukan untuk UTS universi dinamika bangsa (s1)
	*/
	
    static List<Book> books = new List<Book>
    {
        new Book("001", "Pengantar Teknologi Informasi", 2),
        new Book("002", "Pemogram Mobile", 2)
    };

    static void Main()
    {
        DisplayBookList();

        while (true)
        {
            Console.WriteLine("\n===== Aplikasi Perpustakaan =====");
            Console.WriteLine("1. Pinjam Buku");
            Console.WriteLine("2. Keluar");

            Console.Write("Pilihan Anda: ");
            string choice = Console.ReadLine();

            switch (choice)
            {
                case "1":
                    BorrowBook();
                    break;
                case "2":
                    Environment.Exit(0);
                    break;
                default:
                    Console.WriteLine("Pilihan tidak valid. Silakan coba lagi.");
                    break;
            }
        }
    }

    static void DisplayBookList()
    {
        Console.WriteLine("===== Daftar Buku =====");
        Console.WriteLine("Kode  | Judul          | Jumlah");
        Console.WriteLine("--------------------------------");

        foreach (var book in books)
        {
            Console.WriteLine($"{book.Code} | {book.Title} | {book.Quantity}");
        }
    }

    static void BorrowBook()
    {
        Console.Write("Masukkan kode buku yang akan dipinjam: ");
        string codeToBorrow = Console.ReadLine();

        Book selectedBook = books.Find(book => book.Code == codeToBorrow);

        if (selectedBook != null && selectedBook.Quantity > 0)
        {
            selectedBook.Quantity--;
            Console.WriteLine($"Anda berhasil meminjam buku: {selectedBook.Title}");
            Console.WriteLine($"Sisa buku {selectedBook.Title}: {selectedBook.Quantity}");
        }
        else if (selectedBook != null && selectedBook.Quantity == 0)
        {
            Console.WriteLine("Buku tidak tersedia.");
        }
        else
        {
            Console.WriteLine("Kode buku tidak valid.");
        }
    }
}

class Book
{
    public string Code { get; }
    public string Title { get; }
    public int Quantity { get; set; }

    public Book(string code, string title, int quantity)
    {
        Code = code;
        Title = title;
        Quantity = quantity;
    }
}
