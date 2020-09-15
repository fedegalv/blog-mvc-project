using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace blog_data
{
    public class Post
    {
        [Key]
        [Column("id")]
        public int id;

        [Column("title")]
        [Required]
        [RegularExpression(@"^[a-zA-Z ]+$", ErrorMessage = "Debe usar letras unicamente")]
        public string titulo;

        [Column("content")]
        [Required]
        [RegularExpression(@"^[a-zA-Z ]+$", ErrorMessage = "Debe usar letras unicamente")]
        public string contenido;

        public string imagen;

        [Column("category")]
        [Required]
        [RegularExpression(@"^[a-zA-Z ]+$", ErrorMessage = "Debe usar letras unicamente")]
        public string categoria;
        
        [Column("date")]
        [Required]
        [DataType(DataType.DateTime)]
        public DateTime fecha;

    }
}
