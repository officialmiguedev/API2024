using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AcademyOnline.Entities
{
    public class Curso
    {
        [Key]
        public int CursoId { get; set; }
        [Required]
        [MaxLength(100)]
        public string Nombre { get; set; }
        [Required]
        public DateTime Fecha { get; set; }
        //public decimal Precio { get; set; }

        //[Required]
        //public string Descripcion { get; set; }

       //[Required]
        public int InstructorId { get; set; }
        [Required]
        public int CategoriaId { get; set; }

        public string ImagePath { get; set; }
    }
}
