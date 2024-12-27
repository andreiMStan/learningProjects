using Thoughtful.Api.Features.Blogs.Endpoints;

namespace Thoughtful.Api.Features.Blogs.Queries
{
			public class GetBlogContributor:IRequest<List<BlogReadsEndpoint.Contributor>>
				{
        public int BlogId { get; init; }
    }
}
