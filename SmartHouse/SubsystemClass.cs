using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SmartHouse
{
    public class HVAC : IHVAC
    {

        private double _temperature;  
        private int _humidity;     
        private bool _isVentilationOn;

        public void SetHumidity(int humidity)
        {
            _humidity = humidity;
            Console.WriteLine($"HVAC: Вологість встановлена на {_humidity}%.");
        }

        public void SetTemperature(double temperature)
        {
            _temperature = temperature;
            Console.WriteLine($"HVAC: Температура встановлена на {_temperature}°C.");
        }

        public void TurnOff()
        {
            _isVentilationOn = false;
            Console.WriteLine("HVAC: Система вентиляції вимкнена.");
        }

        public void TurnOn()
        {
            _isVentilationOn = true;
            Console.WriteLine("HVAC: Система вентиляції увімкнена.");
        }
        
        public int GetHumidity() => _humidity;
        public double GetTemperature() => _temperature;

        public bool GetVentilationStatus() => _isVentilationOn;
    }
    public class Lights : ILights
    {

        private int _brightness;

        

        public void TurnOff()
        {
            _brightness = 0;
            Console.WriteLine("Lights: Освітлення вимкнено.");
        }

        public void TurnOn()
        {
            _brightness = 50;
            Console.WriteLine("Lights: Освітлення увімкнено.");
        }



        public void SetBrightness(int brightness)
        {
            if (brightness < 0 || brightness > 100)
            {
                Console.WriteLine("Lights: Некоректний відсоток потужності. Значення має бути між 0 і 100.");
                return;
            }

            _brightness = brightness;
            Console.WriteLine($"Lights: Яскравість встановлена на {_brightness}%.");
        }

        public int GetBrightness()=> _brightness;
    }

    public class AlarmSystem : IAlarmSystem
    {

        private bool _isAlarmOn;

        public void Arm()
        {
            _isAlarmOn = true;
            Console.WriteLine("AlarmSystem: Сигналізація увімкнена.");
        }

        public void Disarm()
        {
            _isAlarmOn = false;
            Console.WriteLine("AlarmSystem: Сигналізація вимкнена.");
        }

        public bool IsAlarmOn() => _isAlarmOn;
    }


    public class Multimedia : IMultimedia
    {
        private int _volume;

        private bool _isMusicPlay;

        public void SetVolume(int volume)
        {
            if (volume < 0 || volume > 100)
            {
                Console.WriteLine("Multimedia: Некоректне значення гучності.");
                return;
            }

            _volume = volume;
            Console.WriteLine($"Multimedia: Гучність встановлена на {_volume}%.");
        }

        public int GetVolume() => _volume;

        public void PlayMusic(string playlist)
        {
            _isMusicPlay = true;

            Console.WriteLine($"Multimedia: Відтворення списку {playlist} на гучності {_volume}%.");

        }

        public void StopMusic()
        {
            _isMusicPlay = false;
            Console.WriteLine("Multimedia: Відтворення зупинено.");
        }

        public bool IsMusicPlay() => _isMusicPlay;

    }

    public class Curtains : ICurtains
    {
        private bool _isOpen;

        public void Open()
        {
            _isOpen = true;
            Console.WriteLine("Curtains: Штори відкрито.");
        }

        public void Close()
        {
            _isOpen = false;
            Console.WriteLine("Curtains: Штори закрито.");
        }

        public bool IsOpen() => _isOpen;
    }
}