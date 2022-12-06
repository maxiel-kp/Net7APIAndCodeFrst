using StudentAPI.DTOs.DTOs;
using StudentAPI.DTOs.Requests;

namespace StudentAPI.Services
{
    public interface IStudentService
    {
        public Task<UserInfoDTO> SearchAsync(GetUserRequest request);
    }
}
