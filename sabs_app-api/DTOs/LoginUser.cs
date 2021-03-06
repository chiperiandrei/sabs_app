using MediatR;

namespace sabs_app_api.DTOs
{
    public class LoginUser : IRequest<ResponseLogin>
    {
        public string Email { get; set; }
        public string Password { get; set; }
    }
}