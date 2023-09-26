using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Text.RegularExpressions;

namespace LibraryBook
{
    public class ErrorHandler
    {
        public bool TryParseInt(string input, out int result)
        {
            return int.TryParse(input, out result);
        }

        public void HandleInvalidInput()
        {
            Console.WriteLine("\nInput tidak valid. Harap masukkan input yang benar.");
        }

        public void HandleBookNotFound()
        {
            Console.WriteLine("\nBuku tidak ditemukan, Coba Lagi !");
        }

        public void HandleSearchNotFound()
        {
            Console.WriteLine("\nTidak ada book yang cocok dengan kata kunci yang diberikan !");
        }

        public bool HandleBookError(string title, string author, int publicationYear)
        {
            if (string.IsNullOrWhiteSpace(title) || string.IsNullOrWhiteSpace(author) || publicationYear == 0)
            {
                Console.WriteLine("\nInput tidak valid. Pastikan semua kolom diisi!");
                return false; // Jika input tidak valid, keluar dari metode.
            }
            if (ContainsDigits(author))
            {
                Console.WriteLine("\nJudul dan penulis tidak boleh mengandung angka !\n");
                return false; // Input mengandung angka, kembalikan false.
            }
            return true;
        }

        private bool ContainsDigits(string input)
        {
            // Menggunakan regex untuk mencari angka dalam string
            return Regex.IsMatch(input, @"\d");
        }
    }
}
