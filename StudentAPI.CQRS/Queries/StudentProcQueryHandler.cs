using MediatR;
using StudentAPI.DALs.Queries;
using StudentAPI.DTOs.Requests;
using StudentAPI.DTOs.Responses;

namespace StudentAPI.CQRS.Queries
{
    public class StudentProcQueryHandler : IRequestHandler<GetStudentProcRequest, List<GetStudentProcResponse>>
    {

        private readonly IStudentQueryRepository _repository;

        public StudentProcQueryHandler(IStudentQueryRepository repository)
        {
            _repository = repository;
        }

        public async Task<List<GetStudentProcResponse>> Handle(GetStudentProcRequest request, CancellationToken cancellationToken)
        {
            var student = await _repository.GetByProcAsync();
            return student.AsEnumerable().Select(s => new GetStudentProcResponse
            {
                Age = s.Age,
                FirstName= s.FirstName,
                Gender= s.Gender,
                Id= s.Id,
                LastName = s.LastName
            }).ToList();
        }
    }
}
