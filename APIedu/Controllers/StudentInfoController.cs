using APIedu.BI;
using APIedu.Contexts;
using APIedu.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Collections;

namespace APIedu.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class StudentInfoController : ControllerBase
    {
        private readonly AppDbContext _ctx;

        public StudentInfoController(AppDbContext appDbContext)
        {
            this._ctx = appDbContext;
        }

        //student can see all courses he register it 
        [HttpGet]
        public IActionResult GetAllCourseFourseStudent(int student_Id) 
        {
            var query = from course in _ctx.TbCourses
                        join courseStudentInfo in _ctx.TbCourseStudentInfo
                        on course.Id equals courseStudentInfo.Course_Id
                        where courseStudentInfo.StudentInfo_Id == student_Id
                        select new
                        {
                            Title = course.Title,
                            Course_Id = course.Id
                        };
            return Ok(query);
        }

        //can see course whith lesson for spacific coures he register it 
        [HttpGet("Course/")]
        public IActionResult SeeCourse(int Course_Id,int Studen_Id)
        {
            var query = _ctx.TbCourseStudentInfo.Where(info => info.Course_Id == Course_Id && info.StudentInfo_Id == Studen_Id).FirstOrDefault();
            if(query == null) 
            {
                return BadRequest("yon not register");
            }
            

            //get course and lesson
            var coure = _ctx.TbCourses.FirstOrDefault(e => e.Id == query.Course_Id);
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

        //can regiser new course by code
        [HttpPost]
        public IActionResult RgisterNewCourse(BlRegisterCourse blRegisterCourse)
        {
            if(! ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            var course = _ctx.TbCourses.FirstOrDefault(a=>a.Id == blRegisterCourse.Course_Id);
            if(course == null)
            {
                return BadRequest("You ty to rgister not exsisting course");
            }
            if(blRegisterCourse.Code == course.Code)
            {
                CourseStudentInfo courseStudentInfo = new CourseStudentInfo();
                courseStudentInfo.Course_Id = course.Id;
                courseStudentInfo.StudentInfo_Id = blRegisterCourse.StudentInfo_Id;

                _ctx.TbCourseStudentInfo.Add(courseStudentInfo);
                _ctx.SaveChanges();
                return Ok("Success");
            }
            return BadRequest($"This code : {blRegisterCourse.Code} invalid ");
        }

    }
}
