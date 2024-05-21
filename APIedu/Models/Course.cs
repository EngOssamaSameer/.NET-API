using System.ComponentModel.DataAnnotations;

namespace APIedu.Models
{
    public class Course
    {
        public Course()
        {
            TbLesson = new HashSet<Lesson>();
            TbStudentInfo = new HashSet<StudentInfo>();
        }
        [Key]
        public int Id { get; set; }

        [Required]
        [StringLength(150)]
        public string Title { get; set; }

        [Required]
        [MaxLength(300)]
        public string Description { get; set; }

        [Required]
        public  string Code { get; set; }

        public ICollection<StudentInfo> TbStudentInfo { get; set; }

        public ICollection<Lesson> TbLesson {  get; set; }

    }
}
