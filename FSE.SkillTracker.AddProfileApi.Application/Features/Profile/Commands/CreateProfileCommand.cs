using AutoMapper;
using FSE.SkillTracker.AddProfileApi.Application.Interfaces;
using MediatR;

namespace FSE.SkillTracker.AddProfileApi.Application.Features.Profile.Commands
{
    public class CreateProfileCommand : IRequest<Domain.Entities.Profile>
    {
        public string Name { get; set; }
        public string AssociateId { get; set; }
        public string Mobile { get; set; }
        public string Email { get; set; }
        public Guid SkillsetId { get; set; }
        public class CreateProfileCommandHandler : IRequestHandler<CreateProfileCommand, Domain.Entities.Profile>
        {
            private readonly IProfileRepository _profileRepository;
            private readonly IMapper _mapper;

            public CreateProfileCommandHandler(IProfileRepository profileRepository, IMapper mapper)
            {
                _profileRepository = profileRepository;
                _mapper = mapper;
            }

            public async Task<Domain.Entities.Profile> Handle(CreateProfileCommand request, CancellationToken cancellationToken)
            {
                var LNewGuid = Guid.NewGuid();
                Domain.Entities.Profile newProfile = new Domain.Entities.Profile
                {
                    Id = LNewGuid,
                    AssociateId = request.AssociateId,
                    Email = request.Email,
                    Mobile = request.Mobile,
                    Name = request.Name,
                    SkillsetId = request.SkillsetId,
                    CreatedOn = DateTime.Now
                };

                await _profileRepository.AddItemAsync(newProfile);
                return newProfile;
            }
        }
    }
}
