using MediatR;
using sabs_app_api.Models;

namespace sabs_app_api.DTOs
{
    public class AddIPAdress : IRequest<IPAdress>
    {
        public string Email { get; set; }
        public string IPAdress { get; set; }
    }

}
