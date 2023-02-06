using Application.Features.Products.Dtos;
using Application.Features.Products.Rules;
using Application.Services.Repositories;
using AutoMapper;
using Core.Mailings;
using Core.Persistence.Paging;
using Domain.Entities;
using Domain.Enums;
using MediatR;
using System.Xml.Linq;

namespace Application.Features.Products.Command
{
    public sealed class CreateProductCommand:IRequest<CreateProductDto>
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

        public class CreateProductCommandHandler : IRequestHandler<CreateProductCommand, CreateProductDto>
        {
            private readonly IProductRepository _productRepository;
            private readonly IMapper _mapper;
            private readonly ProductBusinnessRules _productBusinnessRules;
            private readonly IMailService _mailService;
            public CreateProductCommandHandler(IProductRepository productRepository,
                IMapper mapper, ProductBusinnessRules productBusinnessRules,IMailService mailService)
            {
                _mailService = mailService;
                _productRepository = productRepository;
                _mapper = mapper;
                _productBusinnessRules = productBusinnessRules;
            }

            public async Task<CreateProductDto> Handle(CreateProductCommand request, CancellationToken cancellationToken)
            {
                IPaginate<Product> products = await _productRepository.GetListAsync(c => c.Name == request.Name);
                if (products.Items.Any())
                {
                    Product? getNameproduct = await _productRepository.GetAsync(x => x.Name == request.Name);
                   
                    Product product = await _productRepository.UpdateAsync(getNameproduct);
                    CreateProductDto createProduct = _mapper.Map<CreateProductDto>(product);
                    return createProduct;
                }
                Product mappedProduct = _mapper.Map<Product>(request);
                Product addedProduct = await _productRepository.AddAsync(mappedProduct);
                CreateProductDto createProductDto = _mapper.Map<CreateProductDto>(addedProduct);
                //_mailService.SendMail(new Mail
                //{
                //    ToEmail = "ramazankucukkoc43@gmail.com",
                //    HtmlBody = "<strong>Hey, Ürünlere eklendi.</strong>",
                //    Subject = "Yeni ürün eklendi!",
                //    ToFullName = "system Admins"
                //});
                return createProductDto;
            }
        }
    }
}
