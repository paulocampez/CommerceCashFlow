using AutoMapper;
using CommerceCashFlow.Core.Entities;
using CommerceCashFlow.Core.Services.Interfaces;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CommerceCashFlow.Application.Commands;

    public class CreateTransactionCommandHandler : IRequestHandler<CreateTransactionCommand, int>
    {
        private readonly ITransactionService _transactionService;
        private readonly IMapper _mapper;

        public CreateTransactionCommandHandler(ITransactionService transactionService, IMapper mapper)
        {
            _transactionService = transactionService;
            _mapper = mapper;
        }

        public async Task<int> Handle(CreateTransactionCommand request, CancellationToken cancellationToken)
        {
            var transaction = _mapper.Map<Transaction>(request);

            var transactionId = await _transactionService.CreateTransactionAsync(transaction);

            return transactionId;
        }
    }

