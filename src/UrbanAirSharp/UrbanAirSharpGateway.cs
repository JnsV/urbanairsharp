﻿// Copyright (c) 2014-2015 Jeff Gosling (jeffery.gosling@gmail.com)
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;
using log4net;
using log4net.Config;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using UrbanAirSharp.Dto;
using UrbanAirSharp.Request;
using UrbanAirSharp.Request.Base;
using UrbanAirSharp.Response;
using UrbanAirSharp.Type;

namespace UrbanAirSharp
{
	/// <summary>
	/// A gateway for pushing notifications to the Urban Airship API V3
	/// http://docs.urbanairship.com/reference/api/v3/
	/// 
	/// Supported:
	/// ---------
	/// api/push
	/// api/push/validate
	/// api/schedule 
	/// api/device_tokens 
	/// api/tags 
	/// 
	/// Not Supported Yet:
	/// -----------------
	/// api/feeds 
	/// api/reports 
	/// api/segments 
	/// api/location 
	/// </summary>

	public class UrbanAirSharpGateway
	{
		private static readonly ILog Log = LogManager.GetLogger(typeof(UrbanAirSharpGateway));
	    private readonly ServiceModelConfig serviceModelConfig;


        public UrbanAirSharpGateway(String appKey, String appMasterSecret)
		{
			XmlConfigurator.Configure();
			serviceModelConfig = ServiceModelConfig.Create(appKey, appMasterSecret);
		}

		/// <summary>
		/// - Broadcast to all devices
		/// - Broadcast to one device type
		/// - Send to a targeted device
		/// - Broadcast to all devices with a different alert for each type
		/// </summary>
		/// <param name="alert">The message to be pushed</param>
		/// <param name="deviceTypes">use null for broadcast</param>
		/// <param name="deviceId">use null for broadcast or deviceTypes must contain 1 element that distinguishes this deviceId</param>
		/// <param name="deviceAlerts">per device alert messages and extras</param>
		/// <param name="customAudience">a more specific way to choose the audience for the push. If this is set, deviceId is ignored</param>
		/// <returns></returns>
		public PushResponse Push(String alert, IList<DeviceType> deviceTypes = null, String deviceId = null, IList<BaseAlert> deviceAlerts = null, Audience customAudience = null)
		{
			return SendRequest(new PushRequest(CreatePush(alert, deviceTypes, deviceId, deviceAlerts, customAudience), serviceModelConfig));
		}

		/// <summary>
		/// Validates a push request. Duplicates Push without actually sending the alert. See Push
		/// </summary>
		/// <param name="alert">The message to be pushed</param>
		/// <param name="deviceTypes">use null for broadcast</param>
		/// <param name="deviceId">use null for broadcast or deviceTypes must contain 1 element that distinguishes this deviceId</param>
		/// <param name="deviceAlerts">per device alert messages and extras</param>
		/// <param name="customAudience">a more specific way to choose the audience for the push. If this is set, deviceId is ignored</param>
		/// <returns></returns>
		public PushResponse Validate(String alert, IList<DeviceType> deviceTypes = null, String deviceId = null,
			IList<BaseAlert> deviceAlerts = null, Audience customAudience = null)
		{
			return SendRequest(new PushValidateRequest(CreatePush(alert, deviceTypes, deviceId, deviceAlerts, customAudience), serviceModelConfig));
		}

		public ScheduleCreateResponse CreateSchedule(Schedule schedule)
        {
			return SendRequest(new ScheduleCreateRequest(schedule, serviceModelConfig));
        }

		public ScheduleEditResponse EditSchedule(Guid scheduleId, Schedule schedule)
        {
			return SendRequest(new ScheduleEditRequest(scheduleId, schedule, serviceModelConfig));
        }

		public BaseResponse DeleteSchedule(Guid scheduleId)
        {
			return SendRequest(new ScheduleDeleteRequest(scheduleId, serviceModelConfig));
        }

        public ScheduleGetResponse GetSchedule(Guid scheduleId)
        {
			return SendRequest(new ScheduleGetRequest(scheduleId, serviceModelConfig));
        }

        public ScheduleListResponse ListSchedules()
        {
			return SendRequest(new ScheduleListRequest(serviceModelConfig));
        }

		/// <summary>
		/// Registers a device token only with the Urban Airship site, this can be used for new device tokens and for existing tokens.
		/// The existing settings (badge, tags, alias, quiet times) will be overriden. If a token has become inactive reregistering it
		/// will make it active again.
		/// </summary>
		/// <returns>Response from Urban Airship</returns>
		public BaseResponse RegisterDeviceToken(string deviceToken)
		{
			return RegisterDeviceToken(new DeviceToken() {Token = deviceToken});
		}

		/// <summary>
		/// Registers a device token with extended properties with the Urban Airship site, this can be used for new device 
		/// tokens and for existing tokens. If a token has become inactive reregistering it will make it active again. 
		/// </summary>
		/// <returns>Response from Urban Airship</returns>
		public BaseResponse RegisterDeviceToken(DeviceToken deviceToken)
		{
			if (string.IsNullOrEmpty(deviceToken.Token))
				throw new ArgumentException("A device Tokens Token field is Required", "deviceToken");

			return SendRequest(new DeviceTokenRequest(deviceToken, serviceModelConfig));
		}

		public BaseResponse CreateTag(Tag tag)
		{
			if (string.IsNullOrEmpty(tag.TagName))
				throw new ArgumentException("A tag name is Required", "tag.TagName");

			return SendRequest(new TagCreateRequest(tag, serviceModelConfig));
		}

		public BaseResponse DeleteTag(string tag)
		{
			if (string.IsNullOrEmpty(tag))
				throw new ArgumentException("A tag is Required", "tag");

			return SendRequest(new TagDeleteRequest(tag, serviceModelConfig));
		}

		public TagListResponse ListTags()
		{
			return SendRequest(new TagListRequest(serviceModelConfig));
		}

		public static Push CreatePush(String alert, IList<DeviceType> deviceTypes = null, String deviceId = null, IList<BaseAlert> deviceAlerts = null, Audience customAudience = null)
		{
			var push = new Push()
			{
				Notification = new Notification()
				{
					DefaultAlert = alert
				}
			};

			if (customAudience != null)
			{
				deviceId = null;

				push.Audience = customAudience;
			}

			if (deviceTypes != null)
			{
				push.DeviceTypes = deviceTypes;

				if (deviceId != null)
				{
					if (deviceTypes.Count != 1)
					{
						throw new InvalidOperationException("when deviceId is not null, deviceTypes must contain 1 element which identifies the deviceId type");
					}

					var deviceType = deviceTypes[0];

					switch (deviceType)
					{
						case DeviceType.Android:
							push.SetAudience(AudienceType.Android, deviceId);
							break;
						case DeviceType.Ios:
							push.SetAudience(AudienceType.Ios, deviceId);
							break;
						case DeviceType.Wns:
							push.SetAudience(AudienceType.Windows, deviceId);
							break;
						case DeviceType.Mpns:
							push.SetAudience(AudienceType.WindowsPhone, deviceId);
							break;
						case DeviceType.Blackberry:
							push.SetAudience(AudienceType.Blackberry, deviceId);
							break;
					}
				}
			}

			if (deviceAlerts == null || deviceAlerts.Count <= 0)
			{
				return push;
			}

			push.Notification.AndroidAlert = (AndroidAlert)deviceAlerts.FirstOrDefault(x => x is AndroidAlert);
			push.Notification.IosAlert = (IosAlert)deviceAlerts.FirstOrDefault(x => x is IosAlert);
			push.Notification.WindowsAlert = (WindowsAlert)deviceAlerts.FirstOrDefault(x => x is WindowsAlert);
			push.Notification.WindowsPhoneAlert = (WindowsPhoneAlert)deviceAlerts.FirstOrDefault(x => x is WindowsPhoneAlert);
			push.Notification.BlackberryAlert = (BlackberryAlert)deviceAlerts.FirstOrDefault(x => x is BlackberryAlert);

			return push;
		}

		//=====================================================================================================================

		private static TResponse SendRequest<TResponse>(BaseRequest<TResponse> request) where TResponse : BaseResponse, new()
		{
			try
			{
				var requestTask = request.ExecuteAsync();

				return requestTask.Result;
			}
			catch (Exception e)
			{
				Log.Error(request.GetType().FullName, e);

				return new TResponse()
				{
					Error = e.InnerException != null ? e.InnerException.Message : e.Message,
					Ok = false
				};
			}
		}
	}
}
