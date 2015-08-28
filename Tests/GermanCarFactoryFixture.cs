using Domain.Domain;
using Factories.Factory;
using InterfaceActions.Actions;
using Moq;
using NUnit.Framework;

namespace Tests
{
    [TestFixture]
    public class GermanyCarFactoryFixture
    {
        [SetUp]
        public void Setup()
        {
            _mockNotifyUsersAction = new Mock<INotifyUsersAction>();
            _germanyCarFactory = new GermanyCarFactory(_mockNotifyUsersAction.Object);
        }

        //string name, int engineVol, int tankVol, string bodyType

        private string _name = "BMW";
        private string _bodyType = "sedan";
        private int _engineVol = 2000;
        private int _tankVol = 80;
        private GermanyCarFactory _germanyCarFactory;
        private Mock<INotifyUsersAction> _mockNotifyUsersAction;

        public void ActByCreatingGermanyCar()
        {
            _germanyCarFactory.CreateNewGermanyCar(_name, _engineVol, _tankVol, _bodyType);
        }

       [Test]
        public void ItShouldCallNotify()
        {
            _mockNotifyUsersAction.Setup(x => x.Notify(It.IsAny<GermanyCar>()));

            ActByCreatingGermanyCar();

            _mockNotifyUsersAction.Verify(x => x.Notify(It.IsAny<GermanyCar>()), Times.Once);
        }
    }
}