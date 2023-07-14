using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using NewApiProject.Data;
using NewApiProject.Models;

namespace NewApiProject.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class StudentController : ControllerBase
    {
        private readonly AppDbContext _context;        //initializing appdbcontext to connect with the database

        public StudentController(AppDbContext context) //generated constuctor here so that we can communicate with the student table
        {
            _context = context;
        }

        [HttpGet]
        public IActionResult Get()  //action method to read all the students
        {
            try
            {
                var student = _context.Student.ToList(); //to return list of students from the table
                if (student.Count == 0)
                {
                    return NotFound("No Students in the table");
                }
                return Ok(student);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
        [HttpGet("{Id}")]
        public IActionResult Get(int Id) //action method for students passed by the user
        {
            try
            {
                var student = _context.Student.Find(Id);
                if (student == null)
                {
                    return NotFound("Student details not found with id" + Id);
                }
                return Ok(student);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPost]
        public IActionResult Post(Student model) //this action method is to create(insert) new data in the database
        {
            try
            {
                _context.Add(model); //added the models to context
                _context.SaveChanges();

                return Ok("Student details created.");
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }


        [HttpPut]
        public IActionResult Put(Student model) //this action method is to update the data
        {
            if(model==null || model.Id==0) //before updating the data we have to validate the model and hence if statement
            {
                if(model== null) //any if condition is satisfied it will come to this if statement
                {
                    return BadRequest("model data is invalid");
                }
                else if(model.Id==0)
                {
                    return BadRequest("invalid student id"+ model.Id);
                }
            }

            try
            {
                var student = _context.Student.Find(model.Id); //validating
                if (student == null)
                {
                    return NotFound("Student id not found" + model.Id);
                }
                student.Name = model.Name; //saving the data attaching student to studentname which is coming from model
                student.Marks = model.Marks;
                _context.SaveChanges();
                return Ok("Student details updated");
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpDelete]

        public IActionResult delete(int Id) //to delete the data
        {
            try
            {
                var student = _context.Student.Find(Id); // Checking if the student data is available or not
                if (student == null)
                {
                    return NotFound("Student id not found" + Id);
                }
                _context.Student.RemoveRange();
                _context.SaveChanges();
                return Ok("Student Record deleted");
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}
