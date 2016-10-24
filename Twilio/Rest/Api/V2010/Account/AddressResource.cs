using Newtonsoft.Json;
using System;
using Twilio.Base;
using Twilio.Clients;
using Twilio.Converters;
using Twilio.Exceptions;
using Twilio.Http;

namespace Twilio.Rest.Api.V2010.Account {

    public class AddressResource : Resource {
        /// <summary>
        /// create
        /// </summary>
        ///
        /// <param name="accountSid"> The account_sid </param>
        /// <param name="customerName"> The customer_name </param>
        /// <param name="street"> The street </param>
        /// <param name="city"> The city </param>
        /// <param name="region"> The region </param>
        /// <param name="postalCode"> The postal_code </param>
        /// <param name="isoCountry"> The iso_country </param>
        /// <returns> AddressCreator capable of executing the create </returns> 
        public static AddressCreator Creator(string accountSid, string customerName, string street, string city, string region, string postalCode, string isoCountry) {
            return new AddressCreator(accountSid, customerName, street, city, region, postalCode, isoCountry);
        }
    
        /// <summary>
        /// Create a AddressCreator to execute create.
        /// </summary>
        ///
        /// <param name="customerName"> The customer_name </param>
        /// <param name="street"> The street </param>
        /// <param name="city"> The city </param>
        /// <param name="region"> The region </param>
        /// <param name="postalCode"> The postal_code </param>
        /// <param name="isoCountry"> The iso_country </param>
        /// <returns> AddressCreator capable of executing the create </returns> 
        public static AddressCreator Creator(string customerName, 
                                             string street, 
                                             string city, 
                                             string region, 
                                             string postalCode, 
                                             string isoCountry) {
            return new AddressCreator(customerName, street, city, region, postalCode, isoCountry);
        }
    
        /// <summary>
        /// delete
        /// </summary>
        ///
        /// <param name="accountSid"> The account_sid </param>
        /// <param name="sid"> The sid </param>
        /// <returns> AddressDeleter capable of executing the delete </returns> 
        public static AddressDeleter Deleter(string accountSid, string sid) {
            return new AddressDeleter(accountSid, sid);
        }
    
        /// <summary>
        /// Create a AddressDeleter to execute delete.
        /// </summary>
        ///
        /// <param name="sid"> The sid </param>
        /// <returns> AddressDeleter capable of executing the delete </returns> 
        public static AddressDeleter Deleter(string sid) {
            return new AddressDeleter(sid);
        }
    
        /// <summary>
        /// fetch
        /// </summary>
        ///
        /// <param name="accountSid"> The account_sid </param>
        /// <param name="sid"> The sid </param>
        /// <returns> AddressFetcher capable of executing the fetch </returns> 
        public static AddressFetcher Fetcher(string accountSid, string sid) {
            return new AddressFetcher(accountSid, sid);
        }
    
        /// <summary>
        /// Create a AddressFetcher to execute fetch.
        /// </summary>
        ///
        /// <param name="sid"> The sid </param>
        /// <returns> AddressFetcher capable of executing the fetch </returns> 
        public static AddressFetcher Fetcher(string sid) {
            return new AddressFetcher(sid);
        }
    
        /// <summary>
        /// update
        /// </summary>
        ///
        /// <param name="accountSid"> The account_sid </param>
        /// <param name="sid"> The sid </param>
        /// <returns> AddressUpdater capable of executing the update </returns> 
        public static AddressUpdater Updater(string accountSid, string sid) {
            return new AddressUpdater(accountSid, sid);
        }
    
        /// <summary>
        /// Create a AddressUpdater to execute update.
        /// </summary>
        ///
        /// <param name="sid"> The sid </param>
        /// <returns> AddressUpdater capable of executing the update </returns> 
        public static AddressUpdater Updater(string sid) {
            return new AddressUpdater(sid);
        }
    
        /// <summary>
        /// read
        /// </summary>
        ///
        /// <param name="accountSid"> The account_sid </param>
        /// <returns> AddressReader capable of executing the read </returns> 
        public static AddressReader Reader(string accountSid) {
            return new AddressReader(accountSid);
        }
    
        /// <summary>
        /// Create a AddressReader to execute read.
        /// </summary>
        ///
        /// <returns> AddressReader capable of executing the read </returns> 
        public static AddressReader Reader() {
            return new AddressReader();
        }
    
        /// <summary>
        /// Converts a JSON string into a AddressResource object
        /// </summary>
        ///
        /// <param name="json"> Raw JSON string </param>
        /// <returns> AddressResource object represented by the provided JSON </returns> 
        public static AddressResource FromJson(string json) {
            // Convert all checked exceptions to Runtime
            try {
                return JsonConvert.DeserializeObject<AddressResource>(json);
            } catch (JsonException e) {
                throw new ApiException(e.Message, e);
            }
        }
    
        [JsonProperty("account_sid")]
        public string accountSid { get; }
        [JsonProperty("city")]
        public string city { get; }
        [JsonProperty("customer_name")]
        public string customerName { get; }
        [JsonProperty("date_created")]
        public DateTime? dateCreated { get; }
        [JsonProperty("date_updated")]
        public DateTime? dateUpdated { get; }
        [JsonProperty("friendly_name")]
        public string friendlyName { get; }
        [JsonProperty("iso_country")]
        public string isoCountry { get; }
        [JsonProperty("postal_code")]
        public string postalCode { get; }
        [JsonProperty("region")]
        public string region { get; }
        [JsonProperty("sid")]
        public string sid { get; }
        [JsonProperty("street")]
        public string street { get; }
        [JsonProperty("uri")]
        public string uri { get; }
    
        public AddressResource() {
        
        }
    
        private AddressResource([JsonProperty("account_sid")]
                                string accountSid, 
                                [JsonProperty("city")]
                                string city, 
                                [JsonProperty("customer_name")]
                                string customerName, 
                                [JsonProperty("date_created")]
                                string dateCreated, 
                                [JsonProperty("date_updated")]
                                string dateUpdated, 
                                [JsonProperty("friendly_name")]
                                string friendlyName, 
                                [JsonProperty("iso_country")]
                                string isoCountry, 
                                [JsonProperty("postal_code")]
                                string postalCode, 
                                [JsonProperty("region")]
                                string region, 
                                [JsonProperty("sid")]
                                string sid, 
                                [JsonProperty("street")]
                                string street, 
                                [JsonProperty("uri")]
                                string uri) {
            this.accountSid = accountSid;
            this.city = city;
            this.customerName = customerName;
            this.dateCreated = MarshalConverter.DateTimeFromString(dateCreated);
            this.dateUpdated = MarshalConverter.DateTimeFromString(dateUpdated);
            this.friendlyName = friendlyName;
            this.isoCountry = isoCountry;
            this.postalCode = postalCode;
            this.region = region;
            this.sid = sid;
            this.street = street;
            this.uri = uri;
        }
    }
}