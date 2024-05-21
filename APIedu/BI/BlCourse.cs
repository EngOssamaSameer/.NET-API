using System.ComponentModel.DataAnnotations;

namespace APIedu.BI
{
    public class BlCourse
    {
        [Required]
        [MaxLength(100)]
        public string Title { get; set; }

        [Required]
        [MaxLength(300)]
        public string Description { get; set; }

        [Required]
        [MaxLength(100)]
        public string Code { get; set; }
    }
}
