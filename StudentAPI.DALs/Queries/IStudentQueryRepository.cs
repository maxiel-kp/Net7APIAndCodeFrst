using StudentAPI.Models;
using System.Linq.Expressions;

namespace StudentAPI.DALs.Queries
{
    public interface IStudentQueryRepository
    {
        public Task<Students> GetAsync(Expression<Func<Students, bool>> expression);
    }
}