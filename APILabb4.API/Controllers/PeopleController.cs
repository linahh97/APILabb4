using APILabb4.API.Services;
using APILabb4.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace APILabb4.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PeopleController : ControllerBase
    {
        private IUserHobby<Person> _user;
        public PeopleController(IUserHobby<Person> user)
        {
            _user = user;
        }

        [HttpGet]
        public async Task<IActionResult> GetAllPeople()
        {
            try
            {
                return Ok(await _user.GetAll());
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError,
                    ("Error to retrieve data from database..."));
            }
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Person>> GetPerson(int id)
        {
            try
            {
                var result = await _user.GetSingle(id);
                if (result == null)
                {
                    return NotFound();
                }
                return result;
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError,
                    "Error to retrieve single product from database...");
            }
        }

        [HttpPost]
        public async Task<ActionResult<Person>> AddNewPerson(Person newUser)
        {
            try
            {
                if (newUser == null)
                {
                    return BadRequest();
                }
                var addUser = await _user.Add(newUser);
                return CreatedAtAction(nameof(GetPerson), new { id = addUser.PersonId }, addUser);
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError,
                    "Error to add in database...");
            }
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult<Person>> DeletePerson(int id)
        {
            try
            {
                var personToDelete = await _user.GetSingle(id);
                if (personToDelete == null)
                {
                    return NotFound($"Person with ID {id} not found...");
                }
                return await _user.Delete(id);
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError,
                    "Error to delete from database...");
            }
        }
        [HttpPut("{id}")]
        public async Task<ActionResult<Person>> UpdatePerson (int id, Person user)
        {
            try
            {
                if (id != user.PersonId)
                {
                    return BadRequest("Person ID does not match...");
                }
                var PersonToUpdate = await _user.GetSingle(id);
                if (PersonToUpdate == null)
                {
                    return NotFound($"Person with ID {id} not found...");
                }
                return await _user.Update(user);
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError,
                    "Error to update to database...");
            }
        }
    }
}
