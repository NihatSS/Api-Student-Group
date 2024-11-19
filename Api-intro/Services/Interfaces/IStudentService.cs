using Api_intro.DTOs.Students;
using Api_intro.Models;

namespace Api_intro.Services.Interfaces
{
    public interface IStudentService
    {
        Task<IEnumerable<Student>> GetAllAsync();
        Task<Student> GetByIdAsync(int id);
        Task Create(StudentCreateDto student);
        Task Delete(int id);
        Task Edit(int id, StudentEditDto student);
    }
}
