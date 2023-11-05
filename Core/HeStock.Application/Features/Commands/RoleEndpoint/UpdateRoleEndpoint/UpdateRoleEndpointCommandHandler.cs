using HeStock.Application.Repositories.RoleEndpoint;
using HeStock.Application.Validations.RoleEndpoint.UpdateRoleEndpoint;
using MediatR;
using System.Net;

namespace HeStock.Application.Features.Commands.RoleEndpoint.UpdateRoleEndpoint
{
    public class UpdateRoleEndpointCommandHandler : IRequestHandler<UpdateRoleEndpointCommandRequest, UpdateRoleEndpointCommandResponse>
    {
        private readonly IRoleEndpointReadRepository _RoleEndpointReadRepository;
        private readonly IRoleEndpointWriteRepository _RoleEndpointWriteRepository;

        public UpdateRoleEndpointCommandHandler(IRoleEndpointReadRepository RoleEndpointReadRepository, IRoleEndpointWriteRepository RoleEndpointWriteRepository)
        {
            _RoleEndpointReadRepository = RoleEndpointReadRepository;
            _RoleEndpointWriteRepository = RoleEndpointWriteRepository;
        }

        public async Task<UpdateRoleEndpointCommandResponse> Handle(UpdateRoleEndpointCommandRequest request, CancellationToken cancellationToken)
        {
            var isThereRoleEndpointRecord = await _RoleEndpointReadRepository.GetSingleAsync(rp => rp.Id == request.Id);

            isThereRoleEndpointRecord.AppRoleId = request.RoleId;
            isThereRoleEndpointRecord.EndpointId = request.EndpointId;
            isThereRoleEndpointRecord.Create = request.Create;
            isThereRoleEndpointRecord.Update = request.Update;
            isThereRoleEndpointRecord.Delete = request.Delete;
            isThereRoleEndpointRecord.Display = request.Display;


            _RoleEndpointWriteRepository.Update(isThereRoleEndpointRecord);
            await _RoleEndpointWriteRepository.SaveAsync();

            return new UpdateRoleEndpointCommandResponse { StatusCode = HttpStatusCode.OK };
        }
    }
}
