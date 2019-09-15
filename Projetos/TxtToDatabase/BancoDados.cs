using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ImportTxtToDB {
    public class BancoDados {
        
        public static List<Book> SearchBooks()
        {
         
            string filePath = "D:/Jander Silva/Documents/VS Projects/ImportTxtToDB/info.txt";

            List<Book> books = new List<Book>();
            string[] lines = { };

            try
            {
                lines = File.ReadAllLines(filePath);
            }
            catch (Exception e)
            {
                Console.WriteLine("Erro:" + e.Message);
            }

            foreach (var line in lines)
            {
                string[] entries = line.Split(',');

                Book newBook = new Book();

                newBook.Titulo = entries[0];
                newBook.Ano = Convert.ToInt32(entries[1]);
                newBook.Isbn = entries[2];
                newBook.AutorID = Convert.ToInt32(entries[3]);
                newBook.EditoraID = Convert.ToInt32(entries[4]);
                newBook.CategoriaID = Convert.ToInt32(entries[5]);

                books.Add(newBook);
            }

            //foreach(var book in books) {
            //    Console.WriteLine($"Titulo: {book.Titulo}; Ano: {book.Ano}; ISBN: {book.Isbn}; AutorID: {book.AutorID}; EditoraID: {book.EditoraID}; CategoriaID: {book.CategoriaID}");
            //}

            return books;
        }

        public static void AddAutor(string nome, string email, SqlConnection con)
        {
            IDbCommand insert = new SqlCommand("INSERT INTO Autor values ('" + nome + "','" + email + "');", con);
            insert.ExecuteNonQuery();
        }

        public static void AddCategoria(string descricao, SqlConnection con)
        {
            IDbCommand insert
                = new SqlCommand("INSERT INTO Categoria values ('" + descricao + "');", con);
            insert.ExecuteNonQuery();
        }

        public static void AddEditora(string nome, SqlConnection con)
        {
            IDbCommand insert
                = new SqlCommand("INSERT INTO Editora values ('" + nome + "');", con);
            insert.ExecuteNonQuery();
        }

        public static void AddLivro(string titulo, int ano, string isbn, int id_autor, int id_editora, int id_categoria, SqlConnection con)
        {
            IDbCommand insert
                = new SqlCommand("INSERT INTO Livro (titulo, ano, isbn, autorid, editoraid, categoriaid) values ('" + titulo + "'," + ano + ",'" + isbn + "'," + id_autor + "," + id_editora + ", " + id_categoria + ");", con);
            insert.ExecuteNonQuery();
        }
    }
}
