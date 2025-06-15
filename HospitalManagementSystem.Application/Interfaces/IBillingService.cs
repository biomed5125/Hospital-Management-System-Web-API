using System.Collections.Generic;
using System.Threading.Tasks;
using HospitalManagementSystem.Domain.Entities;

public interface IBillingService
{
    Task<Bill> GenerateBillAsync(int patientId, ICollection<BillItem> billItems);
    Task<Bill> GetBillByIdAsync(int billId);
    Task<IEnumerable<Bill>> GetAllBillsAsync();
    Task UpdateBillAsync(Bill bill);
    Task DeleteBillAsync(int billId);
}
