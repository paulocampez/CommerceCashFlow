using CommerceCashFlow.Core.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CommerceCashFlow.Application.Commands;

public class CreateTransactionCommand : IRequest<int>
{
    public double Amount { get; set; }
    public Guid MerchantId { get; set; }
    public TransactionCategory TransactionCategory { get; set; }

    public CreateTransactionCommand(double amount, Guid merchantId, TransactionCategory transactionCategory)
    {
        TransactionCategory = transactionCategory;
        Amount = amount;
        MerchantId = merchantId;
    }
}
