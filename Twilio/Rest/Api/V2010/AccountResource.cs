using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using Twilio.Base;
using Twilio.Clients;
using Twilio.Converters;
using Twilio.Exceptions;
using Twilio.Http;

namespace Twilio.Rest.Api.V2010 
{

    public class AccountResource : Resource 
    {
        public sealed class Status : IStringEnum 
        {
            public const string Active = "active";
            public const string Suspended = "suspended";
            public const string Closed = "closed";
        
            private string _value;
            
            public Status() {}
            
            public Status(string value)
            {
                _value = value;
            }
            
            public override string ToString()
            {
                return _value;
            }
            
            public static implicit operator Status(string value)
            {
                return new Status(value);
            }
            
            public static implicit operator string(Status value)
            {
                return value.ToString();
            }
            
            public void FromString(string value)
            {
                _value = value;
            }
        }
    
        public sealed class Type : IStringEnum 
        {
            public const string Trial = "Trial";
            public const string Full = "Full";
        
            private string _value;
            
            public Type() {}
            
            public Type(string value)
            {
                _value = value;
            }
            
            public override string ToString()
            {
                return _value;
            }
            
            public static implicit operator Type(string value)
            {
                return new Type(value);
            }
            
            public static implicit operator string(Type value)
            {
                return value.ToString();
            }
            
            public void FromString(string value)
            {
                _value = value;
            }
        }
    
        /// <summary>
        /// Create a new Twilio Subaccount from the account making the request
        /// </summary>
        ///
        /// <returns> AccountCreator capable of executing the create </returns> 
        public static AccountCreator Creator()
        {
            return new AccountCreator();
        }
    
        /// <summary>
        /// Fetch the account specified by the provided Account Sid
        /// </summary>
        ///
        /// <returns> AccountFetcher capable of executing the fetch </returns> 
        public static AccountFetcher Fetcher()
        {
            return new AccountFetcher();
        }
    
        /// <summary>
        /// Retrieves a collection of Accounts belonging to the account used to make the request
        /// </summary>
        ///
        /// <returns> AccountReader capable of executing the read </returns> 
        public static AccountReader Reader()
        {
            return new AccountReader();
        }
    
        /// <summary>
        /// Modify the properties of a given Account
        /// </summary>
        ///
        /// <returns> AccountUpdater capable of executing the update </returns> 
        public static AccountUpdater Updater()
        {
            return new AccountUpdater();
        }
    
        /// <summary>
        /// Converts a JSON string into a AccountResource object
        /// </summary>
        ///
        /// <param name="json"> Raw JSON string </param>
        /// <returns> AccountResource object represented by the provided JSON </returns> 
        public static AccountResource FromJson(string json)
        {
            // Convert all checked exceptions to Runtime
            try
            {
                return JsonConvert.DeserializeObject<AccountResource>(json);
            }
            catch (JsonException e)
            {
                throw new ApiException(e.Message, e);
            }
        }
    
        [JsonProperty("auth_token")]
        public string authToken { get; set; }
        [JsonProperty("date_created")]
        public DateTime? dateCreated { get; set; }
        [JsonProperty("date_updated")]
        public DateTime? dateUpdated { get; set; }
        [JsonProperty("friendly_name")]
        public string friendlyName { get; set; }
        [JsonProperty("owner_account_sid")]
        public string ownerAccountSid { get; set; }
        [JsonProperty("sid")]
        public string sid { get; set; }
        [JsonProperty("status")]
        [JsonConverter(typeof(StringEnumConverter))]
        public AccountResource.Status status { get; set; }
        [JsonProperty("subresource_uris")]
        public Dictionary<string, string> subresourceUris { get; set; }
        [JsonProperty("type")]
        [JsonConverter(typeof(StringEnumConverter))]
        public AccountResource.Type type { get; set; }
        [JsonProperty("uri")]
        public string uri { get; set; }
    
        public AccountResource()
        {
        
        }
    
        private AccountResource([JsonProperty("auth_token")]
                                string authToken, 
                                [JsonProperty("date_created")]
                                string dateCreated, 
                                [JsonProperty("date_updated")]
                                string dateUpdated, 
                                [JsonProperty("friendly_name")]
                                string friendlyName, 
                                [JsonProperty("owner_account_sid")]
                                string ownerAccountSid, 
                                [JsonProperty("sid")]
                                string sid, 
                                [JsonProperty("status")]
                                AccountResource.Status status, 
                                [JsonProperty("subresource_uris")]
                                Dictionary<string, string> subresourceUris, 
                                [JsonProperty("type")]
                                AccountResource.Type type, 
                                [JsonProperty("uri")]
                                string uri)
                                {
            this.authToken = authToken;
            this.dateCreated = MarshalConverter.DateTimeFromString(dateCreated);
            this.dateUpdated = MarshalConverter.DateTimeFromString(dateUpdated);
            this.friendlyName = friendlyName;
            this.ownerAccountSid = ownerAccountSid;
            this.sid = sid;
            this.status = status;
            this.subresourceUris = subresourceUris;
            this.type = type;
            this.uri = uri;
        }
    }
}