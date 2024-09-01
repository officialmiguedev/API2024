using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AcademyOnline.Entities
{
    public class Categoria
    {
        [Key]
        public int CategoriaId { get; set; }
        [Required]
        [MaxLength(100)]
        public string Nombre { get; set; }

        public string ImagePath { get; set; }
    }
}
