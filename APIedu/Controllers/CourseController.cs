using APIedu.BI;
using APIedu.Contexts;
using APIedu.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace APIedu.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CourseController : ControllerBase
    {
        private readonly AppDbContext _ctx;

        public CourseController(AppDbContext appDbContext)
        {
            this._ctx = appDbContext;
        }


        //Get all Course
        [HttpGet]
        public IActionResult GetAllCourses()
        {
            return Ok(_ctx.TbCourses.ToList());
        }

        // Get One Course by Id 
        [HttpGet("{id}")]
        public IActionResult GetOneCourseById(int id)
        {
            var coure = _ctx.TbCourses.FirstOrDefault(e => e.Id == id);
            if (coure == null)
            {
                return NotFound("this corse not found");
            }
            return Ok(coure);
        }

        // Get One Course by Id with all lesson related to this course
        [HttpGet("CourseWithLesson/{id}")]
        public IActionResult GetOneCourseByIdWithLessosns(int id)
        {
            var coure = _ctx.TbCourses.FirstOrDefault(e => e.Id == id);
            if (coure == null)
            {
                return NotFound("this corse not found");
            }

            var lessons = _ctx.TbLessons.ToList().Where(e => e.Course_Id == coure.Id);
            if (lessons.Any())
            {
                coure.TbLesson = lessons.ToList();
            }
            return Ok(coure);
        }

        // Get One Course by Id with all lesson related to this course
        [HttpGet("CourseWithStudents/{id}")]
        public IActionResult GetOneCourseByIdWithStudents(int id)
        {
            var students = _ctx.TbCourseStudentInfo.ToList().Where(a=>a.Course_Id == id);
            return Ok(students);
        }

        //create new Course
        [HttpPost]
        public IActionResult AddNewCourse(BlCourse blCourse)
        {
            Course course = new Course();
            course.Title = blCourse.Title;
            course.Description = blCourse.Description;
            course.Code = blCourse.Code;

            _ctx.TbCourses.Add(course);
            _ctx.SaveChanges();

            return Ok(course);
        }


        //Update Course
        [HttpPut("{id}")]
        public IActionResult UpdateCourse(int id , BlCourse blCourse) 
        {
            var course = _ctx.TbCourses.FirstOrDefault(c => c.Id == id);
            if (course == null)
            {
                return NotFound("You try to edit not exsisting course");
            }

            course.Title = blCourse.Title;
            course.Description = blCourse.Description;
            course.Code=blCourse.Code;

            _ctx.Update(course);
            _ctx.SaveChanges();

            return Ok(course);

        }

        //delete
        [HttpDelete]
        public IActionResult DeleteCourse(int id)
        {
            var course = _ctx.TbCourses.FirstOrDefault(e=>e.Id == id);
            if (course == null)
            {
                return NotFound("yu try to delete not exsistin g course ");
            }
            
            _ctx.TbCourses.Remove(course);
            _ctx.SaveChanges();

            return Ok("Delete successfuly !");
        }

    }
}
