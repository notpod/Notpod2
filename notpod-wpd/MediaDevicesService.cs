using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Notpod.Domain;

namespace Notpod.Connectors
{
    public interface MediaDevicesService<T>
    {
        string[] GetDeviceIds();
        T GetDeviceById(string deviceId);
    }
}
