using MediatR;
using System.Collections.Generic;

namespace sabs_app_api.DTOs
{
    public class GetUsers : IRequest<List<UserResponse>>
    {

    }
}