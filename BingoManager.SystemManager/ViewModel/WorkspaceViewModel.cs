using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Collections.ObjectModel;
using System.Windows.Input;

using BingoManager.SystemManager.Commands;

namespace BingoManager.SystemManager.ViewModel
{
  public class WorkspaceViewModel
    {

      ObservableCollection<MainViewModel> _workspaces;
      ICommand _showBingoGameControlCommand;
      ICommand _CreateGameCommand;
      ICommand _RemoveCardCommand;
      public ObservableCollection<MainViewModel> Workspaces
      {
          get 
          {
              if (_workspaces == null)
              {
                  _workspaces = new ObservableCollection<MainViewModel>();
              }
              return _workspaces;
          }
      }

      public MainViewModel CurrentWorkspace
      { get; set; }




     



    }
}
