using HospitalManagementSystem.Application.Interfaces;
using HospitalManagementSystem.Domain.Entities;
using HospitalManagementSystem.Persistence;
using Microsoft.EntityFrameworkCore;

namespace HospitalManagementSystem.Infrastructure.Services
{
    public class LabTestService : ILabTestService
    {
        private readonly ApplicationDbContext _context;

        public LabTestService(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<LabTest>> GetAllLabTestsAsync()
        {
            return await _context.LabTests.Include(t => t.Patient).ToListAsync();
        }

        public async Task<LabTest> GetLabTestByIdAsync(int id)
        {
            return await _context.LabTests.Include(t => t.Patient)
                                          .FirstOrDefaultAsync(t => t.Id == id);
        }

        public async Task AddLabTestAsync(LabTest labTest)
        {
            _context.LabTests.Add(labTest);
            await _context.SaveChangesAsync();
        }

        public async Task UpdateLabTestAsync(LabTest labTest)
        {
            _context.LabTests.Update(labTest);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteLabTestAsync(int id)
        {
            var test = await _context.LabTests.FindAsync(id);
            if (test != null)
            {
                _context.LabTests.Remove(test);
                await _context.SaveChangesAsync();
            }
        }
    }
}
