using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using pet_hotel.Models;
using Microsoft.EntityFrameworkCore;

namespace pet_hotel.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class PetOwnersController : ControllerBase
    {
        private readonly ApplicationContext _context;
        public PetOwnersController(ApplicationContext context) {
            _context = context;
        }

        // This is just a stub for GET / to prevent any weird frontend errors that 
        // occur when the route is missing in this controller
        [HttpGet]
        public IEnumerable<PetOwner> GetPets() {
            return _context.PetOwners;
        }
        [HttpGet("{id}")]
        public ActionResult<PetOwner> GetById(int id) {
        PetOwner owner =  _context.PetOwners
        .SingleOrDefault(owner => owner.id == id);
    
        // Return a `404 Not Found` if the PetOwner doesn't exist
        if(owner is null) {
            return NotFound();
        }

        return owner;
}       [HttpPost]
        public PetOwner Post(PetOwner owner) 
        {
        _context.Add(owner);
        _context.SaveChanges();

        return owner;
        }
        [HttpDelete("{id}")]
        public void Delete(int id) 
        {
     
        PetOwner owner = _context.PetOwners.Find(id);

        _context.PetOwners.Remove(owner);

        _context.SaveChanges();
        }
    }
}
