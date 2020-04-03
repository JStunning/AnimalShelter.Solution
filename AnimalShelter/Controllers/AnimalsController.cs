using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using AnimalShelter.Models;
using Microsoft.EntityFrameworkCore;
using System;

namespace AnimalShelter.Solution.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AnimalsController : ControllerBase
    {
        private AnimalContext _db;

        public AnimalsController(AnimalContext db)
        {
            _db = db;
        }

        // GET api/animals
        [HttpGet]
        public ActionResult<IEnumerable<Animal>> Get(string animalName, string species, string gender)
        {
            var query = _db.Animals.AsQueryable();

            if (animalName != null)
            {
                query = query.Where(entry => entry.AnimalName == animalName);
            }

            if (species != null)
            {
                query = query.Where(entry => entry.Species == species);
            }

            if (gender != null)
            {
                query = query.Where(entry => entry.Gender == gender);
            }

            return query.ToList();
        }

        // GET api/animals/random
        [HttpGet("random")]
        public ActionResult<Animal> GetRandom()
        {

            Random rnd = new Random();
            var query = _db.Animals.AsQueryable();
            var queryList = query.ToList();
            var RandomNum = rnd.Next(0, queryList.Count);
            return queryList[RandomNum];
        }

        // GET api/animals/5
        [HttpGet("{id}")]
        public ActionResult<Animal> Get(int id)
        {
            return _db.Animals.FirstOrDefault(entry => entry.AnimalId == id);;
        }

        // POST api/animals
        [HttpPost]
        public void Post([FromBody] Animal animal)
        {
            _db.Animals.Add(animal);
            _db.SaveChanges();
        }

        // PUT api/animals/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] Animal animal)
        {
            animal.AnimalId = id;

            _db.Entry(animal).State = EntityState.Modified;
            _db.SaveChanges();
        }

        // DELETE api/animals/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
            var animalToDelete = _db.Animals.FirstOrDefault(entry => entry.AnimalId == id);

            _db.Animals.Remove(animalToDelete);
            _db.SaveChanges();
        }
    }
}
