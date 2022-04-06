namespace FSE.SkillTracker.AddProfileApi.Domain.Entities
{
    public class Profiles : EntityKey
    {
        public string Name { get; set; }
        public string AssociateId { get; set; }
        public string Mobile { get; set; }
        public string Email { get; set; }
    }
}
