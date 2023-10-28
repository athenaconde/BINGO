using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using BingoManager.SystemManager.Model;
using BingoManager.SystemManager.Repository;
using BingoManager.SystemManager.Engine;
using BingoManager.SystemManager.Common;
using System.Collections.ObjectModel;
using System.Threading;

namespace BingoManager.SystemManager.ViewModel
{
    public class HighLowBingo : MainViewModel
    {

        public HighLowBingo( PlayingCardRepository cardrepository)
        
        {
            if (cardrepository == null)

            {
                throw new ArgumentNullException("cardrepository");
            }

            _cardREpository = cardrepository;
        }


        List<int> _h;
        List<int> _l;
        ObservableCollection<WonGameCard> _WonGameCards;
        PlayingCardRepository _cardREpository;
        List<int> _numberOfBalls;

        public List<int> HighBingoNumbers
        {
            get
            {
                if (_h == null)
                {
                    _h = new List<int>();
                    int i;
                    for (i = 0; i <= 9; i++)
                    {
                        _h.Add(i);
                    }

                }
                return _h;
            }
        }

        public List<int> lowBingoNumbers
        {
            get
            {
                if (_l == null)
                {
                    _l = new List<int>();
                    int i;
                    for (i = 0; i <= 9; i++)
                    {
                        _l.Add(i);
                    }

                }
                return _l;
            }
        }

        public ObservableCollection<WonGameCard> WonGameCards
        {
            get
            {
                if (_WonGameCards == null)
                {
                    _WonGameCards = new ObservableCollection<WonGameCard>();
                }
                return _WonGameCards;
            }


        }

        #region Methods

        public bool CanSetBall(object param)
        {
            if (param==null){return true;}
            if (_numberOfBalls == null) { return true; }
            var query = from ball in _numberOfBalls where ball.ToString() == param.ToString() select ball;
            if (query.Any()) { return false; }
            return _numberOfBalls.Count > 0 && _numberOfBalls.Count <= 2;
        }

        public void SetballHigh(object param)
        {

            if (_numberOfBalls == null)
            {
                _numberOfBalls = new List<int>();
            }
            if (_numberOfBalls.Count >= 0 && _numberOfBalls.Count<=2)
            {
                _numberOfBalls.Add(System.Convert.ToInt32(param));

                Thread thread = new Thread(SearcherThread);
                thread.Start(param);
            }
        }


        public void SetballLow(object param)
        {
           int num = System.Convert.ToInt32(param);
            using (WinningCardsSearchManager searchmanager = new WinningCardsSearchManager())
            {
                searchmanager.HighLowBingoWinningTicketFinder(_cardREpository.Cards,num, _numberOfBalls.Count==1);
            }
         //   MoveWonGame();
        }

        void SearcherThread(object state)
        {
            int num = System.Convert.ToInt32(state);
            using (WinningCardsSearchManager searchmanager = new WinningCardsSearchManager())
            {
                searchmanager.HighLowBingoWinningTicketFinder(_cardREpository.Cards, num, true);
            }
        }

     public   void MoveWonGame()
        {
            double prize; string game=string.Empty;
            if (_numberOfBalls.Count==1)
            {
                game = "High Bingo";
                prize = AppSettings.HighBingoPrize;
            }
            else { prize = AppSettings.LowBingoPrize; game = "Low Bingo"; }

                var IswinQuery = from wc in WinningCardsRepository.Cards where wc.GameName == game select wc;
                if (IswinQuery.Any())
                {
                    WonGameCard newWonGame = new WonGameCard() { GameName = game, WinnerCount = IswinQuery.Count(), PrizeEach = prize / IswinQuery.Count(), Prize = prize, Tickets = new List<PlayingCard>() };
                    foreach (WinningCard wg in IswinQuery)
                    {
                        var query = from pc in _cardREpository.Cards where pc.SerialNumber == wg.CardNumber select pc;
                        newWonGame.Tickets.Add(query.First());
                    }
                    WonGameCards.Add(newWonGame);
          
            }

        }
        #endregion //MEthods
    }
}