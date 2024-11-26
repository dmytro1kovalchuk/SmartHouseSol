using Moq;
using System.Security.Cryptography;
using SmartHouse;
 
namespace SmartHouse.UnitTest

{
    public class SmartHouseFacadeTests
    {
        private Mock<IHVAC> _mockHvac;
        private Mock<IAlarmSystem> _mockAlarm;
        private Mock<ICurtains> _mockCurtains;
        private Mock<IMultimedia> _mockMultimedia;
        private Mock<ILights> _mockLights;
        private SmartHouseFacade _smartHouseFacade;

        public SmartHouseFacadeTests()
        {
            // Створення мок-об'єктів для залежностей
            _mockHvac = new Mock<IHVAC>();
            _mockAlarm = new Mock<IAlarmSystem>();
            _mockCurtains = new Mock<ICurtains>();
            _mockMultimedia = new Mock<IMultimedia>();
            _mockLights = new Mock<ILights>();

            // Ініціалізація SmartHouseFacade з мок-об'єктами через конструктор
            _smartHouseFacade = new SmartHouseFacade(
                _mockHvac.Object,
                _mockAlarm.Object,
                _mockCurtains.Object,
                _mockMultimedia.Object,
                _mockLights.Object
            );
        }

        [Fact]
        public void TestMorningPreset()
        {
            // Act
            _smartHouseFacade.MorningPreset();

            // Assert
            _mockHvac.Verify(h => h.SetTemperature(22), Times.Once);
            _mockHvac.Verify(h => h.SetHumidity(50), Times.Once);
            _mockHvac.Verify(h => h.TurnOn(), Times.Once);
            _mockLights.Verify(l => l.TurnOff(), Times.Once);
            _mockMultimedia.Verify(m => m.SetVolume(30), Times.Once);
            _mockMultimedia.Verify(m => m.PlayMusic("Музика ранкової мотивації"), Times.Once);
            _mockAlarm.Verify(a => a.Disarm(), Times.Once);
            _mockCurtains.Verify(c => c.Open(), Times.Once);
        }

        [Fact]
        public void TestDayPreset()
        {
            // Act
            _smartHouseFacade.DayPreset();

            // Assert
            _mockHvac.Verify(h => h.SetTemperature(22), Times.Once);
            _mockHvac.Verify(h => h.SetHumidity(50), Times.Once);
            _mockHvac.Verify(h => h.TurnOn(), Times.Once);
            _mockLights.Verify(l => l.TurnOff(), Times.Once);
            _mockMultimedia.Verify(m => m.StopMusic(), Times.Once);
            _mockAlarm.Verify(a => a.Disarm(), Times.Once);
            _mockCurtains.Verify(c => c.Close(), Times.Once);
        }

        [Fact]
        public void TestEveningPreset()
        {
            // Act
            _smartHouseFacade.EveningPreset();

            // Assert
            _mockHvac.Verify(h => h.SetTemperature(22), Times.Once);
            _mockHvac.Verify(h => h.SetHumidity(60), Times.Once);
            _mockHvac.Verify(h => h.TurnOn(), Times.Once);
            _mockLights.Verify(l => l.TurnOn(), Times.Once);
            _mockLights.Verify(l => l.SetBrightness(70), Times.Once);
            _mockMultimedia.Verify(m => m.SetVolume(30), Times.Once);
            _mockMultimedia.Verify(m => m.PlayMusic("Evening Jazz"), Times.Once);
            _mockAlarm.Verify(a => a.Disarm(), Times.Once);
            _mockCurtains.Verify(c => c.Open(), Times.Once);
        }

        [Fact]
        public void TestNightPreset()
        {
            // Act
            _smartHouseFacade.NightPreset();

            // Assert
            _mockHvac.Verify(h => h.SetTemperature(18), Times.Once);
            _mockHvac.Verify(h => h.SetHumidity(60), Times.Once);
            _mockHvac.Verify(h => h.TurnOn(), Times.Once);
            _mockLights.Verify(l => l.TurnOff(), Times.Once);
            _mockMultimedia.Verify(m => m.StopMusic(), Times.Once);
            _mockAlarm.Verify(a => a.Arm(), Times.Once);
            _mockCurtains.Verify(c => c.Close(), Times.Once);
        }

        [Fact]
        public void TestLeaveFromHome()
        {
            // Act
            _smartHouseFacade.LeaveFromHome();

            // Assert
            _mockHvac.Verify(h => h.TurnOff(), Times.Once);
            _mockLights.Verify(l => l.TurnOff(), Times.Once);
            _mockMultimedia.Verify(m => m.StopMusic(), Times.Once);
            _mockAlarm.Verify(a => a.Arm(), Times.Once);
            _mockCurtains.Verify(c => c.Close(), Times.Once);
        }

        [Fact]
        public void TestReturnToHome()
        {
            // Act
            _smartHouseFacade.ReturnToHome();

            // Assert
            _mockHvac.Verify(h => h.TurnOn(), Times.Once);
            _mockHvac.Verify(h => h.SetTemperature(22), Times.Once);
            _mockHvac.Verify(h => h.SetHumidity(50), Times.Once);
            _mockAlarm.Verify(a => a.Disarm(), Times.Once);
            _mockCurtains.Verify(c => c.Open(), Times.Once);
            _mockLights.Verify(l => l.TurnOn(), Times.Once);
            _mockLights.Verify(l => l.SetBrightness(70), Times.Once);
        }
    }
}
