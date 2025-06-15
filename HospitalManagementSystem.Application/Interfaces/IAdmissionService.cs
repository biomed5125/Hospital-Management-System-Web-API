using HospitalManagementSystem.Domain.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace HospitalManagementSystem.Application.Interfaces
{
    public interface IAdmissionService
    {
        Task<IEnumerable<Admission>> GetAllAdmissionsAsync();
        Task<Admission> GetAdmissionByIdAsync(int id);
        Task AddAdmissionAsync(Admission admission);
        Task UpdateAdmissionAsync(Admission admission);
        Task DeleteAdmissionAsync(int id);
    }
}
