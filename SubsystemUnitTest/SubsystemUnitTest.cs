using Microsoft.VisualStudio.TestTools.UnitTesting;
using SmartHouse;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SmartHouse.Tests
{
    [TestClass()]
    public class SubsystemUnitTest
    {
        [TestMethod]
        public void HVAC_SetTemperature_ShouldSetCorrectTemperature()
        {
            var hvac = new HVAC();
            double expected = 23.5;

            hvac.SetTemperature(expected);
            var actual = hvac.GetTemperature();

            Assert.AreEqual(expected, actual, "HVAC temperature should be set correctly.");
        }

        [TestMethod]
        public void HVAC_SetHumidity_ShouldSetCorrectHumidity()
        {
            var hvac = new HVAC();
            int expected = 50;

            hvac.SetHumidity(expected);
            var actual = hvac.GetHumidity();

            Assert.AreEqual(expected, actual, "HVAC humidity should be set correctly.");
        }

        [TestMethod]
        public void HVAC_TurnOn_ShouldEnableVentilation()
        {
            var hvac = new HVAC();

            hvac.TurnOn();
            var isOn = hvac.GetVentilationStatus();

            Assert.IsTrue(isOn, "HVAC ventilation should be turned on.");
        }

        [TestMethod]
        public void HVAC_TurnOff_ShouldDisableVentilation()
        {
            var hvac = new HVAC();

            hvac.TurnOn();
            hvac.TurnOff();
            var isOn = hvac.GetVentilationStatus();

            Assert.IsFalse(isOn, "HVAC ventilation should be turned off.");
        }

        // Lights Tests
        [TestMethod]
        public void Lights_SetBrightness_ShouldSetCorrectBrightness()
        {
            var lights = new Lights();
            int expected = 75;

            lights.SetBrightness(expected);
            var actual = lights.GetBrightness();

            Assert.AreEqual(expected, actual, "Lights brightness should be set correctly.");
        }

        [TestMethod]
        public void Lights_SetBrightness_ShouldNotAllowInvalidValue()
        {
            var lights = new Lights();

            lights.SetBrightness(150); 
            var actual = lights.GetBrightness();

            Assert.AreNotEqual(150, actual, "Lights should not accept invalid brightness values.");
        }

        [TestMethod]
        public void Lights_TurnOn_ShouldSetDefaultBrightness()
        {
            var lights = new Lights();

            lights.TurnOn();
            var brightness = lights.GetBrightness();

            Assert.AreEqual(50, brightness, "Lights should set default brightness to 50% when turned on.");
        }

        [TestMethod]
        public void Lights_TurnOff_ShouldSetBrightnessToZero()
        {
            var lights = new Lights();

            lights.TurnOff();
            var brightness = lights.GetBrightness();

            Assert.AreEqual(0, brightness, "Lights should set brightness to 0% when turned off.");
        }

        [TestMethod]
        public void AlarmSystem_Arm_ShouldActivateAlarm()
        {
            var alarm = new AlarmSystem();

            alarm.Arm();

            Assert.IsTrue(alarm.IsAlarmOn(), "Alarm should be armed.");
        }

        [TestMethod]
        public void AlarmSystem_Disarm_ShouldDeactivateAlarm()
        {
            var alarm = new AlarmSystem();

            alarm.Arm();
            alarm.Disarm();

            Assert.IsFalse(alarm.IsAlarmOn(), "Alarm should be disarmed.");
        }

        [TestMethod]
        public void Multimedia_SetVolume_ShouldSetCorrectValue()
        {
            var multimedia = new Multimedia();
            int expected = 30;

            multimedia.SetVolume(expected);
            var actual = multimedia.GetVolume();

            Assert.AreEqual(expected, actual, "Multimedia volume should be set correctly.");
        }

        [TestMethod]
        public void Multimedia_SetVolume_ShouldNotAllowInvalidValue()
        {
            var multimedia = new Multimedia();

            multimedia.SetVolume(-10); 
            var volume = multimedia.GetVolume();

            Assert.AreNotEqual(-10, volume, "Multimedia should not accept invalid volume values.");
        }

        [TestMethod]
        public void Multimedia_PlayMusic_ShouldEnableMusicPlaying()
        {
            var multimedia = new Multimedia();

            multimedia.PlayMusic("My Playlist");
            var isPlaying = multimedia.IsMusicPlay();

            Assert.IsTrue(isPlaying, "Music should start playing when PlayMusic is called.");
        }

        [TestMethod]
        public void Multimedia_StopMusic_ShouldDisableMusicPlaying()
        {
            var multimedia = new Multimedia();

            multimedia.PlayMusic("My Playlist");
            multimedia.StopMusic();
            var isPlaying = multimedia.IsMusicPlay();

            Assert.IsFalse(isPlaying, "Music should stop playing when StopMusic is called.");
        }

        [TestMethod]
        public void Curtains_Open_ShouldSetOpenState()
        {
            var curtains = new Curtains();

            curtains.Open();
            var isOpen = curtains.IsOpen();

            Assert.IsTrue(isOpen, "Curtains should be open after calling Open.");
        }

        [TestMethod]
        public void Curtains_Close_ShouldSetClosedState()
        {
            var curtains = new Curtains();

            curtains.Open();
            curtains.Close();
            var isOpen = curtains.IsOpen();

            Assert.IsFalse(isOpen, "Curtains should be closed after calling Close.");
        }
    }
}