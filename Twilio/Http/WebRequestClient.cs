﻿using System;
using System.IO;
using System.Net;
using System.Reflection;
using System.Diagnostics;
using Twilio.Exceptions;
using Newtonsoft.Json;

#if NET40
using System.Threading.Tasks;
#endif

namespace Twilio.Http
{
    public class WebRequestClient : HttpClient
    {
        private static Exception HandleErrorResponse(HttpWebResponse errorResponse)
        {
            if (errorResponse.StatusCode >= HttpStatusCode.InternalServerError &&
                errorResponse.StatusCode < HttpStatusCode.HttpVersionNotSupported)
            {
                return new TwilioException("Internal Server error: " + errorResponse.StatusDescription);
            }

            var responseStream = errorResponse.GetResponseStream();
            var errorReader = new StreamReader(responseStream);
            var errorContent = errorReader.ReadToEnd();

            try
            {
                var restEx = RestException.FromJson(errorContent);
                return restEx ?? new TwilioException("Error: " + errorResponse.StatusDescription + " - " + errorContent);
            }
            catch (JsonReaderException)
            {
                return new TwilioException("Error: " + errorResponse.StatusDescription + " - " + errorContent);
            }
        }

        public override Response MakeRequest(Request request, IWebProxy proxy)
        {
            HttpWebRequest httpRequest = (HttpWebRequest)WebRequest.Create(request.ConstructUrl());

#if !__MonoCS__
            PropertyInfo property = typeof(HttpWebRequest).GetRuntimeProperty("UserAgent");
            var version = AssemblyInfomation.AssemblyInformationalVersion;
            string platVersion = null;
#if NET40
			platVersion = " (.NET 4+)";
#elif NET35
            platVersion = " (.NET 3.5)";
#endif
            string libraryVersion = "twilio-csharp/" + version + platVersion;
            property.SetValue(httpRequest, libraryVersion, null);
#endif

            httpRequest.Method = request.Method.ToString();
            httpRequest.Accept = "application/json";
            httpRequest.Headers["Accept-Encoding"] = "utf-8";
            if (proxy != null) httpRequest.Proxy = proxy;

            var authBytes = Authentication(request.Username, request.Password);
            httpRequest.Headers["Authorization"] = "Basic " + authBytes;
            httpRequest.ContentType = "application/x-www-form-urlencoded";

            if (!Equals(request.Method, HttpMethod.Get))
            {
                var stream = GetStream(httpRequest);
                stream.Write(request.EncodePostParams(), 0, request.EncodePostParams().Length);
            }

            try
            {
                var response = GetResponse(httpRequest);
                var reader = new StreamReader(response.GetResponseStream());
                return new Response(response.StatusCode, reader.ReadToEnd());
            }
#if NET40
			catch (AggregateException ae)
			{
				ae.Handle ((x) => {
				    if (!(x is WebException))
				    {
				        return false;
				    }

				    var e = (WebException) x;
				    throw HandleErrorResponse((HttpWebResponse) e.Response);
				});
			    return null;
			}
#else
            catch (WebException e)
            {
                throw HandleErrorResponse((HttpWebResponse)e.Response);
            }
#endif
        }

        private static Stream GetStream(WebRequest request)
        {
#if NET40
	        var streamTask = Task.Factory.FromAsync<Stream>(
	            request.BeginGetRequestStream,
	            request.EndGetRequestStream,
	            null
	        );
	        streamTask.Wait();
#endif

#if NET40
	        return streamTask.Result;
#else
            return request.GetRequestStream();
#endif
        }

        private static HttpWebResponse GetResponse(WebRequest request)
        {
#if NET40
	        var responseTask = Task.Factory.FromAsync<System.Net.WebResponse>(
	            request.BeginGetResponse,
	            request.EndGetResponse,
	            null
	        );
	        responseTask.Wait();
	        return (HttpWebResponse) responseTask.Result;
#else
            return (HttpWebResponse)request.GetResponse();
#endif
        }
    }
}
