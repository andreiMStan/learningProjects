namespace Thoughtful.Api.abstractions
{
				public interface IModule
				{
								WebApplicationBuilder RegisterModule
												(WebApplicationBuilder builder);

								IEndpointRouteBuilder MapEndpoints(IEndpointRouteBuilder endpoints);
				}
}
