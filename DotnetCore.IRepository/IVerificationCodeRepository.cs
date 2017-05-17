using System;
using DotnetCore.Infrastructure.RepositoryFramework;
using DotnetCore.Model.DB;

namespace DotnetCore.IRepository
{
    public interface IVerificationCodeRepository : IRepository<Guid, MVerificationCode>, IDisposable
    {
    }
}