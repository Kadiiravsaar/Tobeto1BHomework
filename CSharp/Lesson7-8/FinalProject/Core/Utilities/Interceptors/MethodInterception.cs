using Castle.DynamicProxy;

namespace Core.Utilities.Interceptors
{
    public class MethodInterception : MethodInterceptionBaseAttribute
    {
        protected virtual void OnBefore(IInvocation invocation) { }
        protected virtual void OnAfter(IInvocation invocation) { }
        protected virtual void OnException(IInvocation invocation, System.Exception e) { }
        protected virtual void OnSuccess(IInvocation invocation) { }




        public override void Intercept(IInvocation invocation)  // Invocation => Metotum
        {
            var isSuccess = true;
            OnBefore(invocation); // metottan önce çalıştır (metodun başında)
            try
            {
                invocation.Proceed();
            }
            catch (Exception e)
            {
                isSuccess = false;
                OnException(invocation, e); // Hata aldığında
                throw;
            }
            finally
            {
                if (isSuccess)
                {
                    OnSuccess(invocation); // başarılı olduğunda 
                }
            }
            OnAfter(invocation); // metottan sonra çalışsın
        }
    }
}
