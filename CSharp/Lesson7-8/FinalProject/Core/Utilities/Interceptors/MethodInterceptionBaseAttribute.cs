using Castle.DynamicProxy;


namespace Core.Utilities.Interceptors// Interceptors   yol kesmek demek
{

    // *************************** classlara | metotlara ekleyebilirsin, birden fazla ekleyebilirsin, inherit edilen noktada da çalışsın

    [AttributeUsage(AttributeTargets.Class | AttributeTargets.Method, AllowMultiple = true, Inherited = true)]
    public abstract class MethodInterceptionBaseAttribute : Attribute, IInterceptor
    {
        public int Priority { get; set; } // hangi attribute önce çalışsın. Sıralama için

        public virtual void Intercept(IInvocation invocation) //  Invocation => metot demek bunu unutma
        {
            // ne yapacağını boş bıraktım ilerde doludurcam
        }
    }
}
