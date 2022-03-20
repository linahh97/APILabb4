using APILabb4.API.Model;
using APILabb4.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace APILabb4.API.Services
{
    public class PersonHobbyRepository : IUserHobby<PersonHobby>
    {
        private AppDbContext _appContext;
        public PersonHobbyRepository(AppDbContext appContext)
        {
            _appContext = appContext;
        }

        public async Task<PersonHobby> Add(PersonHobby newEntity)
        {
            var result = await _appContext.PersonHobbies.AddAsync(newEntity);
            await _appContext.SaveChangesAsync();
            return result.Entity;
        }

        public async Task<PersonHobby> Delete(int id)
        {
            var result = await _appContext.PersonHobbies.FirstOrDefaultAsync(ph => ph.PersonHobbyId == id);
            if (result != null)
            {
                _appContext.PersonHobbies.Remove(result);
                await _appContext.SaveChangesAsync();
                return result;
            }
            return null;
        }

        public async Task<IEnumerable<PersonHobby>> GetAll()
        {
            return await _appContext.PersonHobbies.ToListAsync();
        }

        public async Task<PersonHobby> GetSingle(int id)
        {
            var result = await _appContext.PersonHobbies.FirstOrDefaultAsync(ph => ph.PersonId == id);
            if (result == null)
            {
                _appContext.PersonHobbies.Include(ph => ph.HobbyId).Select(ph => new
                {
                    personId = ph.PersonId,
                    hobbyId = ph.HobbyId
                });
                return result;
            }
            return null;
        }

        public async Task<PersonHobby> Update(PersonHobby Entity)
        {
            var result = await _appContext.PersonHobbies.FirstOrDefaultAsync
                (ph => ph.PersonHobbyId == Entity.PersonHobbyId);
            if (result != null)
            {
                result.HobbyId = Entity.HobbyId;
                result.PersonId = Entity.PersonId;
                result.WebLink = Entity.WebLink;
                await _appContext.SaveChangesAsync();
                return result;
            }
            return null;
        }
    }
}
