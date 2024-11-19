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
            // Determine the response format from the Accept header
            var acceptHeader = context.Request.Headers["Accept"].ToString().ToLower();
            if (!acceptHeader.Contains("xml"))
            {
                await _next(context);
                return;
            }

            // Capture the original response body
            var originalBodyStream = context.Response.Body;

            try
            {
                using (var newBodyStream = new MemoryStream())
                {
                    context.Response.Body = newBodyStream;

                    await _next(context);

                    newBodyStream.Seek(0, SeekOrigin.Begin);
                    var jsonResponse = await new StreamReader(newBodyStream).ReadToEndAsync();

                    if (context.Response.StatusCode == (int)HttpStatusCode.OK)
                    {
                        // Convert JSON to XML
                        var xmlResponse = ConvertJsonToXml(jsonResponse);

                        if (xmlResponse != jsonResponse)
                        {
                            // Set the Content-Type to XML
                            context.Response.ContentType = "application/xml";

                            // Write the XML response to the original response stream
                            var xmlBytes = Encoding.UTF8.GetBytes(xmlResponse);
                            await originalBodyStream.WriteAsync(xmlBytes, 0, xmlBytes.Length);
                            return;
                        }
                    }

                    // Write the JSON response to the original response stream
                    var jsonBytes = Encoding.UTF8.GetBytes(jsonResponse);
                    await originalBodyStream.WriteAsync(jsonBytes, 0, jsonBytes.Length);
                }
            }
            catch(Exception)
            {
                throw;
            }
            finally
            {
                // Reset the body stream
                context.Response.Body = originalBodyStream;
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
