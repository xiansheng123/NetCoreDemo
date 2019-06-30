using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using webApiDemo.Services;

namespace webApiDemo.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ValuesController : ControllerBase
    {
        private readonly ApiDBContent _dbContext;

        public ValuesController(ApiDBContent dbContext)
        {
            _dbContext = dbContext;
        }

        // GET api/values
        [HttpGet]
        public ActionResult<IEnumerable<string>> Get()
        {
            return new string[] {"value1", "value2"};
        }

        // GET api/values/5
        [HttpGet("{id}")]
        public ActionResult<string> Get(int id)
        {
            return "value";
        }

        // POST api/values
        [HttpPost]
        public ActionResult<Object> Post([FromBody] Car car)
        {
             //var row1 = _dbContext.Cars.FromSqlRaw("sp_queryCar 0 ,'Homda' ").ToList();

             var name = "Homda";
             var isNeedData = 1;
             var row2 = _dbContext.Database.SqlQuery<Car>(@" exec sp_queryCar 1 ,'Homda'");
             
             return row2.ToList();
        }


        // DELETE api/values/5
        [HttpDelete("xuda/{id}")]
        public ActionResult<Object> Delete(int id)
        {
            var entityEntry = _dbContext.Cars.Remove(new Car {Id = id});
            return _dbContext.SaveChanges();
        }

        [HttpPut("xuda")]
        public ActionResult<Object> CreateNewCar([FromBody] Car car)
        {
            _dbContext.Cars.Add(new Car
            {
                Name = car.Name,
                Brand = "BMW",
                Model = "car3"
            });
            var changes = _dbContext.SaveChanges();
            Console.WriteLine(changes);
            return _dbContext.Cars.Where(x => x.Name == "320").ToList();
        }

        [HttpGet("xuda/{id}")]
        public ActionResult<Object> GetDataFromDd([FromRoute] int id)
        {
            return _dbContext.Cars.Take(2).ToList();
        }
    }
}