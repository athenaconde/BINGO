using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Windows;
using BingoManager.Views;
using BingoManager.SystemManager.ViewModel;
using BingoManager.SystemManager.Model;
using BingoManager.SystemManager.Repository;

namespace BingoManager
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {

        static PlayingCardViewModel _PlayingCardVM;
        static PlayingCardRepository _playingcardrepository;
        public ResourceDictionary GetResource()
        {
            return (ResourceDictionary)Application.LoadComponent(new Uri("/BingoManager;component/Dictionaries/ResourceDictionary.xaml", UriKind.Relative));
        }

        public static PlayingCardRepository playingcardrepository
        {
            get
            {
                if (_playingcardrepository == null)
                {
                    _playingcardrepository = new PlayingCardRepository();
                    //_playingcardrepository.Cards;
                }
                return _playingcardrepository;
            }
        }
        public static PlayingCardViewModel PlaycardViewModel
        {
            get 
            {
                if (_PlayingCardVM == null)
                {
                    _PlayingCardVM = new PlayingCardViewModel(new PlayingCard(), playingcardrepository, new GameCardsRepository());
                }

                return _PlayingCardVM;
            }
        }


        protected override void OnStartup(StartupEventArgs e)
        {
            base.OnStartup(e);
            if (!App.PlaycardViewModel.IsLicensed())
            {
                SubcriptionSetupView subscriptionView = new SubcriptionSetupView();
                subscriptionView.Show();
                return;
            }
            CardsLoaderView view = new CardsLoaderView();
            view.Show();
        }
    }
}
