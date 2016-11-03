using Newtonsoft.Json;
using System;
using Twilio.Base;
using Twilio.Clients;
using Twilio.Converters;
using Twilio.Exceptions;
using Twilio.Http;
using Twilio.Types;

namespace Twilio.Rest.Api.V2010.Account.AvailablePhoneNumberCountry 
{

    public class TollFreeResource : Resource 
    {
        /// <summary>
        /// read
        /// </summary>
        ///
        /// <param name="countryCode"> The country_code </param>
        /// <returns> TollFreeReader capable of executing the read </returns> 
        public static TollFreeReader Reader(string countryCode)
        {
            return new TollFreeReader(countryCode);
        }
    
        /// <summary>
        /// Converts a JSON string into a TollFreeResource object
        /// </summary>
        ///
        /// <param name="json"> Raw JSON string </param>
        /// <returns> TollFreeResource object represented by the provided JSON </returns> 
        public static TollFreeResource FromJson(string json)
        {
            // Convert all checked exceptions to Runtime
            try
            {
                return JsonConvert.DeserializeObject<TollFreeResource>(json);
            }
            catch (JsonException e)
            {
                throw new ApiException(e.Message, e);
            }
        }
    
        [JsonProperty("friendly_name")]
        [JsonConverter(typeof(PhoneNumberConverter))]
        public Twilio.Types.PhoneNumber friendlyName { get; set; }
        [JsonProperty("phone_number")]
        [JsonConverter(typeof(PhoneNumberConverter))]
        public Twilio.Types.PhoneNumber phoneNumber { get; set; }
        [JsonProperty("lata")]
        public string lata { get; set; }
        [JsonProperty("rate_center")]
        public string rateCenter { get; set; }
        [JsonProperty("latitude")]
        public decimal? latitude { get; set; }
        [JsonProperty("longitude")]
        public decimal? longitude { get; set; }
        [JsonProperty("region")]
        public string region { get; set; }
        [JsonProperty("postal_code")]
        public string postalCode { get; set; }
        [JsonProperty("iso_country")]
        public string isoCountry { get; set; }
        [JsonProperty("address_requirements")]
        public string addressRequirements { get; set; }
        [JsonProperty("beta")]
        public bool? beta { get; set; }
        [JsonProperty("capabilities")]
        public PhoneNumberCapabilities capabilities { get; set; }
    
        public TollFreeResource()
        {
        
        }
    
        private TollFreeResource([JsonProperty("friendly_name")]
                                 Twilio.Types.PhoneNumber friendlyName, 
                                 [JsonProperty("phone_number")]
                                 Twilio.Types.PhoneNumber phoneNumber, 
                                 [JsonProperty("lata")]
                                 string lata, 
                                 [JsonProperty("rate_center")]
                                 string rateCenter, 
                                 [JsonProperty("latitude")]
                                 decimal? latitude, 
                                 [JsonProperty("longitude")]
                                 decimal? longitude, 
                                 [JsonProperty("region")]
                                 string region, 
                                 [JsonProperty("postal_code")]
                                 string postalCode, 
                                 [JsonProperty("iso_country")]
                                 string isoCountry, 
                                 [JsonProperty("address_requirements")]
                                 string addressRequirements, 
                                 [JsonProperty("beta")]
                                 bool? beta, 
                                 [JsonProperty("capabilities")]
                                 PhoneNumberCapabilities capabilities)
                                 {
            this.friendlyName = friendlyName;
            this.phoneNumber = phoneNumber;
            this.lata = lata;
            this.rateCenter = rateCenter;
            this.latitude = latitude;
            this.longitude = longitude;
            this.region = region;
            this.postalCode = postalCode;
            this.isoCountry = isoCountry;
            this.addressRequirements = addressRequirements;
            this.beta = beta;
            this.capabilities = capabilities;
        }
    }
}