﻿namespace Application.Features.ProductComments.Dtos
{
    public class DeleteProductCommentDto
    {
        public int Id { get; set; }
        public int UserId { get; set; }
        public string Comment { get; set; }
        public int ProductId { get; set; }
    }
}
