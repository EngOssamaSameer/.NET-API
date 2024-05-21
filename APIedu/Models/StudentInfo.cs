using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace APIedu.Models
{
    public class StudentInfo
    {
        public StudentInfo()
        {
            TbCourses = new HashSet<Course>();
        }
        [Key]
        public int Id { get; set; }

        public int User_Id { get; set; }

        public ICollection<Course> TbCourses { get; set; }

    }
}
