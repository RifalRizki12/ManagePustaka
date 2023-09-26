using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.ConstrainedExecution;
using System.Text;
using System.Threading.Tasks;

namespace ManagePustaka
{
    public class LoanService
    {
        private List<Loan> loans;
        private BookService bookService;
        private int nextLoanId;

        public LoanService(BookService bookService)
        {
            loans = new List<Loan>();
            this.bookService = bookService;
            nextLoanId = 1;
        }

        public void BorrowBook(int memberId, int bookId)
        {
            // Cek apakah buku sudah dipinjam oleh anggota lain
            if (IsBookAvailable(bookId))
            {
                // Cek apakah anggota sudah meminjam buku ini sebelumnya
                if (!IsBookAlreadyBorrowed(memberId, bookId))
                {
                    Loan newLoan = new Loan
                    {
                        Id = nextLoanId,
                        MemberId = memberId,
                        BookId = bookId,
                        BorrowDate = DateTime.Now,
                        ReturnDate = DateTime.Now.AddDays(14) // Contoh: batas waktu pengembalian adalah 14 hari dari tanggal peminjaman
                    };
                    loans.Add(newLoan);
                    Console.WriteLine("Buku berhasil dipinjam.");

                    // Tingkatkan nilai nextLoanId agar sesuai dengan ID berikutnya
                    nextLoanId++;
                }
                else
                {
                    Console.WriteLine("Anggota sudah meminjam buku ini sebelumnya.");
                }
            }
            else
            {
                Console.WriteLine("Buku tidak tersedia.");
            }
        }

        public void ReturnBook(int memberId, int bookId)
        {
            // Cek apakah anggota memiliki peminjaman buku ini
            var loan = loans.FirstOrDefault(l => l.MemberId == memberId && l.BookId == bookId);
            if (loan != null)
            {
                // Hapus peminjaman buku dari daftar peminjaman
                loans.Remove(loan);
                Console.WriteLine("Buku berhasil dikembalikan.");
            }
            else
            {
                Console.WriteLine("Anggota tidak memiliki peminjaman buku ini.");
            }
        }

        public List<Loan> GetMemberLoans(int memberId)
        {
            return loans.FindAll(l => l.MemberId == memberId);
        }

        private bool IsBookAvailable(int bookId)
        {
            // Cek apakah buku dengan ID yang diminta tersedia dalam daftar buku
            var book = bookService.GetBookById(bookId);

            // Lakukan validasi tambahan apakah buku ditemukan atau tidak
            if (book != null)
            {
                // Buku ditemukan, maka kembalikan true
                return true;
            }
            else
            {
                // Buku tidak ditemukan, kembalikan false
                return false;
            }
        }

        private bool IsBookAlreadyBorrowed(int memberId, int bookId)
        {
            // Periksa apakah anggota sudah meminjam buku ini sebelumnya
            return loans.Any(l => l.MemberId == memberId && l.BookId == bookId);
        }

        public void ViewLoanStatus()
        {
            Console.Write("ID Anggota: ");
            if (int.TryParse(Console.ReadLine(), out int memberId))
            {
                List<Loan> memberLoans = GetMemberLoans(memberId);

                if (memberLoans.Count > 0)
                {
                    Console.WriteLine($"Status Peminjaman untuk Anggota dengan ID {memberId}:");
                    foreach (var loan in memberLoans)
                    {
                        Book book = bookService.GetBookById(loan.BookId);
                        Console.WriteLine($"Buku: {book.Title}, Pengarang: {book.Author}, Tanggal Peminjaman: {loan.BorrowDate}, Tanggal Pengembalian: {loan.ReturnDate}");
                    }
                }
                else
                {
                    Console.WriteLine("Anggota tidak memiliki peminjaman buku.");
                }
            }
            else
            {
                Console.WriteLine("ID Anggota tidak valid.");
            }
        }

        public void EditLoanStatus(int loanId, DateTime newReturnDate)
        {
            // Cari peminjaman berdasarkan ID peminjaman
            var loan = loans.FirstOrDefault(l => l.Id == loanId);

            if (loan != null)
            {
                // Ubah tanggal pengembalian
                loan.ReturnDate = newReturnDate;
                Console.WriteLine("Status peminjaman berhasil diubah.");
            }
            else
            {
                Console.WriteLine("Peminjaman tidak ditemukan.");
            }
        }

        public void DeleteLoan(int loanId)
        {
            // Cari peminjaman berdasarkan ID peminjaman
            var loan = loans.FirstOrDefault(l => l.Id == loanId);

            if (loan != null)
            {
                // Hapus peminjaman buku dari daftar peminjaman
                loans.Remove(loan);
                Console.WriteLine("Peminjaman berhasil dihapus.");
            }
            else
            {
                Console.WriteLine("Peminjaman tidak ditemukan.");
            }
        }

        public void ViewAllLoans()
        {
            Console.WriteLine("Daftar Seluruh Peminjaman:");

            foreach (var loan in loans)
            {
                Book book = bookService.GetBookById(loan.BookId);
                Console.WriteLine($"ID Peminjaman: {loan.Id}" +
                    $"\nAnggota: {loan.MemberId}" +
                    $"\nBuku: {book.Title}" +
                    $"\nPengarang: {book.Author}" +
                    $"\nTanggal Peminjaman: {loan.BorrowDate}" +
                    $"\nTanggal Pengembalian: {loan.ReturnDate}");
            }
        }
    }

}
