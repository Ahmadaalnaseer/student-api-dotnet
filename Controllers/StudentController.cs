using FirstRest_Project.Data;
using FirstRest_Project.Model;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Xml.Linq;

namespace FirstRest_Project.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class StudentController : ControllerBase
    {
        [HttpGet("All",Name = "GetAllStudent")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public ActionResult<IEnumerable<Student>> GetAllStudent()
        {
            if (StudentData.StudentList.Count == 0)
            {
                return NotFound("No Student Found");
            }
            return Ok(StudentData.StudentList);
        
        }
        [HttpGet ("Passedstudents", Name = "GetPassedStudent")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public ActionResult<IEnumerable<Student>> GetPassedStudent()
        {
            var Passedstudents = StudentData.StudentList.Where(Student => Student.Grade >= 50).ToList();
            if (Passedstudents.Count == 0)
            {
                return NotFound("No Students Passed");
            }
            return Ok(Passedstudents);

        }
        [HttpGet("AverageGrade", Name = "GetAverageGrade")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public ActionResult<double> GetAverageGrade()
        {
           // StudentData.StudentList.Clear();

            if (StudentData.StudentList.Count == 0)
            {
                return NotFound("No Student Found.");
            }
            var averageGrade = StudentData.StudentList.Average(Student => Student.Grade);
            return Ok(averageGrade);
        }

        [HttpGet("{id}", Name = "GetStudentById")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public ActionResult<Student> GetStudentById(int id)
        {
            if (id<1)
            {
                return BadRequest($" Not Accepted ID {id} " );
            }
            var Student = StudentData.StudentList.FirstOrDefault(Student => Student.Id == id);
            if (Student == null)
            {
                return NotFound($"Student With ID {id} Not Found.");
            }
            return Ok(Student);
        }
        [HttpPost(Name = "AddStudent")]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public ActionResult<Student> AddStudent(Student newStudent)
        {
            if (newStudent == null || string.IsNullOrEmpty(newStudent.Name) || newStudent.Age < 0 || newStudent.Grade < 0)
            {
                return BadRequest("Invalid Student data.");
            }
            newStudent.Id = StudentData.StudentList.Count > 0 ? StudentData.StudentList.Max(s => s.Id) + 1 : 1;
            StudentData.StudentList.Add(newStudent);
            return CreatedAtRoute("GetStudentById" , new { id = newStudent.Id }, newStudent);
        }
        [HttpDelete("{id}", Name = "DeleteStudent")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public ActionResult DeleteStudent(int id) 
        {
            if (id < 1)
            {
                return BadRequest($" Not Accepted ID {id} ");
            }
            var student= StudentData.StudentList.FirstOrDefault(s => s.Id == id);
            if (student == null) 
            {
               return NotFound($"Student With ID {id} Not Found.");
            }
            StudentData.StudentList.Remove(student);
            return Ok($"Student With ID {id} Has been Delete.");
        }
        [HttpPut("{id}", Name = "UpdateStudent")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public ActionResult<Student> UpdateStudent(int id, Student updatedStudent)
        {
            if (id < 1 || updatedStudent == null || string.IsNullOrEmpty(updatedStudent.Name) || updatedStudent.Age < 0 || updatedStudent.Grade < 0)
            {
                return BadRequest("Invalid student data.");
            }

            var student = StudentData.StudentList.FirstOrDefault(s => s.Id == id);
            if (student == null)
            {
                return NotFound($"Student with ID {id} not found.");
            }

            student.Name = updatedStudent.Name;
            student.Age = updatedStudent.Age;
            student.Grade = updatedStudent.Grade;

            return Ok(student);
        }

    }
}
