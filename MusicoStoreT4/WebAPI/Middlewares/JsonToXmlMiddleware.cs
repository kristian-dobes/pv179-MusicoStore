using Newtonsoft.Json;
using System.Net;
using System.Text;
using System.Xml;

namespace WebAPI.Middlewares
{
    public class JsonToXmlMiddleware
    {
        private readonly RequestDelegate _next;

        public JsonToXmlMiddleware(RequestDelegate next)
        {
            _next = next;
        }

        public async Task Invoke(HttpContext context)
        {
            // Capture the original response body
            var originalBodyStream = context.Response.Body;

            using (var newBodyStream = new MemoryStream())
            {
                context.Response.Body = newBodyStream;

                await _next(context);

                // Reset the body stream and read the response
                context.Response.Body = originalBodyStream;

                newBodyStream.Seek(0, SeekOrigin.Begin);
                var responseBody = await new StreamReader(newBodyStream).ReadToEndAsync();

                // Determine the response format from the Accept header
                var acceptHeader = context.Request.Headers["Accept"].ToString().ToLower();
                bool isXml = acceptHeader.Contains("xml");
                var formattedResponse = isXml ? ConvertJsonToXml(responseBody) : responseBody;

                context.Response.ContentType = isXml ? "application/xml" : "application/json";

                // Write the transformed response back to the original body stream
                await context.Response.WriteAsync(formattedResponse);
            }
        }

        private string ConvertJsonToXml(string jsonResponse)
        {
            try
            {
                // Wrap JSON in a root object if necessary for XML conversion
                var jsonWithRoot = "{\"data\":" + jsonResponse + "}";
                XmlDocument? xmlDocument = JsonConvert.DeserializeXmlNode(jsonWithRoot, "response");
                return xmlDocument?.OuterXml ?? jsonResponse; // Return the formatted XML
            }
            catch
            {
                return "<error>Invalid JSON format for XML conversion</error>";
            }
        }


    }
}
