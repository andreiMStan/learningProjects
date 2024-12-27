using Dal;
using Thoughtful.Api.Features.Author.Commands;

using Thoughtful.Api.Features.AuthorFeature;
using Thoughtful.Domain.Model;

namespace Thoughtful.Api.Features.Author.Handlers
{
    public class CreateAuthorCommandHandler : IRequestHandler<CreateAuthorCommand, AuthorGetDto>
    {
        private readonly ThoughtfulDbContext _ctx;
        private readonly IMapper _mapper;
        public CreateAuthorCommandHandler(ThoughtfulDbContext ctx, IMapper mapper)
        {
            _ctx = ctx;
            _mapper = mapper;
        }

        public async Task<AuthorGetDto> Handle(CreateAuthorCommand request, CancellationToken cancellationToken)
        {
            //map from authordto (body) mapping to add 
            var toAdd = _mapper.Map<Thoughtful.Domain.Model.Author>(request.Author);
            _ctx.Authors.Add(toAdd);
            await _ctx.SaveChangesAsync();
            return _mapper.Map<AuthorGetDto>(toAdd);
            //		return toAdd;
        }
    }
}
