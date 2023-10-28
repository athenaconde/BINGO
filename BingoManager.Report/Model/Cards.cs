using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BingoManager.SystemManager.Model
{
  public  class Cards
    {

      public Cards() { }

      public string SerialNumber{ get; set; }
      
      public int B { get; set; }

      public int I { get; set; }

      public int N { get; set; }

      public int G { get; set; }

      public int O {get;set;}

      public static Cards GetInstance()

      {return new Cards(); }
    }
}
