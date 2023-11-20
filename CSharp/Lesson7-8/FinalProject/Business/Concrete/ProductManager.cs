using Business.Abstract;
using Core.Utilities.Results;
using DataAccess.Abstract;
using Entities.Concrete;
using Entities.DTOs;

namespace Business.Concrete
{
    //Business rules

    public class ProductManager : IProductService
    {
        IProductDal _productDal;

        public ProductManager(IProductDal productDal)
        {
            _productDal = productDal;
            
        }

        public IDataResult<Product> GetById(int id)
        {
            if (_productDal.Get(x => x.ProductId == id) == null)
            {
                return new ErrorDataResult<Product>("Ürün ıd yok");
            }
            return new SuccessDataResult<Product>(_productDal.Get(x => x.ProductId == id),"Ürün getirildi");

        }

        public IDataResult<List<Product>> GetAll()
        {
            if (DateTime.Now.Hour == 20)
            {
                return new ErrorDataResult<List<Product>>("Zaman aşımuı");
            }

            return new SuccessDataResult<List<Product>>(_productDal.GetAll(), "Ürünler Listelendi");

        }

        public IDataResult<List<Product>> GetAllByCategoryId(int id)
        {
            return new SuccessDataResult<List<Product>>(_productDal.GetAll(c => c.CategoryId == id));
        }

        public IDataResult<List<Product>> GetByUnitPrice(decimal min, decimal max)
        {
            return new SuccessDataResult<List<Product>>(_productDal.GetAll(x => x.UnitPrice > min && x.UnitPrice < max));
        }

        public IDataResult<List<Product>> GetByUnitInStock(short min, short max)
        {
            if (min < 0)
            {
                return new ErrorDataResult<List<Product>>("Ürünler Boş");
            }
            return new SuccessDataResult<List<Product>>(_productDal.GetAll(x => x.UnitsInStock > min && x.UnitsInStock < max));

        }


        //public IDataResult<List<ProductDetailDto>> GetProductDetails()
        //{
        //    if (DateTime.Now.Hour == 10)
        //    {
        //        return new ErrorDataResult<List<ProductDetailDto>>("Zaman Aşımı");
        //    }
        //    return new SuccessDataResult<List<ProductDetailDto>>(_productDal.GetProductDetails());
        //}


        // Claim => Yetki (iddia etmek)
        public IResult AddProduct(Product product)
        {
            _productDal.Add(product);
            return new SuccessResult("Eklendi");
        }

        private IResult CheckIfProductCountOfCategoryCorrect(int categoryId)
        {
            var result = _productDal.GetAll(x => x.CategoryId == categoryId).Count;
            if (result >= 10)
            {
                return new ErrorResult("Sayı 10dan büyük");
            }

            return new SuccessResult();
        }

        private IResult CheckIfProductNameExists(string name)
        {
            var result = _productDal.GetAll(p => p.ProductName == name).Any();
            if (result)
            {
                return new ErrorResult("Ürün Adı zaten kayıtlı");
            }
            return new SuccessResult();
        }

    }

}
