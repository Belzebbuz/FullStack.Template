using App.Shared.ApiMessages.Identity.M003;
using App.Shared.ApiMessages.Identity.M004;
using App.Shared.ApiMessages.Identity.M005;
using App.Shared.ApiMessages.Identity.M006;
using App.Shared.ApiMessages.Identity.M007;
using App.Shared.ApiMessages.Identity.M008;
using App.Shared.Wrapper;
using Application.Contracts.DI;

namespace Application.Contracts.Services.Identity;

public interface IUserService : IScopedService
{
	Task<IResult> AssignRolesAsync(M008Request request);
	Task<IResult> CreateAsync(M005Request request, string origin);
	Task<IResult<M007Response>> GetAsync(string id);
	Task<IResult<M003Response>> GetListAsync();
	Task<IResult<M004Response>> GetRolesAsync(string id);
	Task<IResult> ToggleStatusAsync(M006Request request);
}
