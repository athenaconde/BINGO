using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BingoManager.SystemManager.Model
{
  public  class PairModel: MainModel
    {

      int _number;
      bool _Isball;

        #region Constructors
      public PairModel() { }

      public PairModel(int number, bool isBall)
          : this()
      {
          _number = number;
          _Isball = isBall;
      }
        #endregion //Constructors

        #region Properties
      public int Number
      {
          get
          { return _number; }

          set 
          {
              if (value == _number) { return; }
              _number = value;
              OnPropertyChanged("Number");
          }
      }

      public bool Isball
      {
          get { return _Isball; }
          set
          {
              if (value.Equals(_Isball)) { return; }
              _Isball = value;
              OnPropertyChanged("Isball");

          }
      
      }
        #endregion //Properties
    }
}
