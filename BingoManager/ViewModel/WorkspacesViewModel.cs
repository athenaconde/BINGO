using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Collections.ObjectModel;

using System.Windows.Input;

using BingoManager.SystemManager.Commands;
using BingoManager.SystemManager.ViewModel;
using BingoManager.SystemManager.Model;
using BingoManager.SystemManager.Common;
using System.ComponentModel;

namespace BingoManager.ViewModel
{
  public  class WorkspacesViewModel:INotifyPropertyChanged

    {

        ObservableCollection<MainViewModel> _workspaces;
        MainViewModel _currentWorkspace;
        ICommand _showBingoGameControlCommand;
        ICommand _CreateGameCommand;
        ICommand _RemoveCardCommand;
        ICommand _showSettingsCommand;
        ICommand _highLowbingoCommand;
        public ObservableCollection<MainViewModel> Workspaces
        {
            get
            {
                if (_workspaces == null)
                {
                    _workspaces = new ObservableCollection<MainViewModel>();
                  //  App.PlaycardViewModel.DisplayName = "Bingo game control";
                   
                    _workspaces.CollectionChanged += new System.Collections.Specialized.NotifyCollectionChangedEventHandler(_workspaces_CollectionChanged);
                //    _workspaces.Add(App.PlaycardViewModel);
                 //   CurrentWorkspace = App.PlaycardViewModel;
                }
                return _workspaces;
            }
        }

       
      /// <summary>
      /// Gets/Sets the current workspace.
      /// </summary>
        public MainViewModel CurrentWorkspace
        { get { return _currentWorkspace; } set { _currentWorkspace=value;OnPropertyChanged("CurrentWorkspace"); } }

      /// <summary>
      /// Gets the license ID.
      /// </summary>
 
      public string LicenseID
        { get { return App.PlaycardViewModel.SubscriptionId; } }

      #region ICommand
        public ICommand ShowBingoControlCommand
        {
            get
            {
                if (_showBingoGameControlCommand == null)
                {
                    _showBingoGameControlCommand = new RelayCommand(param=>this.ShowBingoControl(), param=>this.CanShowBingoControl());
                }
                return _showBingoGameControlCommand;
            }
        }

        public ICommand RemoveCardCommand
        {
            get
            {
                if (_RemoveCardCommand == null)
                {
                    _RemoveCardCommand = new RelayCommand(delegate { ShowCardRemoverView(); });
                }
                return _RemoveCardCommand;
            }
        }

        public ICommand CreateGameCommand

        {
            get
            {
                if (_CreateGameCommand == null)
                {
                    _CreateGameCommand = new RelayCommand(delegate { CreateGame(); }, delegate { return CanCreateGame(); });
                }
                return _CreateGameCommand;
            }
        }

        public ICommand ShowSettingsCommand
        {
            get
            {
                if (_showSettingsCommand == null)
                { _showSettingsCommand = new RelayCommand(delegate { CreateGame(); }, delegate { return CanCreateGame(); }); }
                return _showSettingsCommand;
            }
        }

        public ICommand PlayHighLowBingoCommand
        {
            get
            {
                if (_highLowbingoCommand == null)
                { _highLowbingoCommand = new RelayCommand(delegate { PlayHighLowBingo(); }); }
                return _highLowbingoCommand;
            }
        }
        #endregion //ICommand

        bool CanShowBingoControl()
            {
               // return true; //create unlimited view.
                if (Workspaces.Count > 0)
                {
                    var query = from i in Workspaces where i.DisplayName == "Bingo game control" select i;
                    return !query.Any();
                }
                return true;
            }

        void ShowBingoControl()
        {
            try
            {
                _workspaces.Add(App.PlaycardViewModel);
                CurrentWorkspace = App.PlaycardViewModel;
            }
            catch(Exception)
            {}
        }

       public bool CanCreateGame()
        { return App.PlaycardViewModel.NewGameCard == null; }
        
        public  void CreateGame()
        {
            //App.PlaycardViewModel.CreateGame();
            //App.PlaycardViewModel.NewGameCard.DisplayName = "New game";
            //_workspaces.Add(App.PlaycardViewModel.NewGameCard);
            //CurrentWorkspace = App.PlaycardViewModel.NewGameCard;

        }

        public bool CanShowRemoverView()
            {
                var query = from r in Workspaces where r.DisplayName == "List of cards" select r;
                return !query.Any();
            }

        public void ShowCardRemoverView()
        {
            //AllPlayingCardsViewModel allcardview = new AllPlayingCardsViewModel();
            //App.playingcardrepository.DisplayName = "List of cards";
            //_workspaces.Add(App.playingcardrepository);
            //CurrentWorkspace = App.playingcardrepository;
        }

        public bool CanShowSettingsSetup()
        {
            var query = from s in Workspaces where s.DisplayName == "Settings setup" select s;
            return !query.Any();
        }
      
      public void ShowSettingsSetup()
        {
            AppSettingViewModel appsettingsvm = new AppSettingViewModel();
            appsettingsvm.DisplayName = "Settings setup";
            _workspaces.Add(appsettingsvm);
            CurrentWorkspace = appsettingsvm;
        }


    public   void PlayHighLowBingo()
      {
          HighLowBingo nighlowbingo = new HighLowBingo(App.playingcardrepository) {  DisplayName = "High-Low Bingo"};
          _workspaces.Add(nighlowbingo);
          CurrentWorkspace = nighlowbingo;
      }

      /// <summary>
      /// Executes on collection changed.
      /// </summary>
      /// <param name="sender"></param>
      /// <param name="e"></param>
        void _workspaces_CollectionChanged(object sender, System.Collections.Specialized.NotifyCollectionChangedEventArgs e)
        {
            if (e.NewItems != null)
            {
                if (e.NewItems.Count > 0)
                {
                    foreach (MainViewModel vm in e.NewItems)
                    {
                        vm.RequestClose += new EventHandler(vm_RequestClose);
                    }
                }
            }

            if (e.OldItems != null)
            {
                if(e.OldItems.Count > 0)
                    {
                        foreach(MainViewModel vm in e.OldItems)
                        {
                            vm.RequestClose -= vm_RequestClose;
                        }
                    }
            }
        }

        void vm_RequestClose(object sender, EventArgs e)
        {
            _workspaces.Remove(sender as MainViewModel);
        }

      /// <summary>
      /// Executes the propertychanged events
      /// </summary>
      /// <param name="propertyName"></param>
        private void OnPropertyChanged(string propertyName)
        {
            if (PropertyChanged != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;
    }
}
