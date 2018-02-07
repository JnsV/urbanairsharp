using UrbanAirSharp.Dto;
using UrbanAirSharp.Request.Base;
using UrbanAirSharp.Response;

namespace UrbanAirSharp.Request
{
    /// <summary>
    /// Used to form a PUSH request
    /// http://docs.urbanairship.com/reference/api/v3/push.html
    /// </summary>
    public class NamedUsersTagRequest : PostRequest<BaseResponse, NamedUserTagUpdate>
    {
        public NamedUsersTagRequest(NamedUserTagUpdate namedUserTagUpdate, ServiceModelConfig serviceModelConfig)
            : base(namedUserTagUpdate, serviceModelConfig)
        {
            RequestUrl = "api/named_users/tags/";
        }
    }
}