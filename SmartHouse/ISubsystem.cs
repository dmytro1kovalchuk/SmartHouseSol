using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SmartHouse
{
    public interface IHVAC
    {
        void TurnOn();
        void TurnOff();
        void SetTemperature(double temperature);

        void SetHumidity(int humidity);


    }

    public interface ILights
    {
        void TurnOn();
        void TurnOff();

        void SetBrightness(int brightness);

    }

    public interface IAlarmSystem
    {
        void Arm();
        void Disarm();
    }

    public interface IMultimedia
    {
        void PlayMusic(string playlist);
        void StopMusic();

        void SetVolume(int volume);
    }

    public interface ICurtains
    {
        void Open();
        void Close();
    }
}
