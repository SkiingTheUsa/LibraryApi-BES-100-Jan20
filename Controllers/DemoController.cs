using LibraryApi.Utils;
using Microsoft.AspNetCore.Mvc;
using System;

namespace LibraryApi.Controllers
{
    public class DemoController : Controller
    {
        private readonly IGeneratorIds idGenerator;

        public DemoController(IGeneratorIds idGenerator)
        {
            this.idGenerator = idGenerator ?? throw new ArgumentNullException(nameof(idGenerator));
        }


        // using the qty:int is a route constraint
        [HttpGet("/beerme/{qty:int}")]
        public IActionResult GetBeer(int qty)
        {
            return Ok($"Giving you {qty} beers");
        }

        // chaining constraints
        [HttpGet("blogs/{year:int:min(2015)}/{month:int:range(1,12)}/{day:int:range(1,31)}")]
        public IActionResult GetPostsFor(int year, int month, int day)
        {
            return Ok($"Getting blog posts for {year}/{month}/{day}");
        }

        [HttpGet("/magazines")]
        public IActionResult GetMagazines([FromQuery] string topic)
        {
            return Ok($"Giving you magazines for {topic}");
        }

        [HttpGet("/whoami")]
        public IActionResult WhoAmI([FromHeader(Name = "User-Agent")]string ua)
        {
            return Ok($"I see you are running {ua}");
        }

        [HttpPost("/courseenrollments")]
        public IActionResult EnrollmentCourse([FromBody] EnrollmentRequest enrollment)
        {
            var response = new EnrollmentResponse
            {
                Instructor = enrollment.Instructor,
                CourseId = enrollment.CourseId,
                EnrollmentId = idGenerator.GetEnrollmentId()
            };

            return Ok(response);
        }
    }

    public class EnrollmentRequest
    {
        public string CourseId { get; set; }
        public string Instructor { get; set; }

    }

    public class EnrollmentResponse
    {
        public string CourseId { get; set; }
        public string Instructor { get; set; }

        public Guid EnrollmentId { get; set; }
    }

}