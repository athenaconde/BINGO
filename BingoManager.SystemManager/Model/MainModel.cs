using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.ComponentModel;
using BingoManager.SystemManager.ViewModel;
namespace BingoManager.SystemManager.Model
{
  public abstract  class MainModel:MainViewModel, INotifyPropertyChanged
    {

      protected void OnPropertyChanged(string propertyName)
      {
          if (PropertyChanged != null)
          {
               PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
          }
      }

      public event PropertyChangedEventHandler PropertyChanged;
    }
}
