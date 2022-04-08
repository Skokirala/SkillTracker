using Microsoft.Azure.Cosmos;

namespace FSE.SkillTracker.AddProfileApi.Application.Intefaces
{
    public interface ICosmosQuerySpecification<T>
    {
        QueryDefinition GetQueryDefinition();
    }
}
