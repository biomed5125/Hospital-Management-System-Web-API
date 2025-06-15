using HospitalManagementSystem.Domain.Entities;

namespace HospitalManagementSystem.Application.Interfaces
{
    public interface ILabTestService
    {
        Task<IEnumerable<LabTest>> GetAllLabTestsAsync();
        Task<LabTest> GetLabTestByIdAsync(int id);
        Task AddLabTestAsync(LabTest labTest);
        Task UpdateLabTestAsync(LabTest labTest);
        Task DeleteLabTestAsync(int id);
    }
}
