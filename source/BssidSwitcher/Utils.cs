using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace BssidSwitcher
{
    class Utils
    {
        public static string MacStringify(byte[] mac)
        {
            if(mac.Length != 6)
            {
                throw new ArgumentException("MAC address not valid");
            }
            return string.Join(":", from m in mac select m.ToString("X2"));
        }

        public static void RunInUIThread(Control ctrl, Action action)
        {
            if(ctrl.InvokeRequired)
            {
                ctrl.Invoke(action);
            }
            else
            {
                action();
            }
        }

        public static int FrequencyToChannel(uint freqInKhz)
        {
            if(freqInKhz >= 2412000 && freqInKhz <= 2472000) // Channels 1-13 for 2.4GHz
            {
                return (int)((freqInKhz - 2407000) / 5000);
            }
            if(freqInKhz == 2484000) // Channel 14 for 2.4GHz
            {
                return 14;
            }
            if(freqInKhz >= 5180000 && freqInKhz <= 5825000) // 5GHz
            {
                return (int)((freqInKhz - 5000000) / 5000);
            }
            return 0; // Unknown
        }

    }
}
