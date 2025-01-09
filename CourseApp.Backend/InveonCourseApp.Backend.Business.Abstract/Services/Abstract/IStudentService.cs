namespace InveonCourseApp.Backend.Business.Abstract.Services.Abstract
{
    public interface IStudentService
    {
        Task<IDataResult<StudentDto>> AddAsync(StudentAddDto studentAddDto);

        Task<IDataResult<StudentDto>> GetByEmailAsync(string email);

        Task<IDataResult<StudentDto>> GetByIdAsync(Guid id);

        Task<IDataResult<StudentDto>> GetByIdentityIdAsync(Guid identityId);
    }
}