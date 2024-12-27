using Thoughtful.Api.Features.AuthorFeature;

namespace Thoughtful.Api.Features.Blogs.Queries
{
				public class GetAuthorById:IRequest<AuthorGetDto>
				{
        public int AuthorId { get; set; }
    }
}
