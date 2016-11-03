using Newtonsoft.Json;
using System;
using Twilio.Base;
using Twilio.Clients;
using Twilio.Converters;
using Twilio.Exceptions;
using Twilio.Http;

namespace Twilio.Rest.Api.V2010.Account 
{

    public class QueueResource : Resource 
    {
        /// <summary>
        /// Fetch an instance of a queue identified by the QueueSid
        /// </summary>
        ///
        /// <param name="sid"> Fetch by unique queue Sid </param>
        /// <returns> QueueFetcher capable of executing the fetch </returns> 
        public static QueueFetcher Fetcher(string sid)
        {
            return new QueueFetcher(sid);
        }
    
        /// <summary>
        /// Update the queue with the new parameters
        /// </summary>
        ///
        /// <param name="sid"> The sid </param>
        /// <returns> QueueUpdater capable of executing the update </returns> 
        public static QueueUpdater Updater(string sid)
        {
            return new QueueUpdater(sid);
        }
    
        /// <summary>
        /// Remove an empty queue
        /// </summary>
        ///
        /// <param name="sid"> Delete by unique queue Sid </param>
        /// <returns> QueueDeleter capable of executing the delete </returns> 
        public static QueueDeleter Deleter(string sid)
        {
            return new QueueDeleter(sid);
        }
    
        /// <summary>
        /// Retrieve a list of queues belonging to the account used to make the request
        /// </summary>
        ///
        /// <returns> QueueReader capable of executing the read </returns> 
        public static QueueReader Reader()
        {
            return new QueueReader();
        }
    
        /// <summary>
        /// Create a queue
        /// </summary>
        ///
        /// <returns> QueueCreator capable of executing the create </returns> 
        public static QueueCreator Creator()
        {
            return new QueueCreator();
        }
    
        /// <summary>
        /// Converts a JSON string into a QueueResource object
        /// </summary>
        ///
        /// <param name="json"> Raw JSON string </param>
        /// <returns> QueueResource object represented by the provided JSON </returns> 
        public static QueueResource FromJson(string json)
        {
            // Convert all checked exceptions to Runtime
            try
            {
                return JsonConvert.DeserializeObject<QueueResource>(json);
            }
            catch (JsonException e)
            {
                throw new ApiException(e.Message, e);
            }
        }
    
        [JsonProperty("account_sid")]
        public string accountSid { get; set; }
        [JsonProperty("average_wait_time")]
        public int? averageWaitTime { get; set; }
        [JsonProperty("current_size")]
        public int? currentSize { get; set; }
        [JsonProperty("date_created")]
        public DateTime? dateCreated { get; set; }
        [JsonProperty("date_updated")]
        public DateTime? dateUpdated { get; set; }
        [JsonProperty("friendly_name")]
        public string friendlyName { get; set; }
        [JsonProperty("max_size")]
        public int? maxSize { get; set; }
        [JsonProperty("sid")]
        public string sid { get; set; }
        [JsonProperty("uri")]
        public string uri { get; set; }
    
        public QueueResource()
        {
        
        }
    
        private QueueResource([JsonProperty("account_sid")]
                              string accountSid, 
                              [JsonProperty("average_wait_time")]
                              int? averageWaitTime, 
                              [JsonProperty("current_size")]
                              int? currentSize, 
                              [JsonProperty("date_created")]
                              string dateCreated, 
                              [JsonProperty("date_updated")]
                              string dateUpdated, 
                              [JsonProperty("friendly_name")]
                              string friendlyName, 
                              [JsonProperty("max_size")]
                              int? maxSize, 
                              [JsonProperty("sid")]
                              string sid, 
                              [JsonProperty("uri")]
                              string uri)
                              {
            this.accountSid = accountSid;
            this.averageWaitTime = averageWaitTime;
            this.currentSize = currentSize;
            this.dateCreated = MarshalConverter.DateTimeFromString(dateCreated);
            this.dateUpdated = MarshalConverter.DateTimeFromString(dateUpdated);
            this.friendlyName = friendlyName;
            this.maxSize = maxSize;
            this.sid = sid;
            this.uri = uri;
        }
    }
}