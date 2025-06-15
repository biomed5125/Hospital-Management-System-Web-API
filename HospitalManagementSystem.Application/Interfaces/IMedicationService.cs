using System.Collections.Generic;
using System.Threading.Tasks;
using HospitalManagementSystem.Domain.Entities;

namespace HospitalManagementSystem.Application.Interfaces
{
    public interface IMedicationService
    {
        Task<IEnumerable<Medication>> GetAllMedicationsAsync();
        Task<Medication> GetMedicationByIdAsync(int id);
        Task AddMedicationAsync(Medication medication);
        Task UpdateMedicationAsync(Medication medication);
        Task DeleteMedicationAsync(int id);
    }
}
