using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Collections.ObjectModel;
using BingoManager.SystemManager.Model;
using BingoManager.SystemManager.Repository;
using System.Threading;

namespace BingoManager.SystemManager.ViewModel
{
  public  class AllPlayingCardsViewModel:MainViewModel
    {

      public AllPlayingCardsViewModel(PlayingCardRepository cardVM) 
      {
          if (cardVM == null)
          {
              throw new ArgumentNullException("cardVM");
          }
          _cardVM = cardVM;
      }


      #region Fields
      PlayingCardRepository _cardVM;
      List<PairModel> _col1Numbers;
      List<PairModel> _col2;
      List<PairModel> _col3;
      List<PairModel> _col4;
      List<PairModel> _col5;
      //List<PairModel> _col6;
      //List<PairModel> _col7;
      //List<PairModel> _col8;
      //List<PairModel> _col9;
      //List<long> _col10;
      #endregion //Fields

      public List<PairModel> Col1Cards
      {
          get
          {
              if (_col1Numbers == null)
              {
                  _col1Numbers = new List<PairModel>();
                 int i;
                 for (i = 1; i <= 30000; i++)
                 {
                     _col1Numbers.Add(new PairModel(i, false));
                 }
                     
              }
              return _col1Numbers ;
          }
      }

      public List<PairModel> Col2Cards
      {
          get
          {
              if (_col2 == null)
              {
                  _col2 = new List<PairModel>();
                  int i;
                  for (i = 30001; i <= 60000; i++)
                  {
                      _col2.Add(new PairModel(i, false));
                  }
              }

         
              return _col2;
          }
      }

      public List<PairModel> Col3Cards
      {
          get
          {
              if (_col3 == null)
              {
                 _col3  = new List<PairModel>();
                 //int i;
                 //for (i = 60001; i <= 90000; i++)
                 //{
                 //    _col3.Add(new PairModel(i, false));
                 //}
              }
              return _col3;
          }
      }

      public List<PairModel> Col4Cards
      {
          get
          {
              if (_col4 == null)
              {
                  _col4 = new List<PairModel>();
                  //int i;
                  //for (i = 90001; i <= 120000; i++)
                  //{
                  //    _col4.Add(new PairModel(i, false));
                  //}

              } return _col4;
          }
      }

      public List<PairModel> Col5Cards
      {
          get
          {
              if (_col5 == null)
              {
                  _col5 = new List<PairModel>();
                  //int i;
                  //for (i = 120001; i <= 150000; i++)
                  //{
                  //    _col3.Add(new PairModel(i, false));
                  //}
              }
              return _col5;
          }
      }

      //public List<long> Col6Cards
      //{
      //    get
      //    {
      //        if (_col6 == null)
      //        {
      //            _col6 = new List<long>();
      //            var query = from cards in PlayingCardRepository.Cards.AsParallel().AsOrdered() where cards.SerialNumber >= 75001 && cards.SerialNumber <= 90000 orderby cards.SerialNumber select cards;
      //            foreach (var cardnumber in query)
      //            { _col6.Add(cardnumber.SerialNumber); }

      //        }
      //        return _col6;
      //    }
      //}

      //public List<long> Col7Cards
      //{
      //    get
      //    {
      //        if (_col7 == null)
      //        {
      //            _col7 = new List<long>();
      //            var query = from cards in PlayingCardRepository.Cards.AsParallel().AsOrdered() where cards.SerialNumber >= 90001 && cards.SerialNumber <= 105000 orderby cards.SerialNumber select cards;
      //            foreach (var cardnumber in query)
      //            { _col7.Add(cardnumber.SerialNumber); }
      //        }
      //        return _col7;
      //    }
      //}

      //public List<long> Col8Cards
      //{
      //    get
      //    {
      //        if (_col8 == null)
      //        {
      //            _col8 = new List<long>();
      //            var query = from cards in PlayingCardRepository.Cards.AsParallel().AsOrdered() where cards.SerialNumber >= 105001 && cards.SerialNumber <= 120000 orderby cards.SerialNumber select cards;
      //            foreach (var cardnumber in query)
      //            { _col8.Add(cardnumber.SerialNumber); }
      //        }
      //        return _col8;
      //    }
      //}

      //public List<long> Col9Cards
      //{
      //    get
      //    {
      //        if (_col9 == null)
      //        {
      //            _col9 = new List<long>();
      //            var query = from cards in PlayingCardRepository.Cards.AsParallel().AsOrdered() where cards.SerialNumber >= 120001 && cards.SerialNumber <= 135000 orderby cards.SerialNumber select cards;
      //            foreach (var cardnumber in query)
      //            { _col9.Add(cardnumber.SerialNumber); }
      //        }
      //        return _col9;
      //    }
      //}


      //public List<long> Col10Cards
      //{
      //    get
      //    {
      //        if (_col10 == null)
      //        {
      //        []    _col10 = new List<long>();
      //            var query = from cards in PlayingCardRepository.Cards.AsParallel().AsOrdered() where cards.SerialNumber >= 135001 && cards.SerialNumber <= 150000 orderby cards.SerialNumber select cards;
      //            foreach (var cardnumber in query)
      //            { _col10.Add(cardnumber.SerialNumber); }
      //        }
      //        return _col10;
      //    }
        //}

        #region Methods
     
       public bool CanRemoveCard(object param)
       {
           if (param == null) {  return false;}

           if (_cardVM.Cards != null)
           {
               if (_cardVM.Cards.Count > 0)
               {

                   var cardquery = from pc in _cardVM.Cards where pc.SerialNumber == 32 select pc;
                   return !cardquery.Any();
               }
           }
           return false;
       }
      public void RemoveCard(object param)
        {
            int number = System.Convert.ToInt32(param);
            Thread thread = new Thread(BallMatcherThread);
            thread.Start(number);
            var cardQuery = from pc in _cardVM.Cards where pc.SerialNumber == number select pc;
            if (cardQuery.Any())
            {
                _cardVM.Cards.Remove(cardQuery.First());
            }

            
        }

      void BallMatcherThread(object state)
      {
          int number = System.Convert.ToInt32(state);
          if (number > 1 && number <= 30000)
          {
              var query = from num in Col1Cards where num.Number == number select num;
              if (query.Any())
              {
                  query.First().Isball = true;
              }
          }
          else if (number > 300001 && number <= 60000)
          {
              var query = from num in Col2Cards where num.Number == number select num;
              if (query.Any())
              {
                  query.First().Isball = true;
              }
          }
          else if (number > 60001 && number <= 90000)
          {
              var query = from num in Col3Cards where num.Number == number select num;
              if (query.Any())
              {
                  query.First().Isball = true;
              }
          }
          else if (number > 90001 && number <= 120000)
          {
              var query = from num in Col4Cards where num.Number == number select num;
              if (query.Any())
              {
                  query.First().Isball = true;
              }
          }
          else if (number > 120001 && number <= 150000)
          {
              var query = from num in Col5Cards where num.Number == number select num;
              if (query.Any())
              {
                  query.First().Isball = true;
              }
          }

      }
        #endregion //Methods

    }
}
