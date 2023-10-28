using System;
using System.Linq;
using System.Collections.ObjectModel;
using BingoManager.SystemManager.Model;
using BingoManager.SystemManager.Repository;
using System.Threading;
using BingoManager.SystemManager.Common;

namespace BingoManager.SystemManager.Engine
{
  public  class WinningCardsSearchManager:IDisposable
    {

      /// <summary>
      /// Constructor
      /// </summary>
      public WinningCardsSearchManager() { }

      
      public void Jackpotsearcher(ObservableCollection<PlayingCard> cards)

      {
          try
          {
              var jackpotcardQuery = from pc in cards
                                     where pc.B[0].Isball == true && pc.B[1].Isball == true &&
                                           pc.B[2].Isball == true && pc.B[3].Isball == true && pc.B[4].Isball == true
                                           &&
                                           pc.I[0].Isball == true && pc.I[1].Isball == true && pc.I[2].Isball == true &&
                                           pc.I[3].Isball == true && pc.I[4].Isball == true
                                           &&
                                           pc.N[0].Isball == true && pc.N[1].Isball == true && pc.N[3].Isball == true && pc.N[4].Isball == true
                                           &&
                                           pc.G[0].Isball == true && pc.G[1].Isball == true &&
                                           pc.G[2].Isball == true && pc.G[3].Isball == true && pc.G[4].Isball == true
                                           &&
                                           pc.O[0].Isball == true && pc.O[1].Isball == true && pc.O[2].Isball == true &&
                                           pc.O[3].Isball == true && pc.O[4].Isball == true
                                     select pc;
              if (jackpotcardQuery.Any())
              {
                  double equalprize = AppSettings.JackpotPrize ;
                  string msg = string.Empty;
                  if (AppSettings.ShouldPrizeBeDividedOnWinners)
                  {
                      equalprize = equalprize / jackpotcardQuery.Count();
                  }
                  foreach (var pc in jackpotcardQuery)
                  {
                      WinningCard jackpotcard = new WinningCard() { CardNumber = pc.SerialNumber, GameName = "Jackpot", Prize = equalprize, IsJackpot = true };
                       WinningCardsRepository.Cards.Add(jackpotcard);
                       msg = msg + string.Format("{0}          {1}\n", Microsoft.VisualBasic.Strings.Format(jackpotcard.CardNumber,"000000"), Microsoft.VisualBasic.Strings.FormatCurrency( jackpotcard.Prize));
                  }
                  System.Windows.MessageBox.Show("Ticket\t Prize\n" + msg, "Winner for the jackpot prize, Congratulations!", System.Windows.MessageBoxButton.OK, System.Windows.MessageBoxImage.Information);
              }
          }
          catch (InvalidOperationException) { }//the collection maybe modified. 

          catch (Exception) { } //general exception.
      }

      /// <summary>
      /// Search and match for a card from game card(s).
      /// </summary>
      /// <param name="gameCards"></param>
      /// <param name="playingCards"></param>
      /// <param name="state"></param>
      public  void CardMatcher(ObservableCollection<GameCard> gameCards, ObservableCollection<PlayingCard> playingCards)
      {
          WinningCardsRepository _winningCards = new WinningCardsRepository();
          try
          {
              bool IsWonGameCard = false; int i;
              for (i = 0; i < gameCards.Count;i++)
                 // foreach (GameCard gc in gameCards)
                  {
                      if (WinningCardsRepository.Cards.Count > 0)
                      {
                          var gameQuery = from wc in WinningCardsRepository.Cards where wc.GameName == gameCards[i].GameName select wc;
                          if (gameQuery.Any())
                          {
                              IsWonGameCard = true;

                              continue;
                          }
                          else { IsWonGameCard = false; }
                      }
                      if (!IsWonGameCard)
                      {
                          int ctrPC;
                          for(ctrPC=0;ctrPC<playingCards.Count;ctrPC++)

                        //  foreach (PlayingCard pc in playingCards)
                          {
                              //search for any jackpot card
                              //hasJackPot = pc.B[0].Isball && pc.B[1].Isball && pc.B[2].Isball && pc.B[3].Isball && pc.B[4].Isball &&
                              //             pc.I[0].Isball && pc.I[1].Isball && pc.I[2].Isball && pc.I[3].Isball && pc.I[4].Isball &&
                              //             pc.N[0].Isball && pc.N[1].Isball && pc.N[2].Isball && pc.N[3].Isball && pc.N[4].Isball &&
                              //             pc.G[0].Isball && pc.G[1].Isball && pc.G[2].Isball && pc.G[3].Isball && pc.G[4].Isball &&
                              //             pc.O[0].Isball && pc.O[1].Isball && pc.O[2].Isball && pc.O[3].Isball && pc.O[4].Isball;
                              //if(hasJackPot)
                              //{_winningCards.CurrentWinningCards.Add(new WinningCard(){ CardNumber=pc.SerialNumber, GameName=  gc.GameName, Price = gc.Price, IsJackpot =true});}
                              try
                              {
                                  var query1 = from wc in WinningCardsRepository.Cards where wc.CardNumber == playingCards[ctrPC].SerialNumber && wc.GameName == gameCards[i].GameName orderby wc.CardNumber select wc;
                                  if (!query1.Any())
                                  {
                                      bool win = true;
                                      int ctr; int ballCount = 0;
                                      for (ctr = 0; ctr <= 4; ctr++)
                                      {

                                          if (gameCards[i].B[ctr].Isball)
                                          {
                                              if (playingCards[ctrPC].B[ctr].Isball)
                                              {
                                                  ballCount++;
                                              }
                                              else { win = false; break; }
                                          }
                                          if (gameCards[i].I[ctr].Isball)
                                          {
                                              if (playingCards[ctrPC].I[ctr].Isball)
                                              {
                                                  ballCount++;
                                              }
                                              else
                                              { win = false; break; }
                                          }
                                          if (gameCards[i].N[ctr].Isball)
                                          {
                                              if (playingCards[ctrPC].N[ctr].Isball)
                                              {
                                                  ballCount++;
                                              }
                                              else { win = false; break; }
                                          }
                                          if (gameCards[i].G[ctr].Isball)
                                          {
                                              if (playingCards[ctrPC].G[ctr].Isball)
                                              {
                                                  ballCount++;
                                              }
                                              else { win = false; break; }
                                          }
                                          if (gameCards[i].O[ctr].Isball)
                                          {
                                              if (playingCards[ctrPC].O[ctr].Isball)
                                              {
                                                  ballCount++;
                                              }
                                              else { win = false; break; }
                                          }
                                      }
                                      //If wins, add to current winners.
                                      if (win)
                                      {

                                          bool _isFullhouse = false;
                                          if (ballCount == 25) { _isFullhouse = true; }
                                          WinningCard _newWinCard = new WinningCard() { CardNumber = playingCards[ctrPC].SerialNumber, GameName = gameCards[i].GameName, Prize = gameCards[i].Prize, IsJackpot = _isFullhouse };
                                          _winningCards.CurrentWinningCards.Add(_newWinCard);
                                          WinningCardsRepository.Cards.Add(_newWinCard);
                                      }
                                  }
                              }
                              catch (Exception) { }
                          }
                      }

                  }
          }
          catch (InvalidOperationException) { }
              ///Display the jackpot winning card, if any.
              string jackpotmsg = string.Empty;
              int c; int count = _winningCards.CurrentWinningCards.Count;
              for (c = 0; c < count; c++)
                  if (_winningCards.CurrentWinningCards[c].IsJackpot)
                  {
                      //foreach (WinningCard wc in query)
                      {
                          jackpotmsg = jackpotmsg + string.Format("This ticket number: {0} is FULL HOUSE!\n", Microsoft.VisualBasic.Strings.Format(_winningCards.CurrentWinningCards[c].CardNumber, "000000"));
                      }
                  }
              if (!string.IsNullOrEmpty(jackpotmsg)) { System.Windows.MessageBox.Show("Winner(s)!!!\n"+ jackpotmsg, "Winner!!!", System.Windows.MessageBoxButton.OK, System.Windows.MessageBoxImage.Information); }
             
          //Popup message box on  the screen to notify the user.

              var query2 = from wc in _winningCards.CurrentWinningCards where wc.IsJackpot == false orderby wc.CardNumber select wc;
              var groupquery = from wc in query2 group wc by wc.GameName into grps orderby grps.Key select grps;
                string message = string.Empty;
              int count2 = query2.Count();
            //  int ctr1 = 0;    
              //  int ctr2 = 1;
                foreach (var gwc in groupquery)
              {
                  foreach (var wc in gwc)
                  {
                      message = message + Microsoft.VisualBasic.Strings.Format(wc.CardNumber, "000000") + "\t";
                  }
                  System.Windows.MessageBox.Show("Below are the winning ticket number(s). Total count: " + Microsoft.VisualBasic.Strings.FormatNumber(gwc.Count(),0) + "\n" + message, gwc.Key + " winner(s)", System.Windows.MessageBoxButton.OK, System.Windows.MessageBoxImage.Information);
                  //if (count < 20)
                  //{
                  //    message = message + string.Format("{0}\t {1}\t {2}\n", Microsoft.VisualBasic.Strings.Format(wc.CardNumber, "000000"), wc.GameName, Microsoft.VisualBasic.Strings.FormatCurrency(wc.Prize));
                  //}
                  //else if (count < 50)
                  //{
                  //    if (ctr2 == 2)
                  //    {
                  //        message = message + string.Format("{0}\t {1}\t {2}\n", Microsoft.VisualBasic.Strings.Format(wc.CardNumber, "000000"), wc.GameName, Microsoft.VisualBasic.Strings.FormatCurrency(wc.Prize));
                  //        ctr2 = 1;
                  //    }
                  //    else
                  //    {
                  //        message = message + string.Format("{0}\t {1}\t {2}\t ", Microsoft.VisualBasic.Strings.Format(wc.CardNumber, "000000"), wc.GameName, Microsoft.VisualBasic.Strings.FormatCurrency(wc.Prize));
                  //        ctr2++;
                  //    }
                  //}
                  //else
                  //{ 
                  //    if (ctr2 == 3)
                  //    {
                  //        message = message + string.Format("{0}\t {1}\t {2}\n", Microsoft.VisualBasic.Strings.Format(wc.CardNumber, "000000"), wc.GameName, Microsoft.VisualBasic.Strings.FormatCurrency(wc.Prize));
                  //        ctr2 = 1;
                  //    }
                  //    else
                  //    {
                  //        message = message + string.Format("{0}\t {1}\t {2}\t ", Microsoft.VisualBasic.Strings.Format(wc.CardNumber, "000000"), wc.GameName, Microsoft.VisualBasic.Strings.FormatCurrency(wc.Prize));
                  //        ctr2++;
                  //    }
                  //}
              
                  //ctr1++;
                  //if (ctr1 == 120)
                  //{ ctr1 = 1; System.Windows.MessageBox.Show("Ticket#\t Game\t Prize\t Ticket#\t Game\t Prize\t Ticket#\t Game\t Prize\n" + message + "\n\n Next=>", "Winner[s] after that ball.", System.Windows.MessageBoxButton.OK, System.Windows.MessageBoxImage.Information); message = string.Empty; }
                  //if (ctr1==270)
                  //{ System.Windows.MessageBox.Show("Ticket#\t Game\t Price\t Ticket#\t Game\t Price\t Ticket#\t Game\t Price\n" + message + "\n\n Next=>", "Winner[s] after that ball.", System.Windows.MessageBoxButton.OK, System.Windows.MessageBoxImage.Information); message = string.Empty; }
               }
              //if (!string.IsNullOrEmpty(message))
              //{
              //    if (count < 20) { System.Windows.MessageBox.Show("Ticket#\t Game\t Prize\n" + message, "Winner[s] after that ball.", System.Windows.MessageBoxButton.OK, System.Windows.MessageBoxImage.Information); }
              //    else
              //    {
              //        if ((ctr1 <= 50))
              //        { System.Windows.MessageBox.Show("Ticket#\t Game\t Prize\t Ticket#\t Game\t Prize\n" + message, "Winner[s] after that ball.", System.Windows.MessageBoxButton.OK, System.Windows.MessageBoxImage.Information); message = string.Empty; }
              //        else { System.Windows.MessageBox.Show("Ticket#\t Game\t Prize\t Ticket#\t Game\t Prize\t Ticket#\t Game\t Prize\n" + message , "Winner[s] after that ball.", System.Windows.MessageBoxButton.OK, System.Windows.MessageBoxImage.Information); message = string.Empty; }
              //    }
              //}
              
              //AutoResetEvent reseter = (AutoResetEvent)state;
              //reseter.Set();
         
      }

      internal void HighLowBingoWinningTicketFinder(ObservableCollection<PlayingCard> cardrepository, int numberBall, bool IsHighBingo)

            {
               string msg = string.Empty;
                int ctr=0;
            string gamename =string.Empty;
            if (IsHighBingo)
                {
                    gamename = "High Bingo";
                    var query = from pc in cardrepository where pc.HighBingo.Number == numberBall select pc;
                    foreach (var pc in query)
                    {
                        pc.HighBingo.Isball = true;
                        WinningCard wc = new WinningCard() { CardNumber = pc.SerialNumber, GameName = "High Bingo", Prize = AppSettings.HighBingoPrize };
                        WinningCardsRepository.Cards.Add(wc);
                      //  msg = msg + string.Format("{0}       {1}", Microsoft.VisualBasic.Strings.Format(wc.CardNumber, "000000"), Microsoft.VisualBasic.Strings.FormatCurrency(wc.Prize));
                      // if (ctr == 4)
                       // { msg = msg + string.Format("{0}       {1}\n", Microsoft.VisualBasic.Strings.Format(wc.CardNumber, "000000"), Microsoft.VisualBasic.Strings.FormatCurrency(wc.Prize)); ctr = 0; }
                        ctr++;
                    }
                }
                else 
                {
                    gamename = "Low Bingo";
                    var query = from pc in cardrepository where pc.LowBingo.Number == numberBall select pc;
                    foreach (var pc in query)
                    {
                        pc.LowBingo.Isball = true;
                        WinningCard wc = new WinningCard() { CardNumber = pc.SerialNumber, GameName = "Low Bingo", Prize =AppSettings.LowBingoPrize };
                        WinningCardsRepository.Cards.Add(wc);
                       // msg = msg + string.Format("{0}       {1}", Microsoft.VisualBasic.Strings.Format(wc.CardNumber, "000000"), Microsoft.VisualBasic.Strings.FormatCurrency(wc.Prize));
                      //  if (ctr == 4)
                       // { msg = msg + string.Format("{0}       {1}\n", Microsoft.VisualBasic.Strings.Format(wc.CardNumber, "000000"), Microsoft.VisualBasic.Strings.FormatCurrency(wc.Prize)); ctr = 0; }
                      ctr++;
                    }
                }

                if (ctr > 0)
                {
                    try
                    {
                        var highlowingoQuery = from bl in WinningCardsRepository.Cards where bl.GameName == gamename orderby bl.CardNumber select bl;
                        foreach (var bl in highlowingoQuery)
                        {
                            msg = msg + Microsoft.VisualBasic.Strings.Format(bl.CardNumber, "000000") + "\t";

                        }
                        System.Windows.MessageBox.Show(string.Format("Total numbers of {0} winner(s): {1} \n{2}", gamename, Microsoft.VisualBasic.Strings.FormatNumber(ctr, 0), msg), gamename + " winner(s)", System.Windows.MessageBoxButton.OK, System.Windows.MessageBoxImage.Information);
                    }
                    catch (InvalidOperationException) { }
                }
                // if (!string.IsNullOrEmpty(msg))
                 //   {
                 //       System.Windows.MessageBox.Show(gamename);  
                    //  System.Windows.MessageBox.Show(string.Format("Ticket       Prize      Ticket       Prize      Ticket       Prize      Ticket       Prize\n\n{0}", msg ),gamename,System.Windows.MessageBoxButton.OK,System.Windows.MessageBoxImage.Information);
                 //   }

            }

      /// <summary>
      /// Dispose/Release used resources
      /// </summary>
      public void Dispose()
      {
         
      }
    }
}
