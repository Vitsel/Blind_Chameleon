﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using Microsoft.Win32;
using DeviceDrivers;
using BlindNet;
namespace Blind_Client.DeviceDriver
{
    public partial class DeviceDriverHelper
    {
        private BlindSocket BS;
        private BlindPacket BP;

        private string ApplyWay = "null";
        private bool usbBlockApply = false;
        private bool camBlockApply = false;
        public List<DEVICE_INFO> HardwareList;
        public HH_Lib hwh;

        ~DeviceDriverHelper()
        {
            BS.Close();
        }

        public DeviceDriverHelper()
        {
            hwh= new HH_Lib(); // 장치관리자 라이브러리관련 객체 생성
        }

        public void Run()
        {
            BS = new BlindSocket();
            BP = new BlindPacket();
            BS.ConnectWithECDH(BlindNetConst.ServerIP, BlindNetConst.WebDevicePort);

            while (true)
            {
                try
                {
                    BP = BS.CryptoReceive();// 아이디에 따른 장치제어 결과 받아옴
                }
                catch
                {
                    break;
                }
                BP.data = BlindNetUtil.ByteTrimEndNull(BP.data);
                string ReceiveByteToStringGender = Encoding.Default.GetString(BP.data);// 변환 바이트 -> string = default,GetString | string -> 바이트 = utf8,GetBytes

                //11 : USB,CAM 차단 | 10: USB만 차단 | 01: 웹캠만 차단 | 00 : 모두허용
                DeviceToggle(ReceiveByteToStringGender);

                Thread.Sleep(1000);
            }
        }

        public void DeviceToggle(string ApplyWay)
        {
            
            /*
             ApplyWay(적용방식) 앞숫자 : USB 뒷숫자 : CAM   | 0 : 허용  1: 차단
            값: 11 (USB,CAM 허용) | 값: 10 (USB만 허용) | 값 : 01 (CAM만 허용) | 값 : 00 (모두 허용)
            */
            if (this.ApplyWay != ApplyWay)
            {
                if (ApplyWay == "11")
                {
                    usbBlockApply = false;
                    camBlockApply = false;
                }
                else if (ApplyWay == "10")
                {
                    usbBlockApply = false;
                    camBlockApply = true;
                }
                else if (ApplyWay == "01")
                {
                    usbBlockApply = true;
                    camBlockApply = false;
                }
                else if (ApplyWay == "00")
                {
                    usbBlockApply = true;
                    camBlockApply = true;
                }
                this.ApplyWay = ApplyWay;

                HardwareList = hwh.GetAll();

                string usbRegLocation = "SOFTWARE\\Policies\\Microsoft\\Windows\\RemovableStorageDevices";
                string camRegLocation = "SYSTEM\\ControlSet001\\Services\\usbvideo";

                RegistryKey usbRegKey = Registry.LocalMachine.OpenSubKey(usbRegLocation, true);
                usbRegKey = Registry.LocalMachine.CreateSubKey(usbRegLocation);
                RegistryKey camRegKey = Registry.LocalMachine.OpenSubKey(camRegLocation, true);

                if (camRegKey == null)
                    camRegKey = Registry.LocalMachine.CreateSubKey(camRegLocation);

                if (usbBlockApply == true)
                    usbRegKey.SetValue("Deny_All", 1, RegistryValueKind.DWord); //레지 값 추가
                else
                {
                    string RegCheckValue = Convert.ToString(usbRegKey.GetValue("Deny_All"));
                    if(RegCheckValue=="1")
                       usbRegKey.DeleteValue("Deny_All");
                }

                if (camBlockApply == true)
                    camRegKey.SetValue("Start", 4, RegistryValueKind.DWord); //레지 값 추가
                else
                    camRegKey.SetValue("Start", 3, RegistryValueKind.DWord); //레지 값 추가

                int UsbVideoIndexNumber = 0;
                //string TempStr = "";
                foreach (var device in HardwareList)
                {
                    if(camBlockApply == true || camBlockApply == false)
                    { 
                    if (device.service == "usbvideo")
                    {
                            hwh.SetDeviceState(HardwareList[UsbVideoIndexNumber], false);
                            hwh.SetDeviceState(HardwareList[UsbVideoIndexNumber], true);
                            break;
                    }
                    UsbVideoIndexNumber++;
                        }
                }
                /* 현호화 회의하에 일단 보류
               TempStr = device.hardwareId;
               if (TempStr != "")
               {
                  if (TempStr.Substring(0, 7) == "USBSTOR")
                  {
                     MessageBox.Show(UsbVideoIndexNumber.ToString());
                     hwh.SetDeviceState(HardwareList[UsbVideoIndexNumber], false);
                     hwh.SetDeviceState(HardwareList[UsbVideoIndexNumber], true);
                     break;
                   }
               }*/
            }
         }

    }
}