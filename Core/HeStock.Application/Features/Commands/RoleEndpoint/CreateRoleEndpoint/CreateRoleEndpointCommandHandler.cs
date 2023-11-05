using HeStock.Application.Repositories.RoleEndpoint;
using MediatR;
using System.Net;

namespace HeStock.Application.Features.Commands.RoleEndpoint.CreateRoleEndpoint
{
    public class CreateRoleEndpointCommandHandler : IRequestHandler<CreateRoleEndpointCommandRequest, CreateRoleEndpointCommandResponse>
    {
        private readonly IRoleEndpointWriteRepository _RoleEndpointWriteRepository;
        private readonly IRoleEndpointReadRepository _RoleEndpointReadRepository;

        public CreateRoleEndpointCommandHandler(IRoleEndpointWriteRepository RoleEndpointWriteRepository, IRoleEndpointReadRepository RoleEndpointReadRepository)
        {
            _RoleEndpointWriteRepository = RoleEndpointWriteRepository;
            _RoleEndpointReadRepository = RoleEndpointReadRepository;
        }

        public async Task<CreateRoleEndpointCommandResponse> Handle(CreateRoleEndpointCommandRequest request, CancellationToken cancellationToken)
        {
            var isThereRoleEndpointRecord =await _RoleEndpointReadRepository.GetSingleAsync(rp => rp.AppRoleId == request.RoleId && rp.EndpointId == request.EndpointId && rp.Create == request.Create && rp.Update == request.Update && rp.Delete == request.Delete && rp.Display == request.Display );

            if (isThereRoleEndpointRecord != null)
                return new CreateRoleEndpointCommandResponse { Message = "Role page is already exist", StatusCode = HttpStatusCode.Conflict };


            var addedRoleEndpoint = new Domain.Entities.RoleEndpoint
            {
                AppRoleId = request.RoleId,
                EndpointId = request.EndpointId,
                Create = request.Create,
                Update = request.Update,
                Delete = request.Delete,
                Display = request.Display,
            };

            await _RoleEndpointWriteRepository.AddAsync(addedRoleEndpoint);
            int status = await _RoleEndpointWriteRepository.SaveAsync();

            if (status == 1)
                return new CreateRoleEndpointCommandResponse { Message = "Role page added successfully", StatusCode = HttpStatusCode.OK };

            return new CreateRoleEndpointCommandResponse { Message = "Failed to add role page. Please try again.", StatusCode = HttpStatusCode.BadGateway };
        }
    }
}
