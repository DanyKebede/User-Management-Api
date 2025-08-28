namespace WebApi.Domain;

public class BankAccount
{
    public string Id { get; set; }
    public string AccountNumber { get; set; }
    public string BankName { get; set; }
    public decimal Balance { get; set; }
}