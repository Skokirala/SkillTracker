using Microsoft.Azure.Cosmos;

namespace FSE.SkillTracker.AddProfileApi.Application.Intefaces
{
    public interface ICosmosContainer
    {
        Container _container { get; }
    }
}
