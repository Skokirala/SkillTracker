using AutoMapper;
using FSE.SkillTracker.AddProfileApi.Application.Interfaces.Base;
using FSE.SkillTracker.AddProfileApi.Application.Wrappers;
using MediatR;
using System.Net;

namespace FSE.SkillTracker.AddProfileApi.Application.Features.Profile.Commands
{
    public class UpdateProfileCommand : IRequest<Response<HttpStatusCode>>
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string AssociateId { get; set; }
        public string Mobile { get; set; }
        public string Email { get; set; }
        public class UpdateProfileCommandHandler : IRequestHandler<UpdateProfileCommand, Response<HttpStatusCode>>
        {
            private readonly ICosmosDbService _cosmosDbService;
            private readonly IMapper _mapper;

            public UpdateProfileCommandHandler(ICosmosDbService cosmosDbService, IMapper mapper)
            {
                _cosmosDbService = cosmosDbService;
                _mapper = mapper;
            }

            public async Task<Response<HttpStatusCode>> Handle(UpdateProfileCommand request, CancellationToken cancellationToken)
            {
                var LNewGuid = Guid.NewGuid();

                var statusCode = await _cosmosDbService.AddItem(LNewGuid, new Domain.Entities.Profiles
                {
                    Id = LNewGuid,
                    AssociateId = request.AssociateId,
                    Email = request.Email,
                    Mobile = request.Mobile,
                    Name = request.Name
                }, cancellationToken);

                return new Response<HttpStatusCode>(statusCode);
            }
        }
    }
}
