using ActionImplementations;
using InterfaceActions.Actions;
using Ninject;

namespace Infrastructure.IoC
{
   internal static class ServiceLocator
    {
        private static readonly IKernel Kernel = new StandardKernel();

        public static void RegisterAll()
        {
            Kernel.Bind<INotifyUsersAction>().To<EmailNotification>();
            Kernel.Bind<INotifyUsersAction2>().To<SmsNotification>();
        }

        public static T Get<T>()
        {
            return Kernel.Get<T>();
        }
    }

}
