
using Thoughtful.Api.Features.AuthorFeature;
using Thoughtful.Domain.Model;

namespace Thoughtful.Api.Features.Author.Commands
{
    public class CreateAuthorCommand : IRequest<AuthorGetDto>
    {
        public AuthorDto? Author { get; set; }
    }

}
