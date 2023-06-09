﻿using CommerceCashFlow.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CommerceCashFlow.Core.Services.Interfaces;

public interface ITransactionService
{
    Task<int> CreateTransactionAsync(Transaction transaction);
}

