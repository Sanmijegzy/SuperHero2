using Microsoft.AspNetCore.Components.Web.Virtualization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Runtime.ExceptionServices;
using SuperHero2.Entities;
using SuperHero2.Data;
using Microsoft.EntityFrameworkCore;

namespace SuperHero2.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    


    public class SuperheroController : ControllerBase
    {
        private readonly DataContext _context;

        public SuperheroController(DataContext context)
        {
           _context = context;
        }

        [HttpGet]

        public async Task<ActionResult<List<Superhero>>> GetAllHeroes()
        {

            var heroes = await _context.Superheroes.ToListAsync();

           
           return Ok(heroes); 
            

            
        }

        [HttpGet("{id}")]
       // [Route("{id}")]

        public async Task<ActionResult<List<Superhero>>> GetHero(int id )
        {

            var hero = await _context.Superheroes.FindAsync(id);
            if(hero is null)
                return NotFound();

            return Ok(hero);




        }
        [HttpPost]
        public async Task<ActionResult<List<Superhero>>> AddHero(Superhero hero)
        {

             _context.Superheroes.Add(hero);
            await _context.SaveChangesAsync();

            return Ok(await _context.Superheroes.ToListAsync());




        }


        [HttpPut]
        public async Task<ActionResult<List<Superhero>>> UpdateHero(Superhero updatedHero)
        {

           var dbHero = await _context.Superheroes.FindAsync(updatedHero.Id);
            if (dbHero is null)

                return NotFound("Hero not found"); 
            dbHero.Name = updatedHero. Name;
            dbHero.FirstName = updatedHero.Name;
            dbHero.LastName = updatedHero.Name;
            dbHero.place = updatedHero.Name;

            await _context.SaveChangesAsync();
            return Ok(await _context.Superheroes.ToListAsync());



        }
        [HttpDelete]
        public async Task<ActionResult<List<Superhero>>> DeleteHero(int id)
        {

            var dbHero = await _context.Superheroes.FindAsync(id);
            if (dbHero is null)

                return NotFound("Hero not found");
            _context .Superheroes.Remove(dbHero);   

            await _context.SaveChangesAsync();
            return Ok(await _context.Superheroes.ToListAsync());



        }
    }  
}
