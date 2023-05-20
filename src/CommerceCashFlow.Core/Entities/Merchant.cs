using System;

namespace CommerceCashFlow.Core.Entities;
    public class Merchant //TODO: Add base entity (Id, CreatedAt, UpdatedAt)
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string Address { get; set; }
        //public string Phone { get; set; }
        //public decimal Balance { get; set; }
        //public DateTime CreatedAt { get; set; }
        //public DateTime? UpdatedAt { get; set; }

        //public ICollection<Transaction> Transactions { get; set; }
    }