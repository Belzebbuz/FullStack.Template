using App.Shared.ApiMessages.Identity.M001;
using App.Shared.ApiMessages.Identity.M002;
using App.Shared.Wrapper;
using Application.Contracts.DI;

namespace Application.Contracts.Services.Identity;

public interface ITokenService : IScopedService
{
	Task<IResult<M001Response>> GetTokenAsync(M001Request request, string ipAddress, CancellationToken cancellationToken);
	Task<IResult<M001Response>> RefreshTokenAsync(M002Request request, string ipAddress);
}
