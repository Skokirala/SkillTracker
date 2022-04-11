namespace FSE.SkillTracker.AddProfileApi.Domain.Entities
{
    public class Skillset : EntityKey
    {
        public string Name { get; set; }
        public int ExpertiseLevel { get; set; }
    }
}
