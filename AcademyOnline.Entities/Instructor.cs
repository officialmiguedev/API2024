using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AcademyOnline.Entities
{
    public class Instructor
    {
        [Key]
        public int InstructorId { get; set; }
        [Required]
        [MaxLength(50)]
        public string Nombres { get; set; }
        [Required]
        [MaxLength(50)]
        public string Titulo { get; set; }
        [Required]
        [MaxLength(50)]
        public string SobreMi { get; set; }
        [Required]
        [MaxLength(50)]
        public string Youtube { get; set; }
        [Required]
        [MaxLength(50)]
        public string Linkedln { get; set; }
        [Required]
        [MaxLength(50)]
        public string Twitter { get; set; }

        public string ImagePath { get; set; }
    }
}
