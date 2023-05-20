using CommerceCashFlow.Application.Commands;
using CommerceCashFlow.Core.Entities;
using CommerceCashFlow.Core.Repositories;
using MediatR;

namespace CommerceCashFlow.Application.CommandHandlers;
public class CreateMerchantHandler : IRequestHandler<CreateMerchantCommand, int>
{
    private readonly IMerchantRepository _merchantRepository;

    public CreateMerchantHandler(IMerchantRepository merchantRepository)
    {
        _merchantRepository = merchantRepository;
    }

    public async Task<int> Handle(CreateMerchantCommand request, CancellationToken cancellationToken)
    {
        var merchant = new Merchant
        {
            Name = request.Name
        };

        await _merchantRepository.AddMerchant(merchant);

        return merchant.Id;
    }
}