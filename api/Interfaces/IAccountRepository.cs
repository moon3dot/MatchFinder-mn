namespace api.Interfaces;

public interface IAccountRepository
{
     public Task<LoggedInDto?> CreatAsync(RegisterDto userInput, CancellationToken cancellationToken);
}