using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ImportTxtToDB {
   public class Book {
        public string Titulo { get; set; }
        public int Ano { get; set; }
        public string Isbn { get; set; }
        public int AutorID { get; set; }
        public int EditoraID { get; set; }
        public int CategoriaID { get; set; }
    }
}
