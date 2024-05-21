using System.ComponentModel.DataAnnotations;

namespace APIedu.BI
{
    public class BlRegisterCourse
    {
        [Required]
        public int StudentInfo_Id { get; set; }

        [Required]
        public int Course_Id { get; set; }

        [Required]
        public string Code { get; set; }
    }
}
