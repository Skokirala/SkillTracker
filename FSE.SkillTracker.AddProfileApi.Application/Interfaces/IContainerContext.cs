using FSE.SkillTracker.AddProfileApi.Domain;
using Microsoft.Azure.Cosmos;

namespace FSE.SkillTracker.AddProfileApi.Application.Intefaces
{
    public interface IContainerContext<T> where T : EntityKey
    {
        string ContainerName { get; }
        PartitionKey ResolvePartitionKey(T entity);
    }
}
