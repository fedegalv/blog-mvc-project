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
        public int Id;

        [Column("title")]
        [Required]
        [RegularExpression(@"^[a-zA-Z ]+$", ErrorMessage = "Debe usar letras unicamente")]
        public string Titulo { get; set; }

        [Column("content")]
        [Required]
        [RegularExpression(@"^[a-zA-Z ]+$", ErrorMessage = "Debe usar letras unicamente")]
        public string Contenido { get; set; }

        public string Imagen { get; set; }

        [Column("category")]
        [Required]
        [RegularExpression(@"^[a-zA-Z ]+$", ErrorMessage = "Debe usar letras unicamente")]
        public string Categoria { get; set; }

        [Column("date")]
        [Required]
        [DataType(DataType.DateTime)]
        public DateTime Fecha { get; set; }

    }
}
