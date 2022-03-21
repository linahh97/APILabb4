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
