using MediatR;
using StudentAPI.DALs.Queries;
using StudentAPI.DTOs.Responses;
using StudentAPI.DTOs.Requests;

namespace StudentAPI.CQRS.Queries
{
    public class StudentOnlyQueryHandler : IRequestHandler<GetStudentRequest, List<GetStudentResponse>>
    {
        private readonly IStudentQueryRepository _repository;

        public StudentOnlyQueryHandler(IStudentQueryRepository repository)
        {
            _repository = repository;
        }

        public async Task<List<GetStudentResponse>> Handle(GetStudentRequest request, CancellationToken cancellationToken)
        {
            var students = await _repository.GetAllAsync();
            return students.Select(s => new GetStudentResponse
            {
                Age = s.Age,
                FirstName = s.FirstName,
                Gender = s.Gender,
                Id = s.Id,
                LastName = s.LastName
            }).ToList();
        }
    }
}
