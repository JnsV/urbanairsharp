using UrbanAirSharp.Dto;
using UrbanAirSharp.Request.Base;
using UrbanAirSharp.Response;

namespace UrbanAirSharp.Request
{
    /// <summary>
    /// Used to form a Named User Assocation request
    /// http://docs.urbanairship.com/api/ua.html#disassociation
    /// </summary>
    public class NamedUserDisassociationRequest : PostRequest<BaseResponse, Association>
    {
        public NamedUserDisassociationRequest(Association association, ServiceModelConfig serviceModelConfig)
            :base(association, serviceModelConfig)
        {
            RequestUrl = "api/named_users/disassociate/";
        }
    }
}
