using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BingoManager.SystemManager.Model
{
    /// <summary>
    /// A class which will be used to store winning playing card.
    /// </summary>
    public  class WinningCard
    {

    /// <summary>
    /// Constructor
    /// </summary>
    public WinningCard() { }


    /// <summary>
    /// Gets/Sets the winning card number.
    /// </summary>
    public long CardNumber
    { get; set; }
   /// <summary>
   /// Gets/Sets the name of game card.
   /// </summary>
    public string GameName
    { get; set; }

    /// <summary>
    /// Gets/Sets the price of the game.
    /// </summary>
    public double Prize
    { get; set; }

    public bool IsJackpot
    { get; set; }

    }
}
