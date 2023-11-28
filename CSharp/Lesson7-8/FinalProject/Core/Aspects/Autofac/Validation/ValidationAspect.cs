using Castle.DynamicProxy;
using Core.CrossCuttingConcerns.Validation;
using Core.Utilities.Interceptors;
using FluentValidation;

namespace Core.Aspects.Autofac.Validation
{
    public class ValidationAspect : MethodInterception
    {
        private Type _validatorType;
        public ValidationAspect(Type validatorType)
        {
            if (!typeof(IValidator).IsAssignableFrom(validatorType))
            {
                throw new System.Exception("Bu doğrulama sınıfı değil");
            }

            _validatorType = validatorType;
        }
        protected override void OnBefore(IInvocation invocation) // MethodInterception aldım bu kodu (OnBefore)
        {
            var validator = (IValidator)Activator.CreateInstance(_validatorType);  // örneğin productValidator'un bir instancesini oluştur  // reflection => çalışma anına birşeyleri çalıştırmamızı sağlar

            var entityType = _validatorType.BaseType.GetGenericArguments()[0]; // productValidator çalışma tipini bul

            var entities = invocation.Arguments.Where(t => t.GetType() == entityType);
            foreach (var entity in entities)
            {
                ValidationTool.Validate(validator, entity);
            }
        }
    }
}
