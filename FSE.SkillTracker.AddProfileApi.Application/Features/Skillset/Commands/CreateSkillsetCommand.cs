using AutoMapper;
using FSE.SkillTracker.AddProfileApi.Application.Interfaces;
using MediatR;

namespace FSE.SkillTracker.AddProfileApi.Application.Features.Skillset.Commands
{
    public class CreateSkillsetCommand : IRequest<Domain.Entities.TechnicalSkills>
    {
        public string Name { get; set; }
        public int ExpertiseLevel { get; set; }

        public class CreateSkillsetCommandHandler : IRequestHandler<CreateSkillsetCommand, Domain.Entities.TechnicalSkills>
        {
            private readonly ISkillsetRepository _skillSetRepository;
            private readonly IMapper _mapper;

            public CreateSkillsetCommandHandler(ISkillsetRepository skillSetRepository, IMapper mapper)
            {
                _skillSetRepository = skillSetRepository;
                _mapper = mapper;
            }

            public async Task<Domain.Entities.TechnicalSkills> Handle(CreateSkillsetCommand request, CancellationToken cancellationToken)
            {
                var id = Guid.NewGuid();
                Domain.Entities.TechnicalSkills skillSet = new Domain.Entities.TechnicalSkills
                {
                    Id = id,
                    Name = request.Name,
                };

                await _skillSetRepository.AddItemAsync(skillSet);
                return skillSet;
            }
        }
    }
}
