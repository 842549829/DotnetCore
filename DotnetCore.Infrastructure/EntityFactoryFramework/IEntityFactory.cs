using DotnetCore.Infrastructure.DomainBase;
using System.Data;

namespace DotnetCore.Infrastructure.EntityFactoryFramework
{
    /// <summary>
    /// IEntityFactory 接口
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public interface IEntityFactory<out T> where T : IEntity
    {
        /// <summary>
        /// The build entity.
        /// </summary>
        /// <param name="reader">
        /// The reader.
        /// </param>
        /// <returns>
        /// The <see cref="T"/>.
        /// </returns>
        T BuildEntity(IDataReader reader);
    }
}