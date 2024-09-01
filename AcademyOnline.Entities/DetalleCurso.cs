using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AcademyOnline.Entities
{
    public class DetalleCurso
    {
        [Key]
        public int ID { get; set; }
        [Required]
        [MaxLength(1000)]
        public string Descripcion { get; set; }
        [Required]
        public int CursoId { get; set; }

    }
}
