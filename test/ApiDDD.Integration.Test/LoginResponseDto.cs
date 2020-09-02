using System;

namespace ApiDDD.Integration.Test
{
    public class LoginResponseDto
    {
        public bool Authenticated { get; set; }
        public DateTime Created { get; set; }
        public DateTime Expiration { get; set; }
        public string AcessToken { get; set; }
        public string UserName { get; set; }
        public string Message { get; set; }
    }
}
