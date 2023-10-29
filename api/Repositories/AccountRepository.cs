namespace api.Repositories;

public class AccountRepository : IAccountRepository
{
    #region  Global variabel
    private const string _collectionName = "users"; // Name collection
    private readonly IMongoCollection<AppUser>? _collection; // For use mongoDB collection
    private readonly ITokenService _tokenService; // For token
    #endregion #region  Global variabel

    #region  constroctor AccountRepository
    public AccountRepository(IMongoClient client, IMongoDbSettings dbSettings, ITokenService tokenService)
    {
        var database = client.GetDatabase(dbSettings.DatabaseName);
        _collection = database.GetCollection<AppUser>(_collectionName);
        _tokenService = tokenService;
    }
    #endregion constroctor AccountRepository

    /// <summary>
    /// Account repository connect to acconte conteroller
    /// </summary>
    /// <param name="userInput"></param>
    /// <param name="cancellationToken"></param>
    /// <returns>
    /// loggedInDto for send angular
    /// </returns>
    public async Task<LoggedInDto?> CreatAsync(RegisterDto userInput, CancellationToken cancellationToken)
    {
        // Check the account exist
        bool doesAccountExist = await _collection.Find<AppUser>(user =>
            user.Email == userInput.Email.ToLower().Trim()).AnyAsync();

        if (doesAccountExist)
            return null;

        using var hmac = new HMACSHA512();

        AppUser appUser = new AppUser(
            Id: null,
            Email: userInput.Email.Trim().ToLower(),
            PasswordHash: hmac.ComputeHash(Encoding.UTF8.GetBytes(userInput.Password)),
            PasswordSalt: hmac.Key
        );

        if (_collection is not null)
            await _collection.InsertOneAsync(appUser, null, cancellationToken);

        if (appUser.Id is not null)
        {
            return new LoggedInDto(
                Id: appUser.Id,
                Email: appUser.Email,
                Token: _tokenService.CreateToken(appUser)
            );
        }
        return null;
    }
}