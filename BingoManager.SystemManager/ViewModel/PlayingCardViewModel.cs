using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Input;
using System.Collections.ObjectModel;
using System.Threading;
using System.ComponentModel;
using BingoManager.SystemManager.Model;
using BingoManager.SystemManager.Repository;
using BingoManager.SystemManager.Commands;
using BingoManager.SystemManager.Engine;
using BingoManager.SystemManager.Common;

namespace BingoManager.SystemManager.ViewModel
{
 public class PlayingCardViewModel:MainViewModel,IDisposable,INotifyPropertyChanged

    {

     /// <summary>
     /// Constructors.
     /// </summary>
     /// <param name="playCard"></param>
     /// <param name="playingCardRepository"></param>
     /// <param name="gameCardRepository"></param>
     public PlayingCardViewModel(PlayingCard playCard, PlayingCardRepository playingCardRepository, GameCardsRepository gameCardRepository)
     {
         if (playCard == null)
         { throw new ArgumentNullException("playCard"); }

         if (playingCardRepository == null)
         { throw new ArgumentNullException("playingCardRepository"); }

         if (gameCardRepository == null)
         { throw new ArgumentNullException("gameCardRepository"); }
         _playingCard = playCard;
         _playingCardRepository = playingCardRepository;
         _gameCardRepository = gameCardRepository;
     }


     #region Fields
     ObservableCollection<PlayingModel> _bNumbers;
     ObservableCollection<PlayingModel> _GameBalls;
     ObservableCollection<PlayingModel> _iNumbers;
     ObservableCollection<PlayingModel> _nNumbers;
     ObservableCollection<PlayingModel> _gNumbers;
     ObservableCollection<PlayingModel> _oNumbers;
     GameCard _newGameCard;
     PlayingCard _playingCard;
     GameCard _selectedGameCard;
     PlayingCard _selectedCard;
     PlayingCardRepository _playingCardRepository;
     GameCardsRepository _gameCardRepository;
     ObservableCollection<WonGameCard> _wonGameCards;
    // Timer WonGameMoveTimer;
     ICommand _setBallCommand;
     ICommand _createNewGame;
     ICommand _saveGameCommand;
     ICommand _removeGameCommand;
     ICommand _blackenedCommand;
     ICommand _resetGamesCommand;
     ICommand refreshlistCommand;
     #endregion //Constructors

     #region Properties


     /// <summary>
     /// Gets the subscription id.
     /// </summary>
     public string SubscriptionId
     {
         get
         { return DataAccessManager.GetSubcriptionId(); }
     }

     public string Company
     {
         get
         { return "[Company]"; }
     }
     /// <summary>
     /// Gets the PlayingCards.
     /// </summary>
     public ObservableCollection<PlayingCard> PlayingCards
     {
         get { return _playingCardRepository.Cards;}
     }

     public PlayingCard SelectedCard
     {
         get { return _selectedCard; }
         set {
             _selectedCard = value;
             if (ShouldSelectedCardBeRemoved)
             {
                 _playingCardRepository.Cards.Remove(_selectedCard);
                 _selectedCard = null;
             }
            }
     }

     public bool ShouldSelectedCardBeRemoved
     { get; set; }

     public ObservableCollection<GameCard> GameCards
     {
         get { return _gameCardRepository.Cards; }
     }

     public GameCard SelectedGameCard
     { get { return _selectedGameCard; }
         set
         {
             //if (value.Equals(_selectedGameCard)) { return; }
             _selectedGameCard = value;
             OnPropertyChanged("SelectedGameCard");
         }
     }
     
     /// <summary>
     /// Gets the game cards have been won.
     /// </summary>
     public ObservableCollection<WonGameCard> WonGameCards
     { get 
         {
             if (_wonGameCards == null)
             {
                 _wonGameCards = new ObservableCollection<WonGameCard>();
             }
             return _wonGameCards; 
         } 
     
     }


     public GameCard NewGameCard
     {
         get
         {
             return _newGameCard;
         }
         set
         {
             _newGameCard = value; OnPropertyChanged("NewGameCard");
            
         }
     }

     public ObservableCollection< PlayingModel> BNumbers
     { get 
         {
             if (_bNumbers == null)
             {
                 _bNumbers = new ObservableCollection< PlayingModel>();
                 int i;
                 for (i = 0; i <= 19; i++)
                 {
                     _bNumbers.Add(new PlayingModel() { B = new PairModel(i, false) });
                 }
             }
             return _bNumbers;
         } 
     }

     public ObservableCollection<PlayingModel> INumbers
     {
         get
         {
             if(_iNumbers==null)
             {
                 _iNumbers = new ObservableCollection<PlayingModel>();
             int i;
             for (i = 20; i <= 39; i++)
             {
                 _iNumbers.Add(new PlayingModel() { B = new PairModel(i, false) });
             }    
             }
             return _iNumbers;
          }
     }

     public ObservableCollection<PlayingModel> NNumbers
     {
         get
         {
             if (_nNumbers == null)
             {
                 _nNumbers = new ObservableCollection<PlayingModel>();
                 int i;
                 for (i = 40; i <= 59; i++)
                 {
                     _nNumbers.Add(new PlayingModel() { B = new PairModel(i, false) });
                 }
             }
             
             return _nNumbers; 
         }
     }

     public ObservableCollection<PlayingModel> GNumbers
     {
         get
         {
             if (_gNumbers == null)
             {
                 _gNumbers = new ObservableCollection<PlayingModel>();
                 int i;
                 for (i = 60; i <= 79; i++)
                 {
                     _gNumbers.Add(new PlayingModel() { B = new PairModel(i, false) });
                 }
             }
             return _gNumbers;
        }
     }

     public ObservableCollection<PlayingModel> ONumbers
     {
         get
         {

               if (_oNumbers == null)
             {
                 _oNumbers = new ObservableCollection<PlayingModel>();
                 int i;
                 for (i = 80; i <= 99; i++)
                 {
                     _oNumbers.Add(new PlayingModel() { B = new PairModel(i, false) });
                 }
                 }
             return _oNumbers;
           }
     }

    
     /// <summary>
     /// Gets the collection of game balls.
     /// </summary>
     public ObservableCollection<PlayingModel> GameBalls
     {
         get
         {
             if (_GameBalls == null)
             { _GameBalls = new ObservableCollection<PlayingModel>(); }
             return _GameBalls;
         }
     }
        #region ICommand
     public ICommand SetBallCommand
     {
         get 
         {
             if (_setBallCommand == null)
             { _setBallCommand = new RelayCommand(delegate { this.SetBall(this); }, delegate { return true; }); }//,param=>this.canSetBall(param)); }
             return _setBallCommand;
         }
         
     }

     /// <summary>
     /// Creates new game command.
     /// </summary>
     public ICommand CreateGameCommand
     {
         get
         {
             if (_createNewGame == null)
             {
                 _createNewGame = new RelayCommand(delegate { this.CreateGame(); }, delegate { return this.CanExecuteCreate(); });
             }
             return _createNewGame;
         }
     }

     /// <summary>
     /// Saves the new create game permanently.
     /// </summary>
     public ICommand SaveGameCommand
     {
         get 
         
         {
             if (_saveGameCommand == null)
             { _saveGameCommand = new RelayCommand(delegate { this.SaveGameCard(); }, delegate { return this.CanSaveGame(); }); }
             return _saveGameCommand;
         }
     }

     public ICommand RemoveGameCard
     {
         get
         {
             if (_removeGameCommand == null)
             { _removeGameCommand = new RelayCommand(delegate { this.RemovegameCard(); }, delegate { return this.canExecuteRemovingGamecard(); }); }
             return _removeGameCommand;
         }

     }

     /// <summary>
     /// ICommand that shades or blackened the current bingo card section.
     /// </summary>
     public ICommand BLackenedCommand
     {
         get
         {
             if (_blackenedCommand == null)
             { _blackenedCommand = new RelayCommand(param => this.BlackenedNumber(param), param => this.canExecuteBlackenedCommand(param)); }
             return _blackenedCommand;
         }
     }

     /// <summary>
     /// ICommand that will reset the games.
     /// </summary>
     public ICommand ResetGamesCommand
     {
         get
         {
             if (_resetGamesCommand == null)
             { _resetGamesCommand = new RelayCommand(delegate { this.ResetGames(); }, delegate { return true;}); }
             return _resetGamesCommand;
         }
     }


     public ICommand RefreshListCommand
     {
         get 
         {
             if (refreshlistCommand == null)
             { refreshlistCommand = new RelayCommand(delegate { MoveWonGame(this); }, delegate { return true; }); }
             return refreshlistCommand;
         }
     }
        #endregion //ICommand

     #endregion //Properties

        #region Methods

     /// <summary>
     /// Determines whether SetBall can execute.
     /// </summary>
     /// <param name="param"></param>
     /// <returns></returns>
   public  bool canSetBall(Object param)
     {
         if (param!=null)
         {
             var query = from pair in GameBalls where pair.B.Number == System.Convert.ToUInt16(param) select pair;
             return !query.Any();
         }
         return true;
     }
     
     /// <summary>
     /// Mark the  selected number on the tally board.
     /// </summary>
     /// <param name="param"></param>
   public void SetBall(object param)
   {
       bool IsJackpotWon=false;
       if (WinningCardsRepository.Cards.Count > 0)
       {
           try
           {
               var jackpotQuery = from jackpot in WinningCardsRepository.Cards where jackpot.GameName == "Jackpot" select jackpot;
               IsJackpotWon = jackpotQuery.Any();
           }
           catch (InvalidOperationException) 
           {
               var jackpotQuery = from jackpot in WinningCardsRepository.Cards where jackpot.GameName == "Jackpot" select jackpot;
               IsJackpotWon = jackpotQuery.Any();
           }
       }
       if (!IsJackpotWon)
       {
           if (System.Convert.ToUInt16(param) >= 0 && System.Convert.ToUInt16(param) <= 99)
           {
               _GameBalls.Add(new PlayingModel() { B = new PairModel(System.Convert.ToUInt16(param), true) });

               //Starts a process from another thread.
               Thread thread = new Thread(MarkCardNumber_As_gameBall);
               thread.Start(param);
               this.MoveWonGame(this);
               var queryB = from b in BNumbers where b.B.Number == System.Convert.ToUInt16(param) select b;
               if (queryB.Any())
               {
                   queryB.First().B.Isball = true;
                   return;
               }

               var queryI = from b in INumbers where b.B.Number == System.Convert.ToUInt16(param) select b;
               if (queryI.Any())
               {
                   queryI.First().B.Isball = true;
                   return;
               }

               var queryN = from b in NNumbers where b.B.Number == System.Convert.ToUInt16(param) select b;
               if (queryN.Any())
               {
                   queryN.First().B.Isball = true;
                   return;
               }

               var queryG = from b in GNumbers where b.B.Number == System.Convert.ToUInt16(param) select b;
               if (queryG.Any())
               {
                   queryG.First().B.Isball = true;
                   return;
               }

               var queryO = from b in ONumbers where b.B.Number == System.Convert.ToUInt16(param) select b;
               if (queryO.Any())
               {
                   queryO.First().B.Isball = true;
                   return;
               }
           }
           
          
       }
   }

     /// <summary>
     /// Mark the number on each playing card that matches on the ball number.
     /// </summary>
     /// <param name="param"></param>
     void MarkCardNumber_As_gameBall(object param)
     {
         PairModel _playModel = new PairModel(System.Convert.ToInt16(param), false);
         if (System.Convert.ToInt16(param) < 20)
         {
             var query = from i in _playingCardRepository.Cards.AsParallel().AsOrdered() select i.B;
             foreach (PairModel[] pm in query)
             {
                 foreach (PairModel i in pm)
               {
                   if (i.Number.Equals(System.Convert.ToInt16(param))) { i.Isball = true; }
               }
             }
         }
         else if (System.Convert.ToInt16(param) >= 20 && System.Convert.ToInt16(param) <40)
         {
             var query = from i in _playingCardRepository.Cards.AsParallel().AsOrdered()  select i.I;
             foreach (PairModel[] pm in query)
             {
                 foreach (PairModel i in pm)
                 {
                     if (i.Number.Equals(System.Convert.ToInt16(param))) { i.Isball = true; }
                 }
             }
         }
          else if (System.Convert.ToInt16(param) >= 40 && System.Convert.ToInt16(param) <60)
         {
             var query = from i in _playingCardRepository.Cards.AsParallel().AsOrdered()  where i.N.Rank!=2 select i.N;
             foreach (PairModel[] pm in query)
             {
                 foreach (PairModel i in pm)
                 {

                     if (i.Number.Equals(System.Convert.ToInt16(param))) { i.Isball = true; }
                  
                 }
             }
             
         }
         else if (System.Convert.ToInt16(param) >= 60 && System.Convert.ToInt16(param) < 80)
         {
             var query = from i in _playingCardRepository.Cards.AsParallel().AsOrdered()  select i.G;
             foreach (PairModel[] pm in query)
             {
                 foreach (PairModel i in pm)
                 {

                     if (i.Number.Equals(System.Convert.ToInt16(param))) { i.Isball = true; }

                 }
             }
         }
         else if (System.Convert.ToInt16(param) >= 80 && System.Convert.ToInt16(param) < 100)
         {
             var query = from i in _playingCardRepository.Cards.AsParallel().AsOrdered()  select i.O;
             foreach (PairModel[] pm in query)
             {
                 foreach (PairModel i in pm)
                 {

                     if (i.Number.Equals(System.Convert.ToInt16(param))) { i.Isball = true; }

                 }
             }
         }
         else {}//Nothing

         ///Play HighLow Bingo thread
         //if (GameBalls.Count > 0 && GameBalls.Count <= 2)
         //{
         //    if (System.Convert.ToInt16(param) >= 0 && System.Convert.ToInt16(param) <= 10)
         //    {
         //        if (AppSettings.IncludeGameHighLowBingo)
         //        {
         //            //Executes the HighLowBingo
         //            Thread thread3 = new Thread(PlayHighLowBingo);
         //            thread3.IsBackground = true;
         //            thread3.Start(GameBalls.Count == 1);
         //        }
         //    }
         //}
         //Execute the matching card searcher
         // if (matchingCardCrawler == null)
         //  {

      
         Thread thread2 = new Thread(searchMatchingCardCrawlerCallback);
         thread2.Start();

         if (GameBalls.Count == AppSettings.DefaultNumberofBallJackpot)
         {
             Thread threadJackpotSearcher = new Thread(JackpotWinnerSearcher);
             threadJackpotSearcher.IsBackground = true;
             threadJackpotSearcher.Start();
         }

        
         }
            
     /// <summary>
     /// Finding out which card(s) win the HighLow Bingo.
     /// </summary>
     /// <param name="threadParam"></param>
     void PlayHighLowBingo(object threadParam)
     {
         
     }

     void JackpotWinnerSearcher()
     {
         if (_GameBalls.Count() <= AppSettings.DefaultNumberofBallJackpot)
         {
             using (WinningCardsSearchManager searchmanager = new WinningCardsSearchManager())
             {
                 searchmanager.Jackpotsearcher(_playingCardRepository.Cards);
             }
             //int Succeededballscount = _GameBalls.Count - AppSettings.DefaultNumberofBallJackpot;
             //if (AppSettings.IsAdditionalPrize)
             //{
             //    AppSettings.currentJackpot = AppSettings.JackpotPrize + (AppSettings.SucceededAmount * Succeededballscount);
             //}
             //else
             //{
             //    AppSettings.currentJackpot = AppSettings.JackpotPrize - (AppSettings.SucceededAmount * Succeededballscount);
             //}
         }
         //else 
         //{
         //    AppSettings.currentJackpot = AppSettings.JackpotPrize;
         //}
        
     }

     //void CreateTheTimer()
     //{
     //    AutoResetEvent reseter = new AutoResetEvent(false);
     //    WonGameMoveTimer = new Timer(new TimerCallback(MoveWonGame), reseter, 100,1000);
     //    reseter.WaitOne();
     //}

     /// <summary>
     /// It will always search for any card that match with the game card(s).
     /// Once a card matches, a nofitication popup will notify the user that a certain playing card win.
     /// </summary>
     /// <param name="state"></param>
     void searchMatchingCardCrawlerCallback(object state)
     {
         using (WinningCardsSearchManager searchmanager = new WinningCardsSearchManager())
         { 
         searchmanager.CardMatcher(_gameCardRepository.Cards, _playingCardRepository.Cards);
         }
        
     }

     void MoveWonGame(object sender)
     {
        
         int i;int count=GameCards.Count;
         for (i = 0; i < GameCards.Count; i++)
         {
             var IswinQuery = from wc in WinningCardsRepository.Cards where wc.GameName == GameCards[i].GameName select wc;
             if (IswinQuery.Any())
             {
                 WonGameCard newWonGame = new WonGameCard() { GameName = GameCards[i].GameName, WinnerCount = IswinQuery.Count(), PrizeEach = GameCards[i].Prize / IswinQuery.Count(), Prize = GameCards[i].Prize, Tickets = new List<PlayingCard>() };
                 foreach(WinningCard wg in IswinQuery)
                 {
                    var query = from pc in _playingCardRepository.Cards where pc.SerialNumber==wg.CardNumber select pc;
                     newWonGame.Tickets.Add(query.First());
                 }
                 WonGameCards.Add(newWonGame);
                 GameCards.Remove(GameCards[i]);
             }
         }
        
     }

   public  bool canExecuteBlackenedCommand(object param)
     {
         return true;
     }


     /// <summary>
     /// Blackened the selected number on the new game card.
     /// </summary>
     public void BlackenedNumber(object param)
     {
         if (System.Convert.ToUInt16(param) <= 5)
         {
             var query = from b in NewGameCard.B where b.Number == System.Convert.ToUInt16(param) select b;
             if (query.Any())
             {
                 if (query.First().Isball==true) { query.First().Isball = false; }
                 query.First().Isball = true; 
             }
         }
         else if (System.Convert.ToUInt16(param) > 5 && System.Convert.ToUInt16(param) <= 10)
         {
             var query = from i in NewGameCard.I where i.Number == System.Convert.ToUInt16(param) select i;
             if (query.Any())
             {
                 if (query.First().Isball==true) { query.First().Isball = false; }
                 query.First().Isball = true;
             }
         }
         else if (System.Convert.ToUInt16(param) >10 && System.Convert.ToUInt16(param) <= 15)
         {
             var query = from n in NewGameCard.N where n.Number == System.Convert.ToUInt16(param) select n;
             if (query.Any())
             {
                 if (query.First().Isball==true) { query.First().Isball = false; }
                 query.First().Isball = true;
             }
           
         }
         else if (System.Convert.ToUInt16(param) >15 && System.Convert.ToUInt16(param) <=20)
         {
             var query = from n in NewGameCard.G where n.Number == System.Convert.ToUInt16(param) select n;
             if (query.Any())
             {
                 if (query.First().Isball==true) { query.First().Isball = false; }
                 query.First().Isball = true;
             }
         }
         else if (System.Convert.ToUInt16(param) >20 && System.Convert.ToUInt16(param) <=25)
         {
             var query = from o in NewGameCard.O where o.Number == System.Convert.ToUInt16(param) select o;
             if (query.Any())
             {
                 if (query.First().Isball==true) { query.First().Isball = false; }
                 query.First().Isball = true;
             }
         }
     }

     /// <summary>
     /// Determines whether the execution of the SaveGame function is enabled.
     /// </summary>
     /// <returns></returns>
    public bool CanSaveGame()
     {
         if (_newGameCard == null)
         { return false; }
         if (string.IsNullOrEmpty(_newGameCard.GameName))
         { return false; }
         if (_newGameCard.Prize.Equals(0))
         { return false; }
         return true;
     }

   public   bool CanExecuteCreate()
     {
         return true;
     }
      
     /// <summary>
     /// Execute the creation of game.
     /// </summary>
       public  void CreateGame()
     {
         _newGameCard = new GameCard();
         _newGameCard.B = new PairModel[] { new PairModel(1, false), new PairModel(2, false), new PairModel(3, false), new PairModel(4, false), new PairModel(5, false) };
         _newGameCard.I = new PairModel[] { new PairModel(6, false), new PairModel(7, false), new PairModel(8, false), new PairModel(9, false), new PairModel(10, false) };
         _newGameCard.N = new PairModel[] { new PairModel(11, false), new PairModel(12, false), new PairModel(13, false), new PairModel(14, false), new PairModel(15, false) };
         _newGameCard.G = new PairModel[] { new PairModel(16, false), new PairModel(17, false), new PairModel(18, false), new PairModel(19, false), new PairModel(20, false) };
         _newGameCard.O = new PairModel[] { new PairModel(21, false), new PairModel(22, false), new PairModel(23, false), new PairModel(24, false), new PairModel(25, false) };
         OnPropertyChanged("NewGameCard");       
     }

     /// <summary>
     /// Saves the new created game permanently, also it will be added to the collection of Game cards.
     /// </summary>
     public void SaveGameCard()
     {
         try
         {
             DataAccessManager.SaveGameCard(_newGameCard);
             _gameCardRepository.Cards.Add(_newGameCard);
             NewGameCard = null;
         }
         catch (Exception) { }
     }

     /// <summary>
     /// Determines whether the remove command can execute.
     /// </summary>
     /// <returns></returns>
    public   bool canExecuteRemovingGamecard()
     {
         return _selectedGameCard != null;
     }


     /// <summary>
     /// Remove the selected gamecard from the list permanently.
     /// </summary>
   public  void RemovegameCard()
     {
         try
         {
             if (DataAccessManager.DeleteGameCard(_selectedGameCard) > 0)
             {
                 _gameCardRepository.Cards.Remove(_selectedGameCard);
                 SelectedGameCard = null;
             }
         }
         catch (Exception) { }
      
     }

     /// <summary>
     /// The current game will be reset.
     /// </summary>
   public void ResetGames()
    {
        foreach (PlayingModel pm in BNumbers)
        {
            pm.B.Isball = false;
        }
        foreach (PlayingModel pm in INumbers)
        {
            pm.B.Isball = false;
        }
        foreach (PlayingModel pm in NNumbers)
        {
            pm.B.Isball = false;
        }
        foreach (PlayingModel pm in GNumbers)
        {
            pm.B.Isball = false;
        }
        foreach (PlayingModel pm in ONumbers)
        {
            pm.B.Isball = false;
        }
       //Reset GameBalls
        GameBalls.Clear();
       //Reset PlayingCards
        var query = from pc in _playingCardRepository.Cards select pc;
        foreach(PlayingCard i in query)
        {
            i.B[0].Isball = false; i.B[1].Isball = false; i.B[2].Isball = false; i.B[3].Isball = false; i.B[4].Isball = false;
            i.I[0].Isball = false; i.I[1].Isball = false; i.I[2].Isball = false; i.I[3].Isball = false; i.I[4].Isball = false;
            i.N[0].Isball = false; i.N[1].Isball = false; i.N[3].Isball = false; i.N[4].Isball = false;
            i.G[0].Isball = false; i.G[1].Isball = false; i.G[2].Isball = false; i.G[3].Isball = false; i.G[4].Isball = false;
            i.O[0].Isball = false; i.O[1].Isball = false; i.O[2].Isball = false; i.O[3].Isball = false; i.O[4].Isball = false;
        }

        var result = System.Windows.MessageBox.Show("Would you like to clear/reset also the winning cards list?","Resetting winning cards list.",System.Windows.MessageBoxButton.YesNo,System.Windows.MessageBoxImage.Question);
        if (result == System.Windows.MessageBoxResult.Yes)
        {
            WinningCardsRepository.Cards.Clear();
        }
     
    }

     /// <summary>
     /// Removes the playing cards, from the playing list, that were not sold.
     /// </summary>
     /// <param name="cardnumber_from"></param>
     /// <param name="cardnumber_to"></param>
     /// 
    public void RemoveExcessCards(int cardnumber_from, int cardnumber_to)
   {
       try
       {
            int i;
            for (i = cardnumber_from; i <= cardnumber_to; i++)
           {
               var querydelete = from pc in _playingCardRepository.Cards   where pc.SerialNumber == i select pc;
               RemovePlayingCard(querydelete.First());
           }
        }
       catch (Exception ex) { global::System.Windows.MessageBox.Show("Errror on: RemoveExcessCards {0}" + ex.Message); }
   }
  

     /// <summary>
     /// Removes the playing card.
     /// </summary>
     /// <param name="card"></param>
   void RemovePlayingCard(PlayingCard card)
    {
        _playingCardRepository.RemoveCard(card);
       OnPropertyChanged("PlayingCards");
    }

     /// <summary>
     /// Raises the PropertyChanged event.
     /// </summary>
     /// <param name="properyName"></param>
     void OnPropertyChanged(string properyName)
     {
        if(PropertyChanged!=null)
        {PropertyChanged(this,new PropertyChangedEventArgs(properyName));}
     }
        #endregion //Methods


     /// <summary>
     /// Determines whether the application has an approved license.
     /// </summary>
     /// <returns></returns>
     public bool IsLicensed()
     {
         return DataAccessManager.GetSubcriptionId()!="unlicensed";
     }

     public long RegisterApplication(string key)
     {
        AppControl.Subcription subscription = new AppControl.Subcription();
        var query = from i in subscription.Subscriptions where i.Key == key select i;
        if (query.Any())
        {
            return DataAccessManager.SaveSubscriptionID(query.First().ID);
        }
        return 0;
     }
     
     public void Dispose()
     {
         _gameCardRepository = null;
         _playingCardRepository = null;
         
       //  matchingCardCrawler.Dispose();
     }

     public event PropertyChangedEventHandler PropertyChanged;
    }
}
