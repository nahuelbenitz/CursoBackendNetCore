using Backend.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Backend.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PeopleController : ControllerBase
    {
        private IPeopleService _peopleService;
        public PeopleController(IPeopleService peopleService)
        {
            _peopleService = peopleService;
        }

        [HttpGet("all")]
        public List<People> GetAll() => RepositoryPeople.People;

        [HttpGet("{id}")]
        public ActionResult<People> GetById(int id)
        {
            var people = RepositoryPeople.People.FirstOrDefault(p => p.Id == id);

            if (people == null)
            {
                return NotFound();
            }

            return Ok(people);
        }

        [HttpGet("search/{search}")]
        public List<People> GetSearch(string search) => 
            RepositoryPeople.People.Where(p => p.Name.ToUpper().Contains(search.ToUpper())).ToList();

        [HttpPost]
        public IActionResult Add(People people)
        {
            if (!_peopleService.Validate(people))
            {
                return BadRequest();
            }

            RepositoryPeople.People.Add(people);
            return NoContent();

        }

    }

    public class People
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public DateTime Birthdate { get; set; }
    }

    public class RepositoryPeople
    {
        public static List<People> People = new List<People>
        {
            new People()
            {
                Id = 1, Name = "Juan", Birthdate = new DateTime(1995,1,30)
            },
            new People()
            {
                Id = 2, Name = "Alexis", Birthdate = new DateTime(1895,12,24)
            },
            new People()
            {
                Id = 3, Name = "Mara", Birthdate = new DateTime(1999,5,20)
            },
            new People()
            {
                Id = 4, Name = "Laura", Birthdate = new DateTime(2005,10,31)
            },

        };
    }
}
