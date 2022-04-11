namespace FSE.SkillTracker.AddProfileApi.Domain.Entities
{
    public class Profile : EntityKey
    {
        public string Name { get; set; }
        public string AssociateId { get; set; }
        public string Mobile { get; set; }
        public string Email { get; set; }
        public Guid SkillsetId { get; set; }
        public DateTime CreatedOn { get; set; }
    }


}
