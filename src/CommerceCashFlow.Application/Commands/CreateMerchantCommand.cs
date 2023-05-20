namespace CommerceCashFlow.Application.Commands;
public class CreateMerchantCommand : IRequest<int>
{
    public string Name { get; set; }
    public string Address { get; set; }
    // Add other properties for merchant creation

    public CreateMerchantCommand(string name, string address)
    {
        Name = name;
        Address = address;
    }
}