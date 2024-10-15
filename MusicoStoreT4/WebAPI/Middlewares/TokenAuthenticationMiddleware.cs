namespace WebAPI.Middlewares
{
    public class TokenAuthenticationMiddleware
    {
        private readonly RequestDelegate _next;
        private readonly string _validToken = "YourHardcodedToken"; // Hardcoded token

        public TokenAuthenticationMiddleware(RequestDelegate next)
        {
            _next = next;
        }

        public async Task Invoke(HttpContext context)
        {
            // Check if the Authorization header exists
            if (context.Request.Headers.ContainsKey("Authorization"))
            {
                // Extract the token from the Authorization header (expected format: "Bearer YourHardcodedToken")
                var token = context.Request.Headers["Authorization"].ToString().Split(" ")[1];

                // If the token matches the valid token, allow the request to proceed
                if (token == _validToken)
                {
                    await _next(context);
                    return;
                }
            }

            // If the token is invalid or missing, return 401 Unauthorized
            context.Response.StatusCode = StatusCodes.Status401Unauthorized;
            await context.Response.WriteAsync("Unauthorized");
        }
    }
}
