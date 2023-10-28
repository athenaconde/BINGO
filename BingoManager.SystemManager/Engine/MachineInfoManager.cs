using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.VisualBasic;

namespace BingoManager.SystemManager.Engine
{
  public sealed  class MachineInfoManager
    {

      public MachineInfoManager() { }

    static  Microsoft.VisualBasic.Devices.Computer machine = new Microsoft.VisualBasic.Devices.Computer();

       internal static string GetOSVersion()
      {
         
          return machine.Info.OSVersion;
      }


      internal static string GetOSFullName()
      {
          return machine.Info.OSFullName;
      }

      internal static string GetMachineName()
      {
          return machine.Name;
      }
    }
}
