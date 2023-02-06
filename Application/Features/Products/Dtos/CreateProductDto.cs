﻿using Domain.Entities;
using Domain.Enums;

namespace Application.Features.Products.Dtos
{
    public class CreateProductDto
    {
        public string Name { get; set; }
        public int BrandId { get; set; }
        public int ProductBranchId { get; set; }
        public int StockId { get; set; }
        public string? ShortDescription { get; set; }
        public string Description { get; set; }
        public decimal RegularPrice { get; set; }// Normal fiyat
        public decimal? SalePrice { get; set; }//Satış Fiyatı
        public string SKU { get; set; }//Stok Kodu
        public int Rating { get; set; }//Değerlendirme
        public int DiscountRate { get; set; }//Indirim oranı
        public int CategoryId { get; set; }

    }
}
