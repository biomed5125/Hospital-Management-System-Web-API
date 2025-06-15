using System.Collections.Generic;
using System.Threading.Tasks;
using HospitalManagementSystem.Application.Interfaces;
using HospitalManagementSystem.Domain.Entities;
using HospitalManagementSystem.Persistence;
using Microsoft.EntityFrameworkCore;

namespace HospitalManagementSystem.Infrastructure.Services
{
    public class AdmissionService : IAdmissionService
    {
        private readonly ApplicationDbContext _context;

        public AdmissionService(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Admission>> GetAllAdmissionsAsync()
        {
            return await _context.Admissions.Include(a => a.Patient).ToListAsync();
        }

        public async Task<Admission> GetAdmissionByIdAsync(int id)
        {
            return await _context.Admissions.Include(a => a.Patient).FirstOrDefaultAsync(a => a.Id == id);
        }

        public async Task AddAdmissionAsync(Admission admission)
        {
            _context.Admissions.Add(admission);
            await _context.SaveChangesAsync();
        }

        public async Task UpdateAdmissionAsync(Admission admission)
        {
            _context.Admissions.Update(admission);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteAdmissionAsync(int id)
        {
            var admission = await _context.Admissions.FindAsync(id);
            if (admission != null)
            {
                _context.Admissions.Remove(admission);
                await _context.SaveChangesAsync();
            }
        }
    }
}
