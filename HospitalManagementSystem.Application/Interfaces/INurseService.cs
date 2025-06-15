using HospitalManagementSystem.Domain.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace HospitalManagementSystem.Application.Interfaces
{
    public interface INurseService
    {
        Task<IEnumerable<Nurse>> GetAllNursesAsync();
        Task<Nurse> GetNurseByIdAsync(int id);
        Task AddNurseAsync(Nurse nurse);
        Task UpdateNurseAsync(Nurse nurse);
        Task DeleteNurseAsync(int id);
    }
}
