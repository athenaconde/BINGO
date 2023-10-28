using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Collections.ObjectModel;
using BingoManager.SystemManager.Model;
using BingoManager.SystemManager.Engine;

namespace BingoManager.SystemManager.Repository
{
   public class GameCardsRepository
    {

       /// <summary>
       /// Contructor.
       /// </summary>
       public GameCardsRepository() { }

       ObservableCollection<GameCard> _gameCards;

       /// <summary>
       /// Gets all game cards saved.
       /// </summary>
       public ObservableCollection<GameCard> Cards

            {       get
                {
                     if(_gameCards==null)
                        {
                         _gameCards = DataAccessManager.GetGameCards();
                        }
                        return _gameCards;
                }
           }

       public void AddNewGameCard(GameCard gameCard)
       {
           if (gameCard == null)
           { return; }
           _gameCards.Add(gameCard);
       }

       public bool HasContains(GameCard gameCard)
       {
           return _gameCards.Contains(gameCard);
       }

    }
}
