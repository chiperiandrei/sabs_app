

using MediatR;

namespace sabs_app_api.DTOs
{
    public class ResponseLogin : IRequest<ResponseLogin>
    {
        public string Token { get; set; }
        public ResponseLogin(string token)
        {
            Token = token;
        }
    }
}