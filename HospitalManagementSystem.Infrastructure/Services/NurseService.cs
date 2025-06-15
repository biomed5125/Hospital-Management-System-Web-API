using HospitalManagementSystem.Application.Interfaces;
using HospitalManagementSystem.Domain.Entities;
using HospitalManagementSystem.Persistence;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace HospitalManagementSystem.Infrastructure.Services
{
    public class NurseService : INurseService
    {
        private readonly ApplicationDbContext _context;

        public NurseService(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Nurse>> GetAllNursesAsync()
        {
            return await _context.Nurses.ToListAsync();
        }

        public async Task<Nurse> GetNurseByIdAsync(int id)
        {
            return await _context.Nurses.FindAsync(id);
        }

        public async Task AddNurseAsync(Nurse nurse)
        {
            _context.Nurses.Add(nurse);
            await _context.SaveChangesAsync();
        }

        public async Task UpdateNurseAsync(Nurse nurse)
        {
            _context.Nurses.Update(nurse);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteNurseAsync(int id)
        {
            var nurse = await _context.Nurses.FindAsync(id);
            if (nurse != null)
            {
                _context.Nurses.Remove(nurse);
                await _context.SaveChangesAsync();
            }
        }
    }
}
