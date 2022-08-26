namespace Post2.Services
{
    public interface IAccountNumberValidationService
    {
        bool isValid(string accountNumber);
    }
}