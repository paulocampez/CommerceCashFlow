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
            Name = request.Name,
            Address = request.Address,
            // Set other properties
        };

        await _merchantRepository.AddMerchantAsync(merchant);

        return merchant.Id;
    }
}