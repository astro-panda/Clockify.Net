using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Net;
using System.Net.Http;
using Clockify.Net.Models.TimeEntries;
using RestSharp;

namespace Clockify.Net.Models {
    [DebuggerDisplay("{" + nameof(DebuggerDisplay) + "()}")]
    public class Response<T> : Response {
        /// <summary>
        /// Deserialized entity data
        /// </summary>
        public T? Data { get; internal set; }

        public static Response<T> FromRestResponse(RestResponse<T> restResponse) => new() {
            Data = restResponse.Data,
            Content = restResponse.Content,
            RawBytes = restResponse.RawBytes,
            ContentEncoding = restResponse.ContentEncoding,
            ContentLength = restResponse.ContentLength,
            ContentType = restResponse.ContentType,
            Cookies = restResponse.Cookies,
            ErrorMessage = restResponse.ErrorMessage,
            ErrorException = restResponse.ErrorException,
            Headers = restResponse.Headers,
            ContentHeaders = restResponse.ContentHeaders,
            IsSuccessful = restResponse.IsSuccessful,
            ResponseStatus = restResponse.ResponseStatus,
            ResponseUri = restResponse.ResponseUri,
            Server = restResponse.Server,
            StatusCode = restResponse.StatusCode,
            StatusDescription = restResponse.StatusDescription,
            Request = restResponse.Request,
            RootElement = restResponse.RootElement
        };

        public Response(Response restResponse) : base(restResponse) { }

        public Response() { }
    }

    public class Response {
        public Response(Response restResponse) {
            Content = restResponse.Content;
            RawBytes = restResponse.RawBytes;
            ContentEncoding = restResponse.ContentEncoding;
            ContentLength = restResponse.ContentLength;
            ContentType = restResponse.ContentType;
            Cookies = restResponse.Cookies;
            ErrorMessage = restResponse.ErrorMessage;
            ErrorException = restResponse.ErrorException;
            Headers = restResponse.Headers;
            ContentHeaders = restResponse.ContentHeaders;
            IsSuccessful = restResponse.IsSuccessful;
            ResponseStatus = restResponse.ResponseStatus;
            ResponseUri = restResponse.ResponseUri;
            Server = restResponse.Server;
            StatusCode = restResponse.StatusCode;
            StatusDescription = restResponse.StatusDescription;
            Request = restResponse.Request;
            RootElement = restResponse.RootElement;
        }

        public Response() { }

        public static Response FromRestResponse(RestResponse restResponse)
            => new() {
                Content = restResponse.Content,
                RawBytes = restResponse.RawBytes,
                ContentEncoding = restResponse.ContentEncoding,
                ContentLength = restResponse.ContentLength,
                ContentType = restResponse.ContentType,
                Cookies = restResponse.Cookies,
                ErrorMessage = restResponse.ErrorMessage,
                ErrorException = restResponse.ErrorException,
                Headers = restResponse.Headers,
                ContentHeaders = restResponse.ContentHeaders,
                IsSuccessful = restResponse.IsSuccessful,
                ResponseStatus = restResponse.ResponseStatus,
                ResponseUri = restResponse.ResponseUri,
                Server = restResponse.Server,
                StatusCode = restResponse.StatusCode,
                StatusDescription = restResponse.StatusDescription,
                Request = restResponse.Request,
                RootElement = restResponse.RootElement
            };

        /// <summary>
        /// The RestRequest that was made to get this Response
        /// </summary>
        /// <remarks>
        /// Mainly for debugging if ResponseStatus is not OK
        /// </remarks>
        public RestRequest? Request { get; set; }

        /// <summary>
        /// MIME content type of response
        /// </summary>
        public string? ContentType { get; internal set; }

        /// <summary>
        /// Length in bytes of the response content
        /// </summary>
        public long? ContentLength { get; internal set; }

        /// <summary>
        /// Encoding of the response content
        /// </summary>
        public ICollection<string> ContentEncoding { get; internal set; } = new List<string>();

        /// <summary>
        /// String representation of response content
        /// </summary>
        public string? Content { get; internal set; }

        /// <summary>
        /// HTTP response status code
        /// </summary>
        public HttpStatusCode StatusCode { get; internal set; }

        /// <summary>
        /// Whether or not the response status code indicates success
        /// </summary>
        public bool IsSuccessful { get; internal set; }

        /// <summary>
        /// Description of HTTP status returned
        /// </summary>
        public string? StatusDescription { get; internal set; }

        /// <summary>
        /// Response content
        /// </summary>
        public byte[]? RawBytes { get; internal set; }

        /// <summary>
        /// The URL that actually responded to the content (different from request if redirected)
        /// </summary>
        public Uri? ResponseUri { get; internal set; }

        /// <summary>
        /// HttpWebResponse.Server
        /// </summary>
        public string? Server { get; internal set; }

        /// <summary>
        /// Cookies returned by server with the response
        /// </summary>
        public CookieCollection? Cookies { get; internal set; }

        /// <summary>
        /// Response headers returned by server with the response
        /// </summary>
        public IReadOnlyCollection<HeaderParameter>? Headers { get; internal set; }

        /// <summary>
        /// Content headers returned by server with the response
        /// </summary>
        public IReadOnlyCollection<HeaderParameter>? ContentHeaders { get; internal set; }

        /// <summary>
        /// Status of the request. Will return Error for transport errors.
        /// HTTP errors will still return ResponseStatus.Completed, check StatusCode instead
        /// </summary>
        public ResponseStatus ResponseStatus { get; set; }

        /// <summary>
        /// Transport or other non-HTTP error generated while attempting request
        /// </summary>
        public string? ErrorMessage { get; set; }

        /// <summary>
        /// The exception thrown during the request, if any
        /// </summary>
        public Exception? ErrorException { get; set; }

        /// <summary>
        /// HTTP protocol version of the request
        /// </summary>
        public Version? Version { get; set; }

        /// <summary>
        /// Root element of the serialized response content, only works if deserializer supports it 
        /// </summary>
        public string? RootElement { get; set; }

        /// <summary>
        /// Assists with debugging responses by displaying in the debugger output
        /// </summary>
        /// <returns></returns>
        protected string DebuggerDisplay()
            => $"StatusCode: {StatusCode}, Content-Type: {ContentType}, Content-Length: {ContentLength})";

        internal Exception? GetException()
            => ResponseStatus switch {
                ResponseStatus.Aborted => new HttpRequestException("Request aborted", ErrorException),
                ResponseStatus.Error => ErrorException,
                ResponseStatus.TimedOut => new TimeoutException("Request timed out", ErrorException),
                ResponseStatus.None => null,
                ResponseStatus.Completed => null,
                _ => throw ErrorException ?? new ArgumentOutOfRangeException(nameof(ResponseStatus))
            };
    }
}