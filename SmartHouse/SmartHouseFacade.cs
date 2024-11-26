using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SmartHouse
{
    public class SmartHouseFacade : ISmartHouseFacade
    {
        protected IHVAC _hvac;
        protected IAlarmSystem _alarm;
        protected ICurtains _curtains;
        protected IMultimedia _multimedia;
        protected ILights _lights;

        public SmartHouseFacade(IHVAC hvac, IAlarmSystem alarm, ICurtains curtains, IMultimedia multimedia, ILights lights)
        {
            _hvac = hvac;
            _alarm = alarm;
            _curtains = curtains;
            _multimedia = multimedia;
            _lights = lights;
        }

       
   

        public void MorningPreset()
        {
            _hvac.SetTemperature(22);
            _hvac.SetHumidity(50);
            _hvac.TurnOn();
            _lights.TurnOff();
            _multimedia.SetVolume(30);
            _multimedia.PlayMusic("Музика ранкової мотивації");
            _alarm.Disarm();
            _curtains.Open();
        }

        public void DayPreset()
        {
            _hvac.SetTemperature(22);
            _hvac.SetHumidity(50);
            _hvac.TurnOn();
            _lights.TurnOff();
            _multimedia.StopMusic();
            _alarm.Disarm();
            _curtains.Close();
        }
        public void EveningPreset()
        {
            _hvac.SetTemperature(22);
            _hvac.SetHumidity(60);
            _hvac.TurnOn();
            _lights.TurnOn();
            _lights.SetBrightness(70);
            _multimedia.SetVolume(30);
            _multimedia.PlayMusic("Evening Jazz");
            _alarm.Disarm();
            _curtains.Open();
        }
        public void NightPreset()
        {
            _hvac.SetTemperature(18);
            _hvac.SetHumidity(60);
            _hvac.TurnOn();
            _lights.TurnOff();
            _multimedia.StopMusic();
            _alarm.Arm();
            _curtains.Close();
        }
        public void LeaveFromHome()
        {
            _hvac.TurnOff();
            _lights.TurnOff();
            _multimedia.StopMusic();
            _alarm.Arm();
            _curtains.Close();
        }
        public void ReturnToHome()
        {
            _hvac.TurnOn();
            _hvac.SetTemperature(22);
            _hvac.SetHumidity(50);
            _alarm.Disarm();
            _curtains.Open();
            _lights.TurnOn();
            _lights.SetBrightness(70);
        }



    }
}
