
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Collections.ObjectModel;
using System.Data.OleDb;

using BingoManager.SystemManager.Model;
using BingoManager.SystemManager.AppControl;

namespace BingoManager.SystemManager.Engine
{
  public  class DataAccessManager
    {

      public DataAccessManager() { }

     
      /// <summary>
      /// Saves the Playing Cards Collection to the Database.
      /// </summary>
      /// <param name="playingCards"></param>
      public static void SavePlayingCards(ObservableCollection<PlayingCard> playingCards)
      {
          using ( OleDbConnection connection = ConnectionProvider.Connection())
          {
              OleDbCommand command = connection.CreateCommand();
              
              connection.Open();
              OleDbTransaction trans = connection.BeginTransaction();
              command.Transaction = trans;
              try
              {
                  //Clears the records.
                  command.CommandText = "Delete from PlayingCards";
                  command.ExecuteNonQuery();
                  command.CommandText = "Delete from PlayingCardsHeader";
                  command.ExecuteNonQuery();
                  //Insert tne records to DB.
                  foreach (PlayingCard pc in playingCards)
                  {
                      command.CommandText = string.Format("Insert Into PlayingCardsHeader(SerialNumberID,ControlNumber,HighBingoNumber,LowBingoNumber) Values({0},{1},{2},{3})",
                                                          pc.SerialNumber,pc.ControlCardNumber,pc.HighBingo.Number,pc.LowBingo.Number);
                      command.ExecuteNonQuery();
                      int i;
                      for (i = 0; i <= 4; i++)
                      {
                          command.CommandText = string.Format("Insert Into PlayingCards(SerialNumber,B,I,N,G,O) Values({0},{1},{2},{3},{4},{5})",pc.SerialNumber, pc.B[i].Number, pc.I[i].Number, pc.N[i].Number, pc.G[i].Number, pc.O[i].Number);
                          command.ExecuteNonQuery();
                      }
                  }
                  trans.Commit();
              }
              catch (OleDbException)
              {
                  trans.Rollback();
              }
              catch (InvalidOperationException)
              {
                  trans.Rollback();
              }
              catch (Exception)
              {
                  trans.Rollback();
              }
          }
      }

      /// <summary>
      /// Gets the playing cards from the database.
      /// </summary>
      /// <returns></returns>
      public static ObservableCollection<PlayingCard> GetPlayingCards()
      {
          ObservableCollection<PlayingCard> _playingCards = null;
          using (OleDbConnection connection = ConnectionProvider.Connection())
          {
              OleDbCommand command = connection.CreateCommand();

              
              //The record count must be 750,000. If record count is below 750,000 the record will be use as the data.
               command.CommandText = string.Format("Select count(*) from PlayingCards");
               try
               {
                   connection.Open();
                   int count = (int)command.ExecuteScalar();
                   if (count.Equals(750000))
                   {
                       _playingCards = new ObservableCollection<PlayingCard>();
                       command.CommandText = string.Format("Select h.*,d.* from PlayingCards d Inner Join PlayingCardsHeader h On h.SerialNumberID=d.SerialNumber Order By d.ID");
                       using (OleDbDataReader datareader = command.ExecuteReader())
                       {
                           int i = 0;
                           PlayingCard _newGameCard = null;
                           while (datareader.Read())
                           {
                               if (_newGameCard == null)
                               {
                                   _newGameCard = new PlayingCard();
                                   _newGameCard.B = new PairModel[] { new PairModel(0, false), new PairModel(0, false), new PairModel(0, false), new PairModel(0, false), new PairModel(0, false) };
                                   _newGameCard.I = new PairModel[] { new PairModel(0, false), new PairModel(0, false), new PairModel(0, false), new PairModel(0, false), new PairModel(0, false) };
                                   _newGameCard.N = new PairModel[] { new PairModel(0, false), new PairModel(0, false), new PairModel(0, true), new PairModel(0, false), new PairModel(0, false)};
                                   _newGameCard.G = new PairModel[] { new PairModel(0, false), new PairModel(0, false), new PairModel(0, false), new PairModel(0, false), new PairModel(0, false) };
                                   _newGameCard.O = new PairModel[] { new PairModel(0, false), new PairModel(0, false), new PairModel(0, false), new PairModel(0, false), new PairModel(0, false) };
                               }

                               _newGameCard.B[i].Number =System.Convert.ToInt32( datareader["B"]);
                               _newGameCard.I[i].Number = System.Convert.ToInt32( datareader["I"]);
                               _newGameCard.N[i].Number = System.Convert.ToInt32( datareader["N"]);
                               _newGameCard.G[i].Number = System.Convert.ToInt32( datareader["G"]);
                               _newGameCard.O[i].Number = System.Convert.ToInt32( datareader["O"]);

                               i++;
                               if (i == 5)
                               {
                                   _newGameCard.SerialNumber = System.Convert.ToInt32( datareader["SerialNumber"]);
                                   _newGameCard.ControlCardNumber = System.Convert.ToInt32(datareader["ControlNumber"]);
                                   _newGameCard.HighBingo = new PairModel(System.Convert.ToInt32(datareader["HighBingoNumber"]),false);
                                   _newGameCard.LowBingo = new PairModel(System.Convert.ToInt32(datareader["LowBingoNumber"]),false);
                                   _playingCards.Add(_newGameCard);
                                   i = 0;
                                   _newGameCard = new PlayingCard();
                                   _newGameCard.B = new PairModel[] { new PairModel(0, false), new PairModel(0, false), new PairModel(0, false), new PairModel(0, false), new PairModel(0, false) };
                                   _newGameCard.I = new PairModel[] { new PairModel(0, false), new PairModel(0, false), new PairModel(0, false), new PairModel(0, false), new PairModel(0, false) };
                                   _newGameCard.N = new PairModel[] { new PairModel(0, false), new PairModel(0, false), new PairModel(0, true), new PairModel(0, false), new PairModel(0, false)};
                                   _newGameCard.G = new PairModel[] { new PairModel(0, false), new PairModel(0, false), new PairModel(0, false), new PairModel(0, false), new PairModel(0, false) };
                                   _newGameCard.O = new PairModel[] { new PairModel(0, false), new PairModel(0, false), new PairModel(0, false), new PairModel(0, false), new PairModel(0, false) };
                                   _newGameCard.B[i].Number = System.Convert.ToInt32(datareader["B"]);
                                   _newGameCard.I[i].Number = System.Convert.ToInt32(datareader["I"]);
                                   _newGameCard.N[i].Number = System.Convert.ToInt32(datareader["N"]);
                                   _newGameCard.G[i].Number = System.Convert.ToInt32(datareader["G"]);
                                   _newGameCard.O[i].Number = System.Convert.ToInt32(datareader["O"]);
                               }

                           }

                       }

                   }
               }
               catch (OleDbException ex)
               {
                   System.Windows.MessageBox.Show(ex.Message, "OLEDB:Exception: GetPlayingCards");
                   return null;
               }
               catch (Exception ex) { System.Windows.MessageBox.Show(ex.Message, "General Exception: GetPlayingCards");  return null; }


          }

          return _playingCards;
      }

      /// <summary>
      /// Saves the game card to the database permanently.
      /// </summary>
      /// <param name="gamecard"></param>
      public static void SaveGameCard(GameCard gamecard)
      {
          using (OleDbConnection connection = ConnectionProvider.Connection())
          {
              OleDbCommand command = connection.CreateCommand();
              OleDbTransaction trans=null;
              connection.Open();
              
              try
              {
                 
                  
                  command.CommandText = "Select max(ID) from GameCardsHeader";
                  int gameId=1;
                  using (OleDbDataReader datareader = command.ExecuteReader())
                  {
                      while (datareader.Read())
                      {
                          try
                          {
                              gameId = System.Convert.ToInt16(datareader[0]);
                              gameId++;  
                          }
                          catch (Exception) 
                          { 
                          }
                      }
                  }
                   trans = connection.BeginTransaction();
                  command.Transaction = trans;
                  command.CommandText = string.Format("Insert Into GameCardsHeader(ID,GameName,GamePrize) Values({0},'{1}',{2})",
                                                          gameId,gamecard.GameName, gamecard.Prize);
                  command.ExecuteNonQuery();
                   int i;
                  for (i = 0; i <= 4; i++)
                  {
                      command.CommandText = string.Format("Insert Into GameCardsDetail(GameID,B,I,N,G,O) Values({0},{1},{2},{3},{4},{5})", 
                                                            gameId,gamecard.B[i].Isball,gamecard.I[i].Isball,gamecard.N[i].Isball,gamecard.G[i].Isball,gamecard.O[i].Isball);
                      command.ExecuteNonQuery();
                 
                  }
                  //Commit changes.
                  trans.Commit();
              }
              catch (OleDbException ex)
                  //Rollback changes.
              { trans.Rollback(); System.Windows.MessageBox.Show(String.Format("Cannot save because error has occur.\n\nError : {0}",ex.Message),"Error from: " + ex.Source); }
          }
      }

      /// <summary>
      /// Gets the game cards from the database.
      /// </summary>
      /// <returns></returns>
      public static ObservableCollection<GameCard> GetGameCards()
      {
        ObservableCollection<GameCard> _gamecards = new ObservableCollection<GameCard>();
        using (OleDbConnection connection = ConnectionProvider.Connection())
            {
                try
                {
                    OleDbCommand command = connection.CreateCommand();
                    connection.Open();
                    command.CommandText = "Select h.*,d.* from GameCardsHeader h INNER Join GameCardsDetail d On d.GameID=h.ID";
                    using (OleDbDataReader datareader = command.ExecuteReader())
                    {
                        int i = 0;
                        GameCard _newgamecard = null;
                        while (datareader.Read())
                        {
                            if (_newgamecard == null)
                            {
                                _newgamecard = new GameCard();
                                _newgamecard.B = new PairModel[] { new PairModel(0, false), new PairModel(0, false), new PairModel(0, false), new PairModel(0, false), new PairModel(0, false) };
                                _newgamecard.I = new PairModel[] { new PairModel(0, false), new PairModel(0, false), new PairModel(0, false), new PairModel(0, false), new PairModel(0, false) };
                                _newgamecard.N = new PairModel[] { new PairModel(0, false), new PairModel(0, false), new PairModel(0, false), new PairModel(0, false), new PairModel(0, false) };
                                _newgamecard.G = new PairModel[] { new PairModel(0, false), new PairModel(0, false), new PairModel(0, false), new PairModel(0, false), new PairModel(0, false) };
                                _newgamecard.O = new PairModel[] { new PairModel(0, false), new PairModel(0, false), new PairModel(0, false), new PairModel(0, false), new PairModel(0, false) };
                            }
                            _newgamecard.B[i].Isball = (bool)datareader["B"];
                            _newgamecard.I[i].Isball = (bool)datareader["I"];
                            _newgamecard.N[i].Isball = (bool)datareader["N"];
                            _newgamecard.G[i].Isball = (bool)datareader["G"];
                            _newgamecard.O[i].Isball = (bool)datareader["O"];
                            i++;
                            if (i == 5)
                            {
                                _newgamecard.GameName = (string)datareader["GameName"];
                                _newgamecard.Prize =System.Convert.ToDouble( datareader["GamePrize"]);
                                _gamecards.Add(_newgamecard);
                                i = 0;
                                //Creates another game card.
                                _newgamecard = new GameCard();
                                _newgamecard.B = new PairModel[] { new PairModel(0, false), new PairModel(0, false), new PairModel(0, false), new PairModel(0, false), new PairModel(0, false) };
                                _newgamecard.I = new PairModel[] { new PairModel(0, false), new PairModel(0, false), new PairModel(0, false), new PairModel(0, false), new PairModel(0, false) };
                                _newgamecard.N = new PairModel[] { new PairModel(0, false), new PairModel(0, false), new PairModel(0, false), new PairModel(0, false), new PairModel(0, false) };
                                _newgamecard.G = new PairModel[] { new PairModel(0, false), new PairModel(0, false), new PairModel(0, false), new PairModel(0, false), new PairModel(0, false) };
                                _newgamecard.O = new PairModel[] { new PairModel(0, false), new PairModel(0, false), new PairModel(0, false), new PairModel(0, false), new PairModel(0, false) };
                                _newgamecard.B[i].Isball = (bool)datareader["B"];
                                _newgamecard.I[i].Isball = (bool)datareader["I"];
                                _newgamecard.N[i].Isball = (bool)datareader["N"];
                                _newgamecard.G[i].Isball = (bool)datareader["G"];
                                _newgamecard.O[i].Isball = (bool)datareader["O"];

                            }
                        }
                    }
                }
                catch (OleDbException ex)
                {
                    { System.Windows.MessageBox.Show(ex.Message, "Error from: GetGameCards"); }
                }
            }
          return _gamecards;
      }

      public static long DeleteGameCard(GameCard gamecard)
      {
          if (gamecard == null)
          { return 0; }
          long result = 0;
          using (OleDbConnection connection = ConnectionProvider.Connection())
          {
              OleDbCommand command = connection.CreateCommand();
              connection.Open();
              OleDbTransaction trans = connection.BeginTransaction();
              try
              {
                  command.Transaction = trans;
                  command.CommandText = string.Format("Delete from GameCardsHeader Where GameName='{0}'", gamecard.GameName);
                 result=command.ExecuteNonQuery();
                  trans.Commit();
              }
              catch (OleDbException ex) { trans.Rollback(); System.Windows.MessageBox.Show("Error : " + ex.Message, "DeleteGameCard"); }
          }
          return result;
      }

      internal static string GetSubcriptionId()
      {
          string _subscriptionId = string.Empty;
          using (OleDbConnection connection = ConnectionProvider.Connection())
          {
              OleDbCommand command = connection.CreateCommand();
              try
              {
                  command.CommandText = string.Format("Select Key From SubscriptionKeys where [MachineName]='{0}' AND [OSVersion]='{1}' AND [OSFullName]='{2}'",MachineInfoManager.GetMachineName(),MachineInfoManager.GetOSVersion(), MachineInfoManager.GetOSFullName() );
                  connection.Open();
                  _subscriptionId = command.ExecuteScalar().ToString();

              }
              catch (OleDbException) { }
              catch (Exception) { }
              finally
              {
                  AppControl.Subcription _subscription = new AppControl.Subcription();
                  var query = from i in _subscription.Subscriptions where i.ID == _subscriptionId select i;
                  if (!query.Any())
                  {
                      _subscriptionId = "unlicensed";
                  }
              }
          }

          return _subscriptionId;
      }

      /// <summary>
      /// Saves the license subscription ID.
      /// </summary>
      internal static long SaveSubscriptionID(string subscriptionID)
      {
          long result = 0;
          using (OleDbConnection connection = ConnectionProvider.Connection())
          {
              OleDbCommand command = connection.CreateCommand();
              OleDbTransaction trans = null;
              try
              {
                  connection.Open();
                  command.CommandText = string.Format("Select * From SubscriptionKeys where [Key]='{0}'",subscriptionID );
                  using (OleDbDataReader reader = command.ExecuteReader())
                    {
                        if (reader.HasRows == true)
                        {
                            //System.Windows.MessageBox.Show("Subscription key .\nTry again another key.","Invalid subscription key",System.Windows.MessageBoxButton.OK, System.Windows.MessageBoxImage.Warning);
                            reader.Dispose();
                            connection.Dispose();
                            return 0;
                        }
                    }
                  trans = connection.BeginTransaction();
                  command.Transaction = trans;
                 
                  command.CommandText = "Insert Into SubscriptionKeys([Key],[MachineName],[OsVersion],[OsFullName]) Values(@key,@machinename,@osver,@osname)";
                  command.Parameters.AddWithValue("key", subscriptionID);
                  command.Parameters.AddWithValue("machinename", MachineInfoManager.GetMachineName());
                  command.Parameters.AddWithValue("osver", MachineInfoManager.GetOSVersion());
                  command.Parameters.AddWithValue("osname", MachineInfoManager.GetOSFullName());
                  result= command.ExecuteNonQuery();
                  trans.Commit();
              }
              catch (OleDbException) { trans.Rollback(); }
          }
          return result;
      }


  }


}
