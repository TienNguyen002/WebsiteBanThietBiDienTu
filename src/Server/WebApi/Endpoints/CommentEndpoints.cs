using Carter;
using Core.Collections;
using Core.DTO.Comment;
using Core.Entities;
using MapsterMapper;
using Microsoft.AspNetCore.Mvc;
using Services.Apps.Comments;
using System.Net;
using System.Xml.Linq;
using WebApi.Models;
using WebApi.Models.Comment;

namespace WebApi.Endpoints
{
    public class CommentEndpoints : ICarterModule
    {
        public void AddRoutes(IEndpointRouteBuilder app)
        {
            var routeGroupBuilder = app.MapGroup("/api/comments");

            routeGroupBuilder.MapGet("/", GetAllComments)
                .WithName("GetAllComments")
                .Produces<ApiResponse<PaginationResult<Comment>>>();

            routeGroupBuilder.MapGet("/byslug/{slug:regex(^[a-z0-9_-]+$)}", GetCommentsByProductSlug)
                .WithName("GetCommentsByProductSlug")
                .Produces<ApiResponse<CommentDto>>();

            routeGroupBuilder.MapPost("/{slug:regex(^[a-z0-9_-]+$)}", AddComment)
                .WithName("AddComment")
                .Accepts<CommentEditModel>("multipart/form-data")
                .Produces(401)
                .Produces<ApiResponse<CommentItems>>();

            routeGroupBuilder.MapDelete("/{id:int}", DeleteComment)
                .WithName("DeleteComment")
                .Produces<ApiResponse<string>>();
        }

        private static async Task<IResult> GetAllComments(
            ICommentRepository commentRepository)
        {
            var comments = await commentRepository.GetCommentsAsync();
            return Results.Ok(ApiResponse.Success(comments));
        }

        private static async Task<IResult> GetCommentsByProductSlug(string slug,
            ICommentRepository commentRepository,
            IMapper mapper)
        {
            var comment = await commentRepository.GetCommentsByProductSlugAsync(slug);
            return comment == null
                ? Results.Ok(ApiResponse.Fail(HttpStatusCode.NotFound, $"Không tìm thấy bình luận nào của sản phẩm có slug {slug}"))
                : Results.Ok(ApiResponse.Success(mapper.Map<CommentDto>(comment)));
        }

        private static async Task<IResult> AddComment(
            HttpContext context,
            ICommentRepository commentRepository,
            string slug,
            IMapper mapper)
        {
            var model = await CommentEditModel.BindAsync(context);
            var comment = new Comment
            {
                Detail = model.Detail,
                CreatedDate = DateTime.Now,
                ProductId = model.ProductId,
                CustomerId = model.CustomerId,
            };
            await commentRepository.AddCommentAsync(comment, slug);
            return Results.Ok(ApiResponse.Success(
                mapper.Map<CommentItems>(comment), HttpStatusCode.Created));
        }

        private static async Task<IResult> DeleteComment(
            int id,
            ICommentRepository commentRepository)
        {
            return await commentRepository.DeleteCommentByIdAsync(id)
              ? Results.Ok(ApiResponse.Success("Xóa bình luận thành công", HttpStatusCode.NoContent))
              : Results.Ok(ApiResponse.Fail(HttpStatusCode.NotFound, $"Không tìm thấy bình luận có id = {id}"));
        }
    }
}
