using HeStock.Application.Features.Commands.RoleEndpoint.DeleteRoleEndpoint;
using HeStock.Application.Repositories.RoleEndpoint;
using HeStock.Application.Validations.RoleEndpoint.DeleteRoleEndpoint;
using MediatR;
using System.Net;

namespace HeStock.Application.Features.Commands.RoleEndpoint.DeleteRoleEndpoint
{
    public class DeleteRoleEndpointCommandHandler : IRequestHandler<DeleteRoleEndpointCommandRequest, DeleteRoleEndpointCommandResponse>
    {
        private readonly IRoleEndpointWriteRepository _RoleEndpointWriteRepository;
        private readonly IRoleEndpointReadRepository _RoleEndpointReadRepository;

        public DeleteRoleEndpointCommandHandler(IRoleEndpointWriteRepository RoleEndpointWriteRepository, IRoleEndpointReadRepository RoleEndpointReadRepository)
        {
            _RoleEndpointWriteRepository = RoleEndpointWriteRepository;
            _RoleEndpointReadRepository = RoleEndpointReadRepository;
        }

        public async Task<DeleteRoleEndpointCommandResponse> Handle(DeleteRoleEndpointCommandRequest request, CancellationToken cancellationToken)
        {
            var RoleEndpointToDelete = await _RoleEndpointReadRepository.GetSingleAsync(rp => rp.Id == request.Id);

            if (RoleEndpointToDelete == null)
                return new DeleteRoleEndpointCommandResponse { Message = "RoleEndpoint does not exist", StatusCode = HttpStatusCode.NotFound };

            RoleEndpointToDelete.IsDeleted = true;
            _RoleEndpointWriteRepository.Update(RoleEndpointToDelete);
            await _RoleEndpointWriteRepository.SaveAsync();

            return new DeleteRoleEndpointCommandResponse { Message = $"{RoleEndpointToDelete.EndpointId} is deleted successfully",StatusCode = HttpStatusCode.OK };
        }
    }
}
