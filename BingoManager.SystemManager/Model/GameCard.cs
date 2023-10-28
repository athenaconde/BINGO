using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Collections.ObjectModel;

namespace BingoManager.SystemManager.Model
{
  public  class GameCard:MainModel
    {

      public GameCard() { }
      #region Fields
      PairModel[] _b;
      PairModel[] _i;
      PairModel[] _n;
      PairModel[] _g;
      PairModel[] _o;

    //  string _gameName;
      double _prize;
      #endregion //Fields

      #region Properties

      public string GameName
      { get; set; }

      public double Prize
      { get { return _prize; } set { _prize = value; OnPropertyChanged("B"); } }

      public PairModel[] B
      {
          get { return _b; }

          set
          {
              if (value == _b)
              { return; }
              _b = value;
              OnPropertyChanged("B");
          }

      }

      public PairModel[] I
      {
          get { return _i; }
          set
          {
              if (value == _i)
              { return; }
              _i = value;
              OnPropertyChanged("I");
          }
      }

      public PairModel[] N
      {
          get { return _n; }
          set
          {
              if (value == _n)
              { return; }
              _n = value;
              OnPropertyChanged("N");
          }
      }

      public PairModel[] G
      {
          get { return _g; }
          set
          {
              if (value == _g)
              { return; }
              _g = value;
              OnPropertyChanged("G");
          }
      }

      public PairModel[] O
      {
          get { return _o; }
          set
          {
              if (value == _o)
              { return; }
              _o = value;
              OnPropertyChanged("O");
          }
      }

      #endregion //Properties

    }
}
