using AutoMapper;
using FSE.SkillTracker.AddProfileApi.Application.Interfaces;
using MediatR;

namespace FSE.SkillTracker.AddProfileApi.Application.Features.Skillset.Commands
{
    public class CreateSkillsetCommand : IRequest<Domain.Entities.Skillset>
    {
        public string Name { get; set; }
        public int ExpertiseLevel { get; set; }

        public class CreateSkillsetCommandHandler : IRequestHandler<CreateSkillsetCommand, Domain.Entities.Skillset>
        {
            private readonly ISkillsetRepository _skillSetRepository;
            private readonly IMapper _mapper;

            public CreateSkillsetCommandHandler(ISkillsetRepository skillSetRepository, IMapper mapper)
            {
                _skillSetRepository = skillSetRepository;
                _mapper = mapper;
            }

            public async Task<Domain.Entities.Skillset> Handle(CreateSkillsetCommand request, CancellationToken cancellationToken)
            {
                var id = Guid.NewGuid();
                Domain.Entities.Skillset skillSet = new Domain.Entities.Skillset
                {
                    Id = id,
                    Name = request.Name,
                    ExpertiseLevel = request.ExpertiseLevel
                };

                await _skillSetRepository.AddItemAsync(skillSet);
                return skillSet;
            }
        }
    }
}
