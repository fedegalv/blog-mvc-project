using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;


namespace blog_data
{
    public class Post
    {
        [Key]
        [Column("id")]
        public int Id { get; set; }

        [Column("title")]
        [Required]
        [RegularExpression(@"^[a-zA-Z ]+$", ErrorMessage = "Debe usar letras unicamente")]
        public string Titulo { get; set; }

        [Column("content")]
        [Required]
        //[RegularExpression(@"^[a-zA-Z ]+$", ErrorMessage = "Debe usar letras unicamente")]
        public string Contenido { get; set; }

        [Column("img")]
        
        [Url]
        public string Imagen { get; set; }

        [Column("category")]
        
        [RegularExpression(@"^[a-zA-Z ]+$", ErrorMessage = "Debe usar letras unicamente")]
        public string Categoria { get; set; }

        [Column("date")]
        [DataType(DataType.DateTime)]
        public DateTime Fecha { get; set; }


    }
}
