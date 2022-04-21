
using FSE.SkillTracker.AddProfileApi.Application.Intefaces;

namespace FSE.SkillTracker.AddProfileApi.Application.Specifications
{
    public class ProfileSpecification : SpecificationBase, ICosmosQuerySpecification<Domain.Entities.Profile>
    {
        public ProfileSpecification()
        {
            OrderByClause = "order by c.id";
        }
    }
}
