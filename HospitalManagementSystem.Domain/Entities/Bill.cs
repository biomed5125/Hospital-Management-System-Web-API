using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace HospitalManagementSystem.Domain.Entities
{
    public class Bill
    {
        public int Id { get; set; }

        [Required]
        public int PatientId { get; set; }

        public DateTime BillingDate { get; set; }

        [Required]
        public decimal TotalAmount { get; set; }

        public decimal AmountPaid { get; set; }

        public Patient Patient { get; set; }
        public ICollection<BillItem> BillItems { get; set; }
    }

    public class BillItem
    {
        public int Id { get; set; }

        [Required]
        public int BillId { get; set; }

        [Required]
        [MaxLength(200)]
        public string Description { get; set; }

        [Required]
        public decimal Amount { get; set; }

        public Bill Bill { get; set; }
    }
}
