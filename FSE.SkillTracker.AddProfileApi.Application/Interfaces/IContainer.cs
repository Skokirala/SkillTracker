using Microsoft.Azure.Cosmos;

namespace FSE.SkillTracker.AddProfileApi.Application.Intefaces
{
    public interface IContainer
    {
        Container _container { get; }
    }
}