using APIedu.Models;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace APIedu.BI
{
    public class BlLesson
    {
        [Required]
        [StringLength(150)]
        public string Title { get; set; }

        [Required]
        [ForeignKey(nameof(Course.Id))]
        public int Course_Id { get; set; }

        [Required]
        [MaxLength(500)]
        public string Contant { get; set; }
    }
}
