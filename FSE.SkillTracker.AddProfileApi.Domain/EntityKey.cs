using Newtonsoft.Json;

namespace FSE.SkillTracker.AddProfileApi.Domain
{
    public class EntityKey
    {
        [JsonProperty(PropertyName = "id")]
        public Guid Id { get; set; }
    }
}
