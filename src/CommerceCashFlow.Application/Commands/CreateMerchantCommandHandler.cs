using CommerceCashFlow.Application.Commands;
using CommerceCashFlow.Core.Entities;
using CommerceCashFlow.Core.Repositories;
using MediatR;

namespace CommerceCashFlow.Application.CommandHandlers;
public class CreateMerchantCommandHandler : IRequestHandler<CreateMerchantCommand, Guid>
{
    private readonly IMerchantRepository _merchantRepository;

    public CreateMerchantCommandHandler(IMerchantRepository merchantRepository)
    {
        _merchantRepository = merchantRepository;
    }

    public async Task<Guid> Handle(CreateMerchantCommand request, CancellationToken cancellationToken)
    {
        var merchant = new Merchant
        {
            Name = request.Name,
            Address = request.Address,
        };

        await _merchantRepository.AddMerchant(merchant);

        return merchant.Id;
    }
}