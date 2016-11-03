using Newtonsoft.Json;
using System;
using Twilio.Base;
using Twilio.Clients;
using Twilio.Converters;
using Twilio.Exceptions;
using Twilio.Http;

namespace Twilio.Rest.Api.V2010.Account.Sip.CredentialList 
{

    public class CredentialResource : Resource 
    {
        /// <summary>
        /// read
        /// </summary>
        ///
        /// <param name="credentialListSid"> The credential_list_sid </param>
        /// <returns> CredentialReader capable of executing the read </returns> 
        public static CredentialReader Reader(string credentialListSid)
        {
            return new CredentialReader(credentialListSid);
        }
    
        /// <summary>
        /// create
        /// </summary>
        ///
        /// <param name="credentialListSid"> The credential_list_sid </param>
        /// <param name="username"> The username </param>
        /// <param name="password"> The password </param>
        /// <returns> CredentialCreator capable of executing the create </returns> 
        public static CredentialCreator Creator(string credentialListSid, string username, string password)
        {
            return new CredentialCreator(credentialListSid, username, password);
        }
    
        /// <summary>
        /// fetch
        /// </summary>
        ///
        /// <param name="credentialListSid"> The credential_list_sid </param>
        /// <param name="sid"> The sid </param>
        /// <returns> CredentialFetcher capable of executing the fetch </returns> 
        public static CredentialFetcher Fetcher(string credentialListSid, string sid)
        {
            return new CredentialFetcher(credentialListSid, sid);
        }
    
        /// <summary>
        /// update
        /// </summary>
        ///
        /// <param name="credentialListSid"> The credential_list_sid </param>
        /// <param name="sid"> The sid </param>
        /// <returns> CredentialUpdater capable of executing the update </returns> 
        public static CredentialUpdater Updater(string credentialListSid, string sid)
        {
            return new CredentialUpdater(credentialListSid, sid);
        }
    
        /// <summary>
        /// delete
        /// </summary>
        ///
        /// <param name="credentialListSid"> The credential_list_sid </param>
        /// <param name="sid"> The sid </param>
        /// <returns> CredentialDeleter capable of executing the delete </returns> 
        public static CredentialDeleter Deleter(string credentialListSid, string sid)
        {
            return new CredentialDeleter(credentialListSid, sid);
        }
    
        /// <summary>
        /// Converts a JSON string into a CredentialResource object
        /// </summary>
        ///
        /// <param name="json"> Raw JSON string </param>
        /// <returns> CredentialResource object represented by the provided JSON </returns> 
        public static CredentialResource FromJson(string json)
        {
            // Convert all checked exceptions to Runtime
            try
            {
                return JsonConvert.DeserializeObject<CredentialResource>(json);
            }
            catch (JsonException e)
            {
                throw new ApiException(e.Message, e);
            }
        }
    
        [JsonProperty("sid")]
        public string sid { get; set; }
        [JsonProperty("account_sid")]
        public string accountSid { get; set; }
        [JsonProperty("credential_list_sid")]
        public string credentialListSid { get; set; }
        [JsonProperty("username")]
        public string username { get; set; }
        [JsonProperty("date_created")]
        public DateTime? dateCreated { get; set; }
        [JsonProperty("date_updated")]
        public DateTime? dateUpdated { get; set; }
        [JsonProperty("uri")]
        public string uri { get; set; }
    
        public CredentialResource()
        {
        
        }
    
        private CredentialResource([JsonProperty("sid")]
                                   string sid, 
                                   [JsonProperty("account_sid")]
                                   string accountSid, 
                                   [JsonProperty("credential_list_sid")]
                                   string credentialListSid, 
                                   [JsonProperty("username")]
                                   string username, 
                                   [JsonProperty("date_created")]
                                   string dateCreated, 
                                   [JsonProperty("date_updated")]
                                   string dateUpdated, 
                                   [JsonProperty("uri")]
                                   string uri)
                                   {
            this.sid = sid;
            this.accountSid = accountSid;
            this.credentialListSid = credentialListSid;
            this.username = username;
            this.dateCreated = MarshalConverter.DateTimeFromString(dateCreated);
            this.dateUpdated = MarshalConverter.DateTimeFromString(dateUpdated);
            this.uri = uri;
        }
    }
}