using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Data;
using System.Data.SqlClient;

namespace ImportTxtToDB {
    class Program {
        static void Main(string[] args) {

           var books = BancoDados.SearchBooks();

            IDbConnection con = new SqlConnection("Server=JANDER\\SQLEXPRESS; Database=Livraria; Trusted_Connection=True; ");
            con.Open();
            //Console.WriteLine(con.Database);
            try { 
                foreach(var book in books) {
                    BancoDados.AddLivro(book.Titulo, book.Ano, book.Isbn, book.AutorID, book.EditoraID, book.EditoraID, (SqlConnection)con);
                }
            } catch (SqlException e) {
                Console.WriteLine($"Erro: {e.Message}");
            } finally {
                con.Close();
            }

            //AddCategoria("Ficção",(SqlConnection)con);
            //AddEditora("Saraiva", (SqlConnection)con);
            //AddLivro(" ", 2000, "NULL", 1, 1, 1, (SqlConnection)con);

            //IDbCommand select = new SqlCommand("SELECT * FROM Editora;", (SqlConnection)con);
            //select.ExecuteNonQuery();
            

            Console.ReadLine();
        }
    }
}
