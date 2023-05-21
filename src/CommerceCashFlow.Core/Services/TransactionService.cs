using CommerceCashFlow.Core.Entities;
using CommerceCashFlow.Core.Repositories.Interfaces;
using CommerceCashFlow.Core.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CommerceCashFlow.Core.Services;
public class TransactionService : ITransactionService
{
    private readonly ITransactionRepository _transactionRepository;

    public TransactionService(ITransactionRepository transactionRepository)
    {
        _transactionRepository = transactionRepository;
    }

    public async Task<int> CreateTransactionAsync(Transaction transaction)
    {
        //TODO: Validate

        // Save the transaction using the repository
        return await _transactionRepository.CreateAsync(transaction);
    }
}

