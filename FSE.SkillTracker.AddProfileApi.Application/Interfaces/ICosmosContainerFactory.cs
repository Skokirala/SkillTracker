using FSE.SkillTracker.AddProfileApi.Domain.Configurations;

namespace FSE.SkillTracker.AddProfileApi.Application.Intefaces
{
    public interface ICosmosContainerFactory
    {
        ICosmosContainer GetContainer(string containerName);
        ContainerInfo GetContainerInfo(string containerName);
        void EnsureDbSetupAsync();
    }
}
