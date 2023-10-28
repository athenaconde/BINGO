using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Collections.ObjectModel;

namespace BingoManager.SystemManager.AppControl
{
 internal sealed   class Subcription
    {

     public string Key
     { get; set; }

     public string ID
     { get; set; }


     public long duration
     { get; set; }


     public ObservableCollection<Subcription> Subscriptions
     { 
         get{
             ObservableCollection<Subcription> _subscriptions = new ObservableCollection<Subcription>();
            // Removed the Keys collection
             return _subscriptions;
         }
     }

    }
}
