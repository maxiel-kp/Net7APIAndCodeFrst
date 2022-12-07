using StudentAPI.DALs;
using StudentAPI.DALs.Queries;
using StudentAPI.DTOs.DTOs;
using StudentAPI.DTOs.Requests;
using StudentAPI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StudentAPI.Services.Queries
{
    public class StudentService : IStudentService
    {
        private readonly IStudentQueryRepository _repository;

        public StudentService(IStudentQueryRepository repository)
        {
            _repository = repository;
        }



        public async Task<UserInfoDTO> SearchAsync(GetUserRequest request)
        {
            var query = await _repository.GetAsync(w => w.Id == request.Id);

            var response = new UserInfoDTO()
            {
                Id = query.Id,
                FirstName = query.FirstName,
                Age = query.Age,
                Gender = query.Gender,
                LastName = query.LastName
            };

            return response;
        }
    }
}
