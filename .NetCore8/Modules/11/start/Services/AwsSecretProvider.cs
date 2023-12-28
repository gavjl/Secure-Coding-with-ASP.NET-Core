using Amazon;
using Amazon.SecretsManager;
using Amazon.SecretsManager.Model;

namespace Globomantics.Survey.Services
{
    public class AwsSecretProvider
    {
        private readonly IAmazonSecretsManager _client;
        public AwsSecretProvider(string region)
        {
            _client = new AmazonSecretsManagerClient(RegionEndpoint.GetBySystemName(region));
        }

        public async Task<string> GetSecret(string secretName)
        {
            GetSecretValueRequest request = new GetSecretValueRequest();
            request.SecretId = secretName;

            GetSecretValueResponse response = await _client.GetSecretValueAsync(request);

            string secret = "";
            if (response.SecretString != null)
            {
                secret = response.SecretString;
            }

            return secret;
        }
    }

}