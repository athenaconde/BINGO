using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.ComponentModel;
using System.Collections.ObjectModel;

namespace BingoManager.SystemManager.Model
{
    public class PlayingCard : MainModel  //: ObservableCollection<PlayingModel>
    {

      public PlayingCard()
      {  }

    //  long _SerialNumber;

      public long SerialNumber
      {
          get;
          set;
      }

        /// <summary>
        /// Gets/ Sets the unique card control number (6 digits).
        /// </summary>
      public long ControlCardNumber
      { get; set; }

        /// <summary>
        /// Gets/Sets the number of the High Bingo play card.
        /// </summary>
      public PairModel HighBingo
      { get; set; }

        /// <summary>
        /// Gets/Sets the number of the Low bingo play card.
        /// </summary>
      public PairModel LowBingo
      { get; set; }

        /// <summary>
        /// Constructors.
        /// </summary>
        /// <param name="b"></param>
        /// <param name="i"></param>
        /// <param name="n"></param>
        /// <param name="g"></param>
        /// <param name="o"></param>
      public PlayingCard(PairModel[] b, PairModel[] i, PairModel[] n, PairModel[] g, PairModel[] o)
          : this()
      {
          _b = b;
          _i = i;
          _n = n;
          _g = g;
          _o = o;
      }

      #region Fields
      PairModel[] _b;
      PairModel[] _i;
      PairModel[] _n;
      PairModel[] _g;
      PairModel[] _o;
      #endregion //Fields

      #region Properties

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
