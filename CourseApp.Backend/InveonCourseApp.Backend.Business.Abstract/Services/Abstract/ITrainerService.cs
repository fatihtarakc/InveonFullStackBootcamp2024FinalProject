namespace InveonCourseApp.Backend.Business.Abstract.Services.Abstract
{
    public interface ITrainerService
    {
        Task<IDataResult<TrainerDto>> AddAsync(TrainerAddDto trainerAddDto);

        Task<IDataResult<TrainerDto>> GetByEmailAsync(string email);

        Task<IDataResult<TrainerDto>> GetByIdAsync(Guid id);

        Task<IDataResult<TrainerDto>> GetByIdentityIdAsync(Guid identityId);
    }
}