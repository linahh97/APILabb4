using APILabb4.API.Model;
using APILabb4.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace APILabb4.API.Services
{
    public class PersonRepository : IUserHobby<Person>
    {
        private AppDbContext _appContext;
        public PersonRepository(AppDbContext appContext)
        {
            _appContext = appContext;
        }
        public async Task<Person> Add(Person newEntity)
        {
            var result = await _appContext.People.AddAsync(newEntity);
            await _appContext.SaveChangesAsync();
            return result.Entity;
        }

        public async Task<Person> Delete(int id)
        {
            var result = await _appContext.People.FirstOrDefaultAsync(p => p.PersonId == id);
            if (result != null)
            {
                _appContext.People.Remove(result);
                await _appContext.SaveChangesAsync();
                return result;
            }
            return null;
        }

        public async Task<IEnumerable<Person>> GetAll()
        {
            return await _appContext.People.ToListAsync();
        }

        public async Task<Person> GetSingle(int id)
        {
            return await _appContext.People.FirstOrDefaultAsync(p => p.PersonId == id);
        }

        public async Task<Person> Update(Person Entity)
        {
            var result = await _appContext.People.FirstOrDefaultAsync(p => p.PersonId == Entity.PersonId);
            if (result != null)
            {
                result.FirstName = Entity.FirstName;
                result.LastName = Entity.LastName;
                result.Address = Entity.Address;
                result.Phone = Entity.Phone;
                result.Email = Entity.Email;
                await _appContext.SaveChangesAsync();
                return result;
            }
            return null;
        }
    }
}
