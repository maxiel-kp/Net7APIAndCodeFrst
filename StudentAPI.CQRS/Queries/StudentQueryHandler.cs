using MediatR;
using StudentAPI.DTOs.DTOs;
using StudentAPI.DTOs.Requests;
using StudentAPI.Services.Queries;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StudentAPI.CQRS.Queries
{
    public class StudentQueryHandler : IRequestHandler<GetUserRequest, UserInfoDTO>
    {
        private readonly IStudentService _service;

        public StudentQueryHandler(IStudentService service)
        {
            _service = service;
        }

        public async Task<UserInfoDTO> Handle(GetUserRequest request, CancellationToken cancellationToken)
        {
            var users = await _service.SearchAsync(request);
            return users;
        }
    }
}
