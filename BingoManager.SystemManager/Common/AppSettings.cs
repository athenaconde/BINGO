using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Collections.ObjectModel;

namespace BingoManager.SystemManager.Common
{
 public   class AppSettings
    {

     public AppSettings() { }



     static string _defaultFont = Fonts[10];
      static string _ticketnumberFont = Fonts[15];
     static Int32 _numberofballsjackpotdefault=24;
     static bool _includeGameHighLowBingo=true;
     static bool _isadditionalPrize=true;

     public static Int32 DefaultNumberofBallJackpot
     {
         get { return _numberofballsjackpotdefault; }
         set { _numberofballsjackpotdefault = value; }
     }

     public static string DefaultFont
       
     { get { return _defaultFont; } internal set { _defaultFont = value; } }

    /// <summary>
    /// Gets/Sets the the font for the ticket number.
    /// </summary>
     public static string TicketNumberFont

     { get { return _ticketnumberFont; } internal set { _ticketnumberFont = value; } }

     public static bool IncludeGameHighLowBingo
     { get { return _includeGameHighLowBingo; } set { _includeGameHighLowBingo = value; } }

    /// <summary>
    /// Gets/Sets the High bingo prize.
    /// </summary>
     public static double HighBingoPrize
     { get ; set; }

     /// <summary>
     /// Gets/Sets the low bingo prize.
     /// </summary>
     public static double LowBingoPrize
     { get; set; }

     /// <summary>
     /// Gets/sets the jackpot prize.
     /// </summary>
     public static double JackpotPrize
     { get; set; }

     internal static double currentJackpot
     { get; set; }

     public static double SucceededAmount
     { get; set; }

     public static bool IsAdditionalPrize
     { get { return _isadditionalPrize; } set { _isadditionalPrize = value; } }

     /// <summary>
     /// Gets/ sets the value whether the prize per game be divided by all winners for the particular game.
     /// </summary>
     public static bool ShouldPrizeBeDividedOnWinners
     { get; set; }
     
     static List<string> _fonts;
     public static List<string> Fonts
     { 
         get
         {
             if (_fonts == null)
             {
                 _fonts = new List<string>();
                 _fonts.Add("Algerian");
                 _fonts.Add("Arial");
                 _fonts.Add("Arial Black");
                 _fonts.Add("Arial Narrow");
                 _fonts.Add("Arial Narrow Special G1");
                 _fonts.Add("Calibri");
                 _fonts.Add("Calisto MT");
                 _fonts.Add("Cambria");
                 _fonts.Add("Cambria Math");
                 _fonts.Add("Candara");
                 _fonts.Add("Century");
                 _fonts.Add("Century Gothic");
                 _fonts.Add("Century Schoolbook");
                 _fonts.Add("Chiller");
                 _fonts.Add("Comic Sans MS");
                 _fonts.Add("Courier New");
                 _fonts.Add("Papyrus");
                 _fonts.Add("Perpetua");
                 _fonts.Add("Segoe UI");
                 _fonts.Add("Segoe UI Light");
                 _fonts.Add("Stencil");
                 _fonts.Add("Sylfaen");
                 _fonts.Add("Symbol");
                 _fonts.Add("Tahoma");
                 _fonts.Add("Times New Roman");
                 _fonts.Add("Times New Roman Special G1");
                 _fonts.Add("Times New Roman Special G2");
                 _fonts.Add("Traditional Arabic");
                 _fonts.Add("Verdana");
                 _fonts.Add("Wingdings");
                 _fonts.Add("Wingdings 2");
                 _fonts.Add("Wingdings 3");
             }
             return _fonts;
        }
     }
    }
}
