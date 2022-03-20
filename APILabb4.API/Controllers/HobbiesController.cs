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
    public class HobbiesController : ControllerBase
    {
        private IUserHobby<Hobby> _hobby;
        public HobbiesController(IUserHobby<Hobby> hobby)
        {
            _hobby = hobby;
        }

        [HttpGet]
        public async Task<IActionResult> GetAllHobbies()
        {
            try
            {
                return Ok(await _hobby.GetAll());
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError,
                    "Error to retrieve data from database...");
            }
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Hobby>> GetHobby(int id)
        {
            try
            {
                var result = await _hobby.GetSingle(id);
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
        public async Task<ActionResult<Hobby>> AddNewHobby(Hobby newHobby)
        {
            try
            {
                if (newHobby == null)
                {
                    return BadRequest();
                }
                var addedHobby = await _hobby.Add(newHobby);
                return CreatedAtAction(nameof(GetHobby), new { id = addedHobby.HobbyId }, addedHobby);
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError,
                    "Error to add in database...");
            }
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult<Hobby>> DeleteHobby(int id)
        {
            try
            {
                var hobbyToDelete = await _hobby.GetSingle(id);
                if (hobbyToDelete == null)
                {
                    return NotFound($"Hobby with ID {id} not found...");
                }
                return await _hobby.Delete(id);
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError,
                    "Error to delete from database...");
            }
        }

        [HttpPut("{id}")]
        public async Task<ActionResult<Hobby>> UpdateHobby(int id, Hobby hob)
        {
            try
            {
                if (id != hob.HobbyId)
                {
                    return BadRequest("Hobby ID does not match...");
                }
                var HobbyToUpdate = await _hobby.GetSingle(id);
                if (HobbyToUpdate == null)
                {
                    return NotFound($"Hobby with ID {id} not found...");
                }
                return await _hobby.Update(hob);
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError,
                    "Error to update to database...");
            }
        }
    }
}
