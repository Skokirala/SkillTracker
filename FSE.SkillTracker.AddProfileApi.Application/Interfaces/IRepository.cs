using FSE.SkillTracker.AddProfileApi.Application.Intefaces;
using FSE.SkillTracker.AddProfileApi.Domain;

namespace FSE.SkillTracker.AddProfileApi.Application.Interfaces
{
    public interface IRepository<T> where T : EntityKey
    {
        IAsyncEnumerable<T> GetItemsAsyncEnumerable(ICosmosQuerySpecification<T> specification);
        Task<IEnumerable<T>> GetItemsAsync(ICosmosQuerySpecification<T> specification);
        Task<T> GetItemAsync(string id, string partitionKey);
        Task AddItemAsync(T item);
        Task UpdateItemAsync(T item);
        Task DeleteItemAsync(string id, string partitionKeyValue);
    }
}
