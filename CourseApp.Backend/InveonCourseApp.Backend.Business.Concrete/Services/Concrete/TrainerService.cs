namespace InveonCourseApp.Backend.Business.Concrete.Services.Concrete
{
    public class TrainerService : ITrainerService
    {
        private readonly ITrainerRepository trainerRepository;
        private readonly IStringLocalizer<MessageResources> stringLocalizer;
        private readonly ILogger<TrainerService> logger;
        public TrainerService(ITrainerRepository trainerRepository, IStringLocalizer<MessageResources> stringLocalizer, ILogger<TrainerService> logger)
        {
            this.trainerRepository = trainerRepository;
            this.stringLocalizer = stringLocalizer;
            this.logger = logger;
        }

        public async Task<IDataResult<TrainerDto>> GetByIdAsync(Guid id) =>
        await trainerRepository.GetByIdAsync(id) is null ? new ErrorDataResult<TrainerDto>(stringLocalizer[Message.Trainer_Was_Not_Found_ById]) : new SuccessDataResult<TrainerDto>((await trainerRepository.GetByIdAsync(id)).Adapt<TrainerDto>(), stringLocalizer[Message.Trainer_Was_Found_ById]);

        public async Task<IDataResult<TrainerDto>> GetByEmailAsync(string email) =>
        await trainerRepository.GetFirstOrDefaultAsync(trainer => trainer.Email == email) is null ? new ErrorDataResult<TrainerDto>(stringLocalizer[Message.Trainer_Was_Not_Found_ByEmail]) : new SuccessDataResult<TrainerDto>((await trainerRepository.GetFirstOrDefaultAsync(trainer => trainer.Email == email)).Adapt<TrainerDto>(), stringLocalizer[Message.Trainer_Was_Found_ByEmail]);
        public async Task<IDataResult<TrainerDto>> GetByIdentityIdAsync(Guid identityId) =>
            await trainerRepository.GetByIdentityIdAsync(identityId) is null ? new ErrorDataResult<TrainerDto>(stringLocalizer[Message.Trainer_Was_Not_Found_ByIdentityId]) : new SuccessDataResult<TrainerDto>((await trainerRepository.GetByIdentityIdAsync(identityId)).Adapt<TrainerDto>(), stringLocalizer[Message.Trainer_Was_Found_ByIdentityId]);
    }
}