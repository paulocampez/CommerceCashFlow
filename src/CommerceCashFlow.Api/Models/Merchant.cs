namespace CommerceCashFlow.Api.Models;
public class Merchant
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public string PhoneNumber { get; set; }

        //TODO: Add relationship with transactions (credit/debit)
    }