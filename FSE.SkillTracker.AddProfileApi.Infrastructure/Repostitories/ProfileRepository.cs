using FSE.SkillTracker.AddProfileApi.Application.Intefaces;
using FSE.SkillTracker.AddProfileApi.Application.Interfaces;
using FSE.SkillTracker.AddProfileApi.Domain.Entities;
using FSE.SkillTracker.AddProfileApi.Infrastructure.Repostitories.Base;
using Microsoft.Azure.Cosmos;

namespace FSE.SkillTracker.AddProfileApi.Infrastructure.Repostitories
{
    public class ProfileRepository : CosmosRepository<Profile>, IProfileRepository
    {
        public override string ContainerName { get; } = "profiles";
        public ProfileRepository(ICosmosContainerFactory factory) : base(factory)
        {
            factory.EnsureDbSetupAsync ();
        }
        public override PartitionKey ResolvePartitionKey(Profile entity)
        {
            return new PartitionKey(entity.Name);
        }
    }
}
