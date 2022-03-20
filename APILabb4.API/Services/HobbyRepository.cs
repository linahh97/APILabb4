using APILabb4.API.Model;
using APILabb4.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace APILabb4.API.Services
{
    public class HobbyRepository : IUserHobby<Hobby>
    {
        private AppDbContext _appContext;
        public HobbyRepository (AppDbContext appContext)
        {
            _appContext = appContext;
        }

        public async Task<Hobby> Add(Hobby newEntity)
        {
            var result = await _appContext.Hobbies.AddAsync(newEntity);
            await _appContext.SaveChangesAsync();
            return result.Entity;
        }

        public async Task<Hobby> Delete(int id)
        {
            var result = await _appContext.Hobbies.FirstOrDefaultAsync(h => h.HobbyId == id);
            if (result != null)
            {
                _appContext.Hobbies.Remove(result);
                await _appContext.SaveChangesAsync();
                return result;
            }
            return null;
        }

        public async Task<IEnumerable<Hobby>> GetAll()
        {
            return await _appContext.Hobbies.ToListAsync();
        }

        public async Task<Hobby> GetSingle(int id)
        {
            return await _appContext.Hobbies.FirstOrDefaultAsync(h => h.HobbyId == id);
        }

        public async Task<Hobby> Update(Hobby Entity)
        {
            var result = await _appContext.Hobbies.FirstOrDefaultAsync(h => h.HobbyId == Entity.HobbyId);
            if (result != null)
            {
                result.HobbyName = Entity.HobbyName;
                result.Description = Entity.Description;
                await _appContext.SaveChangesAsync();
                return result;
            }
            return null;
        }
    }
}
