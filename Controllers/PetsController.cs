using System.Net.NetworkInformation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using pet_hotel.Models;
using Microsoft.EntityFrameworkCore;


namespace pet_hotel.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class PetsController : ControllerBase
    {
        private readonly ApplicationContext _context;
        public PetsController(ApplicationContext context) {
            _context = context;
        }

        // This is just a stub for GET / to prevent any weird frontend errors that 
        // occur when the route is missing in this controller
        
        [HttpGet]
        public IEnumerable<Pet> GetPets() {
            return _context.Pets
                .Include(pet => pet.petOwner);
        }
        [HttpPost]
        public Pet Post(Pet pet) 
        {
        _context.Add(pet);
        _context.SaveChanges();

        return pet;
        }
        [HttpPut("{id}")]

        public Pet Put(int id, Pet pet) 
        {
        // Our DB context needs to know the id of the pet to update
        pet.id = id;
        
        // Tell the DB context about our updated pet object
        _context.Update(pet);

        // ...and save the pet object to the database
        _context.SaveChanges();

        // Respond back with the created pet object
        return pet;
        }

        [HttpPut("{id}/checkin")]

        public Pet PutCheckIn(int id) 
        {
        Console.WriteLine("test");
        System.DateTime today = System.DateTime.Now;

        Console.WriteLine(today);
        // Our DB context needs to know the id of the pet to update

        Pet pet = _context.Pets.SingleOrDefault(pet => pet.id == id);


        // Tell the DB context about our updated pet object
        pet.checkedInAt = today.ToString();

        // ...and save the pet object to the database
        _context.SaveChanges();

        // Respond back with the created pet object
        return pet;
        }
        [HttpPut("{id}/checkout")]

        public Pet PutCheckOut(int id) 
        {
        // Our DB context needs to know the id of the pet to update
        Console.WriteLine("$$$$$$$$$$$$");
        // Tell the DB context about our updated pet object
        Pet pet = _context.Pets.SingleOrDefault(pet => pet.id == id);
        
        pet.checkedInAt = null;

        // ...and save the pet object to the database
        _context.SaveChanges();

        // Respond back with the created pet object
        return pet;
        }
        [HttpDelete("{id}")]
        public void Delete(int id) 
        {
     
        Pet pet = _context.Pets.Find(id);

        _context.Pets.Remove(pet);

        _context.SaveChanges();
        }

        }
}
