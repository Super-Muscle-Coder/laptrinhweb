﻿using MVC.Models;
using MVC.Repositories;
using MVC.Services.Interface;
namespace MVC.Services.Implementation
{
    public class ProductService : IProductService
    {
        private readonly IRepository<Product> _productRepository;

        public ProductService(IRepository<Product> productRepository)
        {
            _productRepository = productRepository;
        }

        public IEnumerable<Product> GetAllProducts() => _productRepository.GetAll();

        public Product GetProductById(int id) => _productRepository.GetById(id);

        public void CreateProduct(Product product)
        {
            _productRepository.Add(product);
            _productRepository.Save();
        }

        public void UpdateProduct(Product product)
        {
            _productRepository.Update(product);
            _productRepository.Save();
        }

        public void DeleteProduct(int id)
        {
            var product = _productRepository.GetById(id);
            if (product != null)
            {
                _productRepository.Delete(product);
                _productRepository.Save();
            }
        }

    }
}