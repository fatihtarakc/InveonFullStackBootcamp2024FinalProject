﻿namespace InveonCourseApp.Backend.DataAccess.Abstract.Repositories.Abstract
{
    public interface IAdminRepository :
        IAsyncAddableRepository<Admin>, IAsyncDeletableRepository<Admin>, IAsyncUpdatableRepository<Admin>,
        IAsyncQueryableRepository<Admin>, IAsyncOrderableRepository<Admin>
    {
        Task<Admin> GetByIdentityIdAsync(Guid identityId);
    }
}