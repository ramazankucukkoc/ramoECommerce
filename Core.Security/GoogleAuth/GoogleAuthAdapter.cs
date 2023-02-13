using Google.Apis.Auth;

namespace Core.Security.GoogleAuth
{
    public class GoogleAuthAdapter : IGoogleAuthAdapter
    {
        public async Task<GoogleUserDetails> GetGoogleUserDetails(string googleAccessToken)
        {

            GoogleJsonWebSignature.Payload? googleAuthTokenInfo = await GoogleJsonWebSignature.ValidateAsync(googleAccessToken);

            return new GoogleUserDetails
            {
                Email = googleAuthTokenInfo.Email,
                EmailVerified = googleAuthTokenInfo.EmailVerified,
                FirstName = googleAuthTokenInfo.GivenName,
                LastName = googleAuthTokenInfo.FamilyName
            };
        }
    }
}
