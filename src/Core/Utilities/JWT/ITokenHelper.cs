namespace Core.Utilities.JWT
{
    public interface ITokenHelper
    {
        AccessToken CreateToken(TokenData? data);
    }
}
