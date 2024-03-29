﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TechnoShop.BusinessLayer.Dtos.ProductDto;
using TechnoShop.BusinessLayer.Dtos.ProductTypeDto;

namespace TechnoShop.BusinessLayer.Interfaces
{
    public interface IProductService
    {
        public Task AddNewProduct(ProductRequestDto product);
        public Task AddNewType(ProductTypeRequestDto productType);
        public Task<List<ProductResponceDto>> GetProducts(string userEmail, string productType, int page, int productsPerPage);
        public Task<ProductResponceDto> GetProduct(string productId);
        public Task<List<ProductTypeResponceDto>> GetProductTypes();
        public Task DeleteProduct(string productId);
        public Task DeleteProductType(string productTypeName);
        public int GetProductCount(string productType);
        public Task UpdateProduct(string productId, ProductRequestDto product);
    }
}
