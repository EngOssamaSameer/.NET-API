using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace APIedu.Models
{
    public class Lesson
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [StringLength(150)]
        public string Title { get; set; }

        [Required]
        [ForeignKey(nameof(Course.Id))]
        public int Course_Id { get; set; }

        [Required]
        [MaxLength(500)]
        public string Contant { get; set;}




    }
}
