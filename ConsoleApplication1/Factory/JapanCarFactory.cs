using Domain.Domain;
using InterfaceActions.Actions;

namespace Factories.Factory
{
    public class JapanCarFactory
    {
        private readonly INotifyUsersAction2 _notifyUsersAction;

        public JapanCarFactory(INotifyUsersAction2 notifyUsersAction)
        {
            _notifyUsersAction = notifyUsersAction;
        }

        public JapanCar CreateNewJapanCar(string name, int engineVol, int tankVol, string bodyType)
            //Action<IProductOptions> optionalParams)
        {
            var japanCar = new JapanCar(name, engineVol, tankVol, bodyType);
            OnJapanCarCreation(japanCar);
            return japanCar;
        }

        public void OnJapanCarCreation(JapanCar japanCar)
        {
            _notifyUsersAction.Notify(japanCar);
        }
    }
}