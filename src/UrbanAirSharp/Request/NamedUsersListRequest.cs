using UrbanAirSharp.Request.Base;
using UrbanAirSharp.Response;

namespace UrbanAirSharp.Request
{
    /// <summary>
    /// Used to form a Named User List request
    /// http://docs.urbanairship.com/api/ua.html#listing
    /// </summary>
    public class NamedUsersListRequest : GetRequest<NamedUsersListResponse>
    {
        public NamedUsersListRequest(string NamedUserId, ServiceModelConfig serviceModelConfig)
            : base(serviceModelConfig)
        {
            RequestUrl = string.IsNullOrEmpty(NamedUserId) ? "api/named_users/" : "api/named_users?start="+NamedUserId;
        }
    }
}
