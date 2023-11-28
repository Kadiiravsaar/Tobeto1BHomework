using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.CrossCuttingConcerns.Validation
{
    public static class ValidationTool
    {
        public static void Validate(IValidator validator, object entity)
        {
            // context bir Thread'i anlatır
            var context = new ValidationContext<object>(entity); // 1.32.36 => object için bir doğrulama yapıcam. Parametreden gelen entity ile
            var result = validator.Validate(context); // bu örneğin courseValidatore karşılık gelir. CourseValidator.Validate
            if (!result.IsValid)
            {
                throw new ValidationException(result.Errors);
            }


            //Yukarıda ki kodun tekil hali

            //var context = new ValidationContext<Course>(course); 
            //ProductValidator productValidator = new ProductValidator();
            //var result = productValidator.Validate(context); 
            //if (!result.IsValid)
            //{
            //    throw new ValidationException(result.Errors);
            //}
        }
    }
}
