using Thoughtful.Api.abstractions;
using Thoughtful.Api.Features.Blogs.Endpoints;

namespace Thoughtful.Api.Features.Blogs
{
				public class BlogsModule : IModule
				{
								private IMapper _mapper;
								private IMediator _mediator; 
								public IEndpointRouteBuilder MapEndpoints(IEndpointRouteBuilder endpoints)
								{
												new BlogReadsEndpoint(_mediator).RegisterRoutes(endpoints);
												new BlogsWritesEndpoint(_mediator).RegisterRoutes(endpoints);
												return endpoints;

								}

								public WebApplicationBuilder RegisterModule(WebApplicationBuilder builder)
								{
												var provider = builder.Services.BuildServiceProvider();
												_mediator = provider.GetRequiredService<IMediator>();
												_mapper = provider.GetRequiredService<IMapper>();
												return builder;
								}
				}
}
