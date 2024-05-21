using System.ComponentModel.DataAnnotations.Schema;

namespace APIedu.Models
{
    public class CourseStudentInfo
    {
        public int Id { get; set; }

        [ForeignKey(nameof(Course.Id))]
        public int Course_Id { get; set; }

        [ForeignKey(nameof(StudentInfo.Id))]
        public int StudentInfo_Id { get; set; }
    }
}
