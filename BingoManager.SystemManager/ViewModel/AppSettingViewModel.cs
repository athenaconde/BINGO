using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using BingoManager.SystemManager.Common;

namespace BingoManager.SystemManager.ViewModel
{
  public  class AppSettingViewModel :MainViewModel
    {

      public AppSettingViewModel() { }

      public List<string> Fonts
      { get { return AppSettings.Fonts;} }

      public string CurrentFont
      { get { return AppSettings.DefaultFont; } set { AppSettings.DefaultFont = value;} }

      public string TicketNumberFont
      { get { return AppSettings.TicketNumberFont; } set { AppSettings.TicketNumberFont = value; } }

      public Int32 NumbersOfBallsToWinJackpot
      { get { return AppSettings.DefaultNumberofBallJackpot; } set { AppSettings.DefaultNumberofBallJackpot = value; } }

      public bool IncludeGameHighLowBingo
      { get { return AppSettings.IncludeGameHighLowBingo; } set { AppSettings.IncludeGameHighLowBingo = value; } }

      public double JackpotPrize
      { get { return AppSettings.JackpotPrize; } set { AppSettings.JackpotPrize = value; } }

      public double SucceededAmount
      { get { return AppSettings.SucceededAmount; } set { AppSettings.SucceededAmount = value; } }

      public bool IsAdditionalAmount
      { get { return AppSettings.IsAdditionalPrize; } set { AppSettings.IsAdditionalPrize = value; } }

      public double HighBingoPrize
      { get { return AppSettings.HighBingoPrize; } set { AppSettings.HighBingoPrize= value;} }

      public double LowBingoPrize
      { get { return AppSettings.LowBingoPrize; } set { AppSettings.LowBingoPrize = value; } }

      public bool ShouldPrizeBeDividedOnWinners
      { get { return AppSettings.ShouldPrizeBeDividedOnWinners; } set { AppSettings.ShouldPrizeBeDividedOnWinners = value; } }




  }
}
