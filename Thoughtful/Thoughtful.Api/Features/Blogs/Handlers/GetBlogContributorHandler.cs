using Dal;
using Thoughtful.Api.Features.Blogs.Endpoints;
using Thoughtful.Api.Features.Blogs.Queries;

namespace Thoughtful.Api.Features.Blogs.Handlers
{
				public class GetBlogContributorHandler : IRequestHandler<GetBlogContributor, List<BlogReadsEndpoint.Contributor>>
				{
								private readonly ThoughtfulDbContext _ctx;
								private readonly IMapper _mapper;
        public GetBlogContributorHandler(ThoughtfulDbContext ctx, IMapper mapper)
        {
												_ctx = ctx;
												_mapper = mapper;
        }
        public async Task<List<BlogReadsEndpoint.Contributor>> Handle(GetBlogContributor request, CancellationToken cancellationToken)
								{
												var blog = await _ctx.Blogs.Include(b => b.Contributors).FirstOrDefaultAsync(b => b.Id == request.BlogId);
												if (blog != null)
																return _mapper.Map<List<BlogReadsEndpoint.Contributor>>(blog.Contributors);
												return new List<BlogReadsEndpoint.Contributor>();

								}
				}
}
