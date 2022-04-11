using FSE.SkillTracker.AddProfileApi.Application.Intefaces;
using FSE.SkillTracker.AddProfileApi.Application.Interfaces;
using FSE.SkillTracker.AddProfileApi.Domain.Entities;
using FSE.SkillTracker.AddProfileApi.Infrastructure.Repostitories.Base;
using Microsoft.Azure.Cosmos;

namespace FSE.SkillTracker.AddProfileApi.Infrastructure.Repostitories
{
    public class SkillsetRepository : CosmosRepository<Skillset>, ISkillsetRepository
    {
        public override string ContainerName { get; } = "skillsets";
        public SkillsetRepository(ICosmosContainerFactory factory) : base(factory)
        {
            factory.EnsureDbSetupAsync ();
        }
        public override PartitionKey ResolvePartitionKey(Skillset entity)
        {
            return new PartitionKey(entity.Name);
        }
    }
}
