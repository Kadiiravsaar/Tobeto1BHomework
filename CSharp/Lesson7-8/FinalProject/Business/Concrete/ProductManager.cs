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


    
     
        public IResult Add(Product product)
        {
            _productDal.Add(product);
            return new SuccessResult("Eklendi");
        }

        public IResult Update(Product product)
        {
            _productDal.Update(product);
            return new SuccessResult("Güncellendi");
        }
        public IResult Delete(Product product)
        {
            _productDal.Delete(product);
            return new SuccessResult("Güncellendi");
        }
    }

}
