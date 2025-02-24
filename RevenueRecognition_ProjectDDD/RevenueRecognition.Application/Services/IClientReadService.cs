namespace RevenueRecognition.Application.Services.ClientServices;

public interface IClientReadService
{
    Task<bool> ExistsByPeselAsync(string pesel);
    Task<bool> ExistsByPhoneAsync(string phoneNumber);
    Task<bool> ExistsByEmailAsync(string email);
    Task<bool> ExistsByKrsAsync(string krsNumber);
}