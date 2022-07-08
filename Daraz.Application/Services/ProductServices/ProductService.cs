using Daraz.Application.Common.Interfaces;
using Daraz.Domain.Entities;

namespace Daraz.Application.Services.ProductServices
{
    public class ProductService : IProductService
    {
        public readonly IUnitOfWork _unitOfWork;

        public ProductService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }
        public ProductResult[] GetAll()
        {
            var products = _unitOfWork.Products.GetAll();
            ProductResult[] result = new ProductResult[] { };
            products.ToList().ForEach(p =>
            {
                result.Append(MapToProductResult(p));
            });
            return result;
        }
        public int AddProduct(string Name, string Description, double MarkedPrice, double Discount, int userId)
        {
            var product = new Product()
            {
                Name = Name,
                Description = Description,
                Price = MarkedPrice,
                Discount = Discount,
            };
            _unitOfWork.Products.Add(product);
            _unitOfWork.Save();
            return product.Id;
        }
        public ProductResult UpdateProduct(int ProductId, string Name, string Description, double MarkedPrice, double Discount, int userId)
        {
            var product = Get(ProductId);
            // check if userId is admin or groupAdmin who manages this kind of product or the owner of the product
            bool condition = true;

            if (condition)
            {
                product.Name = Name;
                product.Discount = Discount;
                product.Description = Description;
                product.Price = MarkedPrice;
                _unitOfWork.Products.UpdateProduct(product);
                _unitOfWork.Save();
                return MapToProductResult(product);
            }
            throw new Exception("Invalid User Persissions for this operation.");
        }
        public bool DeleteProduct(int ProductId, int userId)
        {
            Product product = Get(ProductId);
            // check if userId is admin or groupAdmin who manages this kind of product or the owner of the product
            bool condition = true;

            if (condition)
            {
                _unitOfWork.Products.Delete(product);
                _unitOfWork.Save();
                return true;
            }
            return false;
        }

        public ProductResult GetItem(int ProductId)
        {
            Product product = Get(ProductId);
            return MapToProductResult(product);
        }
        public Product? Get(int id)
        {
            Product? product = _unitOfWork.Products.GetT(p => p.Id == id);
            if (product == null)
                throw new Exception("No such product found");
            return product;
        }
        public ProductResult MapToProductResult(Product product)
        {
            return new ProductResult(product.Id, product.Name, product.Description, product.Price, product.Discount);
        }

    }
}
