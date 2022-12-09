using Microsoft.EntityFrameworkCore;
using StudentAPI.Models;
using System.Linq.Expressions;

namespace StudentAPI.DALs.Queries
{
    public class StudentQueryRepository : IStudentQueryRepository
    {
        private readonly PracticeDbContext _dbContext;

        public StudentQueryRepository(PracticeDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<Students> GetAsync(Expression<Func<Students, bool>> expression)
        => await _dbContext.Set<Students>(). FirstOrDefaultAsync(expression);

        public async Task<List<Students>> GetAllAsync()
        => await _dbContext.Students.ToListAsync();

        public async Task<IQueryable<Students>> GetByProcAsync()
        {
            var students = _dbContext.Students.FromSqlRaw<Students>("exec GetStudents");
            return students;
        }
    }
}
