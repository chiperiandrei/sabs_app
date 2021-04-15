using MediatR;
using sabs_app_api.Models;
using System.Collections.Generic;

namespace sabs_app_api.DTOs
{
    public class GetUsers : IRequest<List<User>>
    {

    }
}