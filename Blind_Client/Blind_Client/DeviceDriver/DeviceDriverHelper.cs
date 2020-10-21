using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Microsoft.Win32;
using DeviceDriver;
namespace Blind_Client
{
    public class DeviceDriverHelper
    {
        HH_Lib hwh = new HH_Lib(); // 장치관리자 라이브러리관련 객체 생성
        List<DEVICE_INFO> HardwareList;

        public void DeviceToggle(string Type, bool value)
        {
            HardwareList = hwh.GetAll();

            string UsbVideoRegLocation = "";
            if(Type == "WebCam")
                UsbVideoRegLocation="SYSTEM\\ControlSet001\\Services\\usbvideo";
            else // USB일때
                UsbVideoRegLocation= "SOFTWARE\\Policies\\Microsoft\\Windows\\RemovableStorageDevices";

                RegistryKey RegKey = Registry.LocalMachine.OpenSubKey(UsbVideoRegLocation, true);
            if (RegKey == null)
            {
                MessageBox.Show("Registry Not Open");
                return;
            }
                RegKey = Registry.LocalMachine.CreateSubKey(UsbVideoRegLocation);

            if (Type == "WebCam")
            {
                if (value == true)
                    RegKey.SetValue("Start", 4, RegistryValueKind.DWord);
                else
                    RegKey.SetValue("Start", 3, RegistryValueKind.DWord);
            }
            else //USB이면
            {
                if (value == true)
                    RegKey.SetValue("Deny_All", 1, RegistryValueKind.DWord);
                else
                    RegKey.DeleteValue("Deny_All");
            }

            int UsbVideoIndexNumber = 0;
            //string TempStr = "";
            foreach (var device in HardwareList)
            {
                if (Type == "WebCam")
                {
                    if (device.service == "usbvideo")
                    {
                        hwh.SetDeviceState(HardwareList[UsbVideoIndexNumber], false);
                        hwh.SetDeviceState(HardwareList[UsbVideoIndexNumber], true);
                        break;
                    }
                }
                else // USB인 경우
                {
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
                    }
                    */
                }
                UsbVideoIndexNumber++;
            }

        }
    }
}