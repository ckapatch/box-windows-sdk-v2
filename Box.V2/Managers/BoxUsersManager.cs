using Box.V2.Auth;
using Box.V2.Config;
using Box.V2.Converter;
using Box.V2.Extensions;
using Box.V2.Models;
using Box.V2.Services;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Box.V2.Managers
{
    /// <summary>
    /// The manager that represents all of the user endpoints
    /// </summary>
    public class BoxUsersManager : BoxResourceManager
    {
        public BoxUsersManager(IBoxConfig config, IBoxService service, IBoxConverter converter, IAuthRepository auth)
            : base(config, service, converter, auth) { }

        /// <summary>
        /// Retrieves information about the user who is currently logged in i.e. the user for whom this auth token was generated.
        /// </summary>
        /// <exception cref="Exceptions.BoxRateLimitingException">Thrown If the account is currently rate limited</exception>
        /// <exception cref="Exceptions.AccessTokenExpiredException">Thrown If the account's Access Token has expired</exception>
        /// <exception cref="Exceptions.BoxException">Thrown If any other unknown error is returned</exception>                              
        /// <returns></returns>
        public async Task<BoxUser> GetCurrentUserInformationAsync(List<string> fields = null)
        {
            BoxRequest request = new BoxRequest(_config.UserEndpointUri, "me")
                .Param(ParamFields, fields);

            IBoxResponse<BoxUser> response = await ToResponseAsync<BoxUser>(request).ConfigureAwait(false);

            return response.ResponseObject;
        }

        /// <summary>
        /// Used to edit the settings and information about a user. This method only works for enterprise admins. To roll a user out 
        /// of the enterprise (and convert them to a standalone free user), update the special enterprise attribute to be null
        /// </summary>
        /// <param name="id"></param>
        /// <param name="userRequest"></param>
        /// <exception cref="Exceptions.BoxRateLimitingException">Thrown If the account is currently rate limited</exception>
        /// <exception cref="Exceptions.AccessTokenExpiredException">Thrown If the account's Access Token has expired</exception>
        /// <exception cref="Exceptions.BoxException">Thrown If any other unknown error is returned</exception>                       
        /// <returns></returns>
        public async Task<BoxUser> UpdateUserInformationAsync(BoxUserRequest userRequest, List<string> fields = null)
        {
            BoxRequest request = new BoxRequest(_config.UserEndpointUri, userRequest.Id)
                .Param(ParamFields, fields)
                .Payload(_converter.Serialize(userRequest));

            IBoxResponse<BoxUser> response = await ToResponseAsync<BoxUser>(request).ConfigureAwait(false);

            return response.ResponseObject;
        }

    }
}
