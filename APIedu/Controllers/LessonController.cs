using APIedu.BI;
using APIedu.Contexts;
using APIedu.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace APIedu.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LessonController : ControllerBase
    {
        private readonly AppDbContext _ctx;

        public LessonController(AppDbContext appDbContext)
        {
            this._ctx = appDbContext;
        }

        //get all lesson for spasifc course 
        [HttpGet("{id}")]
        public IActionResult GetAllLessonForCourse(int id)
        {
            if(_ctx.TbCourses.FirstOrDefault(a=>a.Id == id) == null)
            {
                return NotFound("This course not existing");
            }
            return Ok(_ctx.TbLessons.ToList().Where(c=>c.Course_Id == id));
        }

        //get one lesson for spasifc coures
        [HttpGet("GetOneLesson/")]
        public IActionResult GetOneLessonForCourse(int course_id , int lesson_id) 
        {
            if (_ctx.TbCourses.FirstOrDefault(a => a.Id == course_id) == null)
            {
                return NotFound("This course not existing");
            }
            var lesson = _ctx.TbLessons.FirstOrDefault(a=>a.Id== lesson_id);    
            if (lesson == null)
            {
                return NotFound("This lesson not exsisting");
            }
            return Ok(lesson);
        }

        //add new lesson
        [HttpPost("{course_id}")]
        public IActionResult AddNewLesson(int course_id,BlLesson blLesson)
        {
            if(!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            Lesson lesson = new Lesson();

            lesson.Title = blLesson.Title;
            lesson.Course_Id = course_id;
            lesson.Contant = blLesson.Contant;

            _ctx.TbLessons.Add(lesson);
            _ctx.SaveChanges();

            return Ok(lesson);

        }

        //update existing esson
        [HttpPut("{id}")]
        public IActionResult UpdateLesson(int id , BlLesson blLesson)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            var lesson = _ctx.TbLessons.FirstOrDefault(b=>b.Id==id);
            if(lesson == null)
            {
                return NotFound("you try to edit lesson not exsisting");
            }

            lesson.Title = blLesson.Title;
            lesson.Contant=blLesson.Contant;
            lesson.Course_Id = blLesson.Course_Id; 

            _ctx.TbLessons.Update(lesson);
            _ctx.SaveChanges(true);

            return Ok(lesson);
        }


        //delete lesson
        [HttpDelete("{id}")]
        public IActionResult DeleteLesson(int id)
        {
            var lesson = _ctx.TbLessons.FirstOrDefault(a => a.Id == id);
            if (lesson == null)
            {
                return NotFound("This Lesson not existing");
            }

            _ctx.TbLessons.Remove(lesson);
            _ctx.SaveChanges();

            return Ok("Deleted");
        }
    }
}
