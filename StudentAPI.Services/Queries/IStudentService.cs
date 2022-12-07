using StudentAPI.DTOs.DTOs;
using StudentAPI.DTOs.Requests;

namespace StudentAPI.Services.Queries
{
    public interface IStudentService
    {
        public Task<UserInfoDTO> SearchAsync(GetUserRequest request);
    }
}
