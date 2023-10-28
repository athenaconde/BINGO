using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Collections.ObjectModel;

using BingoManager.SystemManager.Model;

namespace BingoManager.SystemManager.Repository
{
    /// <summary>
    /// Storage of winning cards.
    /// </summary>
 public   class WinningCardsRepository
    {

     /// <summary>
     /// Constructor
     /// </summary>
     public WinningCardsRepository() { }

     #region Fields
     ObservableCollection<WinningCard> _currentWinningCards;  
     static ObservableCollection<WinningCard> _cards;
     #endregion //Fields

     public static  ObservableCollection<WinningCard> Cards
     {
         get
         {
             if (_cards == null)
             { _cards=new ObservableCollection<WinningCard>();}
            return _cards;
         }
     }

     /// <summary>
     /// Gets the current winning cards in queu.
     /// </summary>
     public ObservableCollection<WinningCard> CurrentWinningCards
     {
         get 
         {
             if (_currentWinningCards == null)
             { _currentWinningCards = new ObservableCollection<WinningCard>(); }
             return _currentWinningCards;
         }
         
     }
 }
}
