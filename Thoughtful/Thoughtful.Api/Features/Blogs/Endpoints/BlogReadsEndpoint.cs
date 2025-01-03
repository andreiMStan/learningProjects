﻿using Dal;
using Thoughtful.Api.abstractions;
using Thoughtful.Api.Features.AuthorFeature;
using Thoughtful.Api.Features.Blogs.Commands;
using Thoughtful.Api.Features.Blogs.Queries;

namespace Thoughtful.Api.Features.Blogs.Endpoints
{
				public class BlogReadsEndpoint : IEndpoint
				{
								private readonly IMediator _mediator;
								public BlogReadsEndpoint(IMediator mediator )
								{
												_mediator = mediator;
								}

								public IEndpointRouteBuilder RegisterRoutes(IEndpointRouteBuilder endpoints)
								{
												endpoints.MapGet("/api/blogs", async () => await GetAllBlogs())
																	.WithDisplayName("Blogs")
																	.WithName(" Get all Blogs")
														.Produces<List<Blog>>()
																	.Produces(500);
												endpoints.MapGet("/api/blogs/{id}", async (int id) => await GetBlogById(id))
																.WithName("GetBlogById")
																.WithDisplayName("Blogs")
													.Produces<Blog>()
																.Produces(404)
																.Produces(500);

												endpoints.MapGet("/api/blogs/{blogId}/contributors",
																async (int blogId) => await GetBlogContributors(blogId))
																.WithName("GetBlogContributors")
																.WithDisplayName("Blogs")
																.Produces<List<Contributor>>()
																.Produces(500);
												return endpoints;

												//		(ThoughtfulDbContext ctx)

												//	return await ctx.Blogs.ToListAsync();

								}
								private async Task<IResult> GetAllBlogs()
								{
												var result = await _mediator.Send(new GetAllBlogs());
												return Results.Ok(result);
								}
								private async Task<IResult> GetBlogById(int id) 
								{
												var result = await _mediator.Send(new GetBlogById { BlogId = id });
												if (result is null) return Results.NotFound();
												return Results.Ok(result);
								}
								private async Task<IResult> GetBlogContributors(int blogId)
								{
												var query = new Thoughtful.Api.Features.Blogs.Queries.GetBlogContributor
												{
																BlogId = blogId
												};
												var result =await _mediator.Send(query);
												return Results.Ok(result);
								}
								public record Blog
								{
												public int Id { get; init; }
            public  string Name { get; init; }
            public string Description { get; init; }

            public DateTime DateCreated { get; init; }
            public Author Owner { get; init; }
        }

								public record Author
								{
            public string Name { get; init; }

            public string Bio { get; init; }
        }

								public record Contributor
								{
												public int ContributorId { get; init; }
												public string Name { get; init; }
            public string Bio { get; init; }
        }
				}
}
