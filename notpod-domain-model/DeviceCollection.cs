﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml.Serialization;

namespace Notpod.Domain
{
    [XmlRoot("devicecollection")]
    public class DeviceCollection
    {

        private List<Device> devices = new List<Device>();

        [XmlElement("devices")]
        public List<Device> Devices
        {
            set { devices = value; }
            get { return devices; }
        }

        public Device GetDeviceWithIdentifier(string identifier)
        {
            foreach(Device device in devices) {

                if (device.Identifier == identifier)
                {
                    return device;
                }
            }

            return null;
        }

        public void DeleteByIdentifier(string identifier)
        {
            for (int i = 0; i < devices.Count; i++)
            {
                if (devices[i].Identifier == identifier)
                {
                    devices.RemoveAt(i);
                }

            }
        }

    }
}
