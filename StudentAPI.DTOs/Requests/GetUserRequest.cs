using MediatR;
using StudentAPI.DTOs.DTOs;

namespace StudentAPI.DTOs.Requests
{
    public class GetUserRequest : IRequest<UserInfoDTO>
    {
        public int Id { get; set; }
    }
}
