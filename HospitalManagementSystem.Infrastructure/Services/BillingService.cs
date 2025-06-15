using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using HospitalManagementSystem.Domain.Entities;
using HospitalManagementSystem.Persistence;
using Microsoft.EntityFrameworkCore;

public class BillingService : IBillingService
{
    private readonly ApplicationDbContext _context;

    public BillingService(ApplicationDbContext context)
    {
        _context = context;
    }

    public async Task<Bill> GenerateBillAsync(int patientId, ICollection<BillItem> billItems)
    {
        if (billItems == null || billItems.Count == 0)
            throw new ArgumentException("Bill must have at least one item.");

        decimal totalAmount = 0;
        foreach (var item in billItems)
        {
            totalAmount += item.Amount;
        }

        var bill = new Bill
        {
            PatientId = patientId,
            BillingDate = DateTime.UtcNow,
            TotalAmount = totalAmount,
            AmountPaid = 0,
            BillItems = new List<BillItem>(billItems)
        };

        _context.Bills.Add(bill);
        await _context.SaveChangesAsync();

        return bill;
    }

    public async Task<Bill> GetBillByIdAsync(int billId)
    {
        return await _context.Bills
            .Include(b => b.BillItems)
            .Include(b => b.Patient)
            .FirstOrDefaultAsync(b => b.Id == billId);
    }

    public async Task<IEnumerable<Bill>> GetAllBillsAsync()
    {
        return await _context.Bills
            .Include(b => b.BillItems)
            .Include(b => b.Patient)
            .ToListAsync();
    }

    public async Task UpdateBillAsync(Bill bill)
    {
        _context.Bills.Update(bill);
        await _context.SaveChangesAsync();
    }

    public async Task DeleteBillAsync(int billId)
    {
        var bill = await _context.Bills.FindAsync(billId);
        if (bill != null)
        {
            _context.Bills.Remove(bill);
            await _context.SaveChangesAsync();
        }
    }
}
