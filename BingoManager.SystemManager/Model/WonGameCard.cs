using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BingoManager.SystemManager.Model
{
  public  class WonGameCard
    {

      public WonGameCard() { }

      public string GameName { get; set; }

      public int WinnerCount { get; set; }

      public double PrizeEach { get; set; }

      public double Prize { get; set; }

      public List<PlayingCard> Tickets { get; set; }
    }
}
