using MediatR;
using StudentAPI.DTOs.Responses;

namespace StudentAPI.DTOs.Requests
{
    public class GetStudentRequest :  IRequest<List<GetStudentResponse>>
    {

    }

    public class GetStudentProcRequest : IRequest<List<GetStudentProcResponse>>
    {

    }
}
