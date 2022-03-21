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

        public async Task<IEnumerable<PersonHobby>> GetAll()
        {
            return await _appContext.PersonHobbies.ToListAsync();
        }

        public async Task<PersonHobby> GetOne(int id)
        {
            return await _appContext.PersonHobbies.FirstOrDefaultAsync(p => p.PersonHobbyId == id);
        }

        public async Task<IEnumerable<PersonHobby>> GetSingle(int id)
        {
            IQueryable<PersonHobby> qw = _appContext.PersonHobbies;
            if (!qw.Equals(id))
            {
                qw = qw.Where(p => p.PersonId == id);
            }
            return qw.ToList();
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
