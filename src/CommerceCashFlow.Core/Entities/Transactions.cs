using System;

namespace CommerceCashFlow.Core.Entities;
public class Transaction
{
    public int Id { get; set; }
    public decimal Amount { get; set; }
    public int MerchantId { get; set; }
     public TransactionCategory TransactionCategory { get; set; }
    public Merchant Merchant { get; set; }
}

public enum TransactionCategory //TODO: Send to enum folder
{
    Credit,
    Debit
}
