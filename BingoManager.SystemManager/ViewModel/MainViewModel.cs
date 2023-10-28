using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Input;
using BingoManager.SystemManager.Commands;

namespace BingoManager.SystemManager.ViewModel
{
 public abstract class MainViewModel
    {

     public MainViewModel() { }

     ICommand _closeCommand;

     public string DisplayName
     { get; set; }

     public string ImageDisplayURI
     { get; set; }

     public ICommand CloseCommand
     {
         get
         {
             if (_closeCommand == null)
             { _closeCommand = new RelayCommand(cmd=>this.OnRequestClosed(),cmd=>true); }
             return _closeCommand;
         }
         
     }

     private void OnRequestClosed()
     {
         if (RequestClose != null)
         {
             RequestClose(this, new EventArgs());
         }
     }

     public event EventHandler RequestClose;

    }
}
