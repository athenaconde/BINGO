using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Collections.ObjectModel;
using BingoManager.SystemManager.Model;
using BingoManager.SystemManager.Engine;
using System.Threading;
using BingoManager.SystemManager.ViewModel;
namespace BingoManager.SystemManager.Repository
{
 public class PlayingCardRepository:MainViewModel
    {
     public PlayingCardRepository() { }

       ObservableCollection<PlayingCard> _cards;
     PlayingCard _bingoNumbers;
     Random random = new Random();
     Random randomControlNumber = new Random();

     public  ObservableCollection<PlayingCard> Cards
     {
         get
         {
             if (_cards == null)
             {
                 _cards = DataAccessManager.GetPlayingCards();
                 //if DataAccessManager.GetPlayingCards returns null record then we should generate the Cards.
                 if (_cards == null)
                 {
                     _cards = new ObservableCollection<PlayingCard>();
                     int i;
                     for (i = 1; i <= 150000; i++)
                     {
                         _cards.Add(this.GeneratePlayingCard(i));
                     }
                     Thread thread = new Thread(this.PersistGeneratedCardstoDB);
                     thread.Priority = ThreadPriority.Highest;
                     thread.Start();
                     

                 }
             }
             return _cards;
         }

     }

    

     public PlayingCard BingoNumbers
     {
         get
         {
             if (_bingoNumbers == null)
             {
                 _bingoNumbers = new PlayingCard();
                                 
             }
             return _bingoNumbers;
         }

         
     }

     public bool Contains(PlayingCard card)
     {
         return _cards.Contains(card);
     }


     /// <summary>
     /// Executes adding of card.
     /// </summary>
     /// <param name="card"></param>
     public void AddNewCard(PlayingCard card)
     {
         if (card == null)
         { return; }
         _cards.Add(card);
     }

     private PlayingCard GeneratePlayingCard(int serialNum)
     {  
        // int i;
         PlayingCard _card = new PlayingCard();
         _card.SerialNumber = serialNum;
         _card.ControlCardNumber = randomControlNumber.Next(100000, 999999);
         _card.HighBingo = new PairModel(random.Next(0, 10), false);
         _card.LowBingo = new PairModel(random.Next(0, 10), false);
         //for (i = 1; i <= 5;i++)
         //{  
             _card.B = new PairModel[] { new PairModel(random.Next(0, 20), false), new PairModel(random.Next(0, 20), false), new PairModel(random.Next(0, 20), false), new PairModel(random.Next(0, 20), false), new PairModel(random.Next(0, 20), false) };
                 CheckAnyDoubledNumber(_card.B,"B");
             _card.I = new PairModel[] { new PairModel(random.Next(20, 40), false), new PairModel(random.Next(20, 40), false), new PairModel(random.Next(20, 40), false), new PairModel(random.Next(20, 40), false), new PairModel(random.Next(20, 40), false) };
                CheckAnyDoubledNumber(_card.I, "I");
                _card.N = new PairModel[] { new PairModel(random.Next(40, 60), false), new PairModel(random.Next(40, 60), false), new PairModel(0, true), new PairModel(random.Next(40, 59), false), new PairModel(random.Next(40, 60), false)};
                CheckAnyDoubledNumber(_card.N, "N");
                CheckHighLowBingoNumbersIfExistsInB(_card.HighBingo, _card.LowBingo, _card.B);
             _card.G = new PairModel[]{new PairModel(random.Next(60, 80), false), new PairModel(random.Next(60, 80), false), new PairModel(random.Next(60, 80), false), new PairModel(random.Next(60, 80), false), new PairModel(random.Next(60, 80), false)};
                CheckAnyDoubledNumber(_card.G, "G");
             _card.O = new PairModel[]{new PairModel(random.Next(80, 100),false),new PairModel(random.Next(80, 100),false),new PairModel(random.Next(80, 100),false),new PairModel(random.Next(80, 100),false),new PairModel(random.Next(80, 100),false)};
                CheckAnyDoubledNumber(_card.O, "O");
        // }
            
         return _card;
     }
            
         private PairModel[] GetPairModelArray(int min,int max)
             {
                 PairModel[] pairModeArray = new PairModel[] { new PairModel(random.Next(min, max), false), new PairModel(random.Next(min, max), false), new PairModel(random.Next(min, max), false), new PairModel(random.Next(min, max), false), new PairModel(random.Next(min, max), false), };
                 return pairModeArray;
             }

     private int GenerateNumber(int min, int max)
     {
         return GenerateNumber( min,  max,null);          

     }

   
     
     private int GenerateNumber(int min, int max, PairModel[] pairModel)
     {
         if (pairModel==null)
         return random.Next(min, max);

         int newNumber = random.Next(min, max);
         int i;
         for (i = 0; i <= 4; i++)
         {
             if (pairModel[i].Number == newNumber)
             {
                 GenerateNumber(min, max, pairModel);
             }
         }
            
         return newNumber;
     }

     private void GenerateAnotherNumber(PairModel[] pairmodel, int min, int max)
     {
         if (min == 40)//G
         { pairmodel[0].Number = random.Next(min, max); pairmodel[1].Number = random.Next(min, max); pairmodel[2].Number = 0; pairmodel[3].Number = random.Next(min, max); pairmodel[4].Number = random.Next(min, max); }
         else
         { pairmodel[0].Number = random.Next(min, max); pairmodel[1].Number = random.Next(min, max); pairmodel[2].Number = random.Next(min, max); pairmodel[3].Number = random.Next(min, max); pairmodel[4].Number = random.Next(min, max); }
          
         if ((pairmodel[0].Number == pairmodel[1].Number || pairmodel[0].Number == pairmodel[2].Number || pairmodel[0].Number == pairmodel[3].Number || pairmodel[0].Number == pairmodel[4].Number) || (pairmodel[1].Number == pairmodel[2].Number || pairmodel[1].Number == pairmodel[3].Number || pairmodel[1].Number == pairmodel[4].Number) || (pairmodel[2].Number == pairmodel[3].Number || pairmodel[2].Number == pairmodel[4].Number) || (pairmodel[3].Number == pairmodel[4].Number))
                {
                    { GenerateAnotherNumber(pairmodel, min, max); }
                }
     }
  
     void CheckAnyDoubledNumber(PairModel[] pairmodel, string ball)

         {
              if ((pairmodel[0].Number == pairmodel[1].Number || pairmodel[0].Number == pairmodel[2].Number || pairmodel[0].Number == pairmodel[3].Number || pairmodel[0].Number == pairmodel[4].Number) || (pairmodel[1].Number == pairmodel[2].Number || pairmodel[1].Number == pairmodel[3].Number || pairmodel[1].Number == pairmodel[4].Number) || (pairmodel[2].Number == pairmodel[3].Number || pairmodel[2].Number == pairmodel[4].Number) || (pairmodel[3].Number == pairmodel[4].Number))
                {
                    
                    if(ball.Equals("B"))
                    {GenerateAnotherNumber(pairmodel,0,20);}
                    //{ pairmodel[0].Number = 5; pairmodel[1].Number = 11;pairmodel[2].Number = 15;pairmodel[3].Number = 4;pairmodel[4].Number = 9;}
//= new PairModel[] { new PairModel(05, false), new PairModel(11, false), new PairModel(15, false), new PairModel(4, false), new PairModel(9, false)}; }
                    else if (ball.Equals("I"))
                    {GenerateAnotherNumber(pairmodel,20,40);}
                    //{ pairmodel[0].Number = 21; pairmodel[1].Number = 39; pairmodel[2].Number = 29; pairmodel[3].Number = 31; pairmodel[4].Number = 24; }
                    //= new PairModel[] { new PairModel(21, false), new PairModel(39, false), new PairModel(25, false), new PairModel(30, false), new PairModel(33, false) }; }
                    else if (ball.Equals("N"))
                    {GenerateAnotherNumber(pairmodel,40,60);
                      
                    }
                   // { pairmodel[0].Number = 55; pairmodel[1].Number = 58; pairmodel[3].Number = 47; pairmodel[4].Number = 45; }
                        //new PairModel[] { new PairModel(55, false), new PairModel(58, false), new PairModel(51, false), new PairModel(47, false), new PairModel(45, false) }; }
                    else if (ball.Equals("G"))
                    {GenerateAnotherNumber(pairmodel,60,80);}
                   // { pairmodel[0].Number = 73; pairmodel[1].Number = 70; pairmodel[2].Number = 77; pairmodel[3].Number = 69; pairmodel[4].Number = 71; }
                        //= new PairModel[] { new PairModel(73, false), new PairModel(70, false), new PairModel(77, false), new PairModel(69, false), new PairModel(71, false) }; }
                    else if (ball.Equals("O"))
                    { GenerateAnotherNumber(pairmodel, 80, 100); }
                   // { pairmodel[0].Number = 85; pairmodel[1].Number = 81; pairmodel[2].Number = 88; pairmodel[3].Number = 94; pairmodel[4].Number = 90; }
                        //= new PairModel[] { new PairModel(85, false), new PairModel(81, false), new PairModel(88, false), new PairModel(94, false), new PairModel(90, false) }; }
                   // pairmodel.Reverse();
                }
         //     int i;
         //  for (i = 1; i <= pairmodel.Count() - 1; i++)
         //   {
         //       if (pairmodel[0].Number == (pairmodel[i].Number))
         //       {
         //           System.Windows.MessageBox.Show(string.Format("This numbers duplicate = {0} and {1}", pairmodel[0].Number, pairmodel[i].Number));
         //       }
         //   }
         //for (i=2;i<=pairmodel.Count()-1;i++)
         //   {
         //           if (pairmodel[1].Number==(pairmodel[i].Number)){ System.Windows.MessageBox.Show(string.Format("This numbers duplicate = {0} and {1}",pairmodel[1].Number, pairmodel[i].Number));}
         //   }
         //for (i = 3; i <= pairmodel.Count() - 1; i++)
         //{
         //    if (pairmodel[2].Number == (pairmodel[i].Number)) { System.Windows.MessageBox.Show(string.Format("This numbers duplicate = {0} and {1}", pairmodel[2].Number, pairmodel[i].Number)); }
         //}
         // for (i=4;i<=pairmodel.Count()-1;i++)
         //   {
         //           if (pairmodel[3].Number==(pairmodel[i].Number)){ System.Windows.MessageBox.Show(string.Format("This numbers duplicate = {0} and {1}",pairmodel[3].Number, pairmodel[i].Number));}
         //   }
         }

     void CheckHighLowBingoNumbersIfExistsInB(PairModel highbingo, PairModel lowbingo, PairModel[] B)
        {
           
            var query = from b in B where b.Number == highbingo.Number select b;
            if (query.Any())
            {
                highbingo.Number = random.Next(0, 10);
                CheckHighLowBingoNumbersIfExistsInB(highbingo, lowbingo, B);
            }
            var query2 = from b in B where b.Number == lowbingo.Number select b;
            if (query2.Any())
            {

                lowbingo.Number = random.Next(0, 10);
                CheckHighLowBingoNumbersIfExistsInB(highbingo, lowbingo, B);
            }
            if (highbingo.Number == lowbingo.Number)
            {
                highbingo.Number = random.Next(0, 10);
            }
        }

     private bool IsSequenceExistsInCards(PairModel[] pairmodel, string ball)
     {
       this.CheckAnyDoubledNumber(pairmodel,ball);

         if (ball.Equals("B"))
         {
             var query = from card in _cards select card.B;
             if (query.Contains(pairmodel))
             {
                 return true;
             }
         }
         else if (ball.Equals("I"))
         {
             var query = from card in _cards select card.I;
             if (query.Contains(pairmodel))
             {
                 return true;
             }
         }
         else if (ball.Equals("N"))
         {
             var query = from card in _cards select card.N;
             if (query.Contains(pairmodel))
             {
                 return true;
             }
         }
         else if (ball.Equals("G"))
         {
             var query = from card in _cards select card.G;
             if (query.Contains(pairmodel))
             {
                 return true;
             }
         }
         else if (ball.Equals("O"))
         {
             var query = from card in _cards select card.O;
             if (query.Contains(pairmodel))
             {
                 return true;
             }
         }
         return false;
     }


     /// <summary>
     /// Saves the generated cards to the Db permanently.
     /// </summary>
     /// <param name="sender"></param>
     void PersistGeneratedCardstoDB(object sender)
     {
         DataAccessManager.SavePlayingCards(_cards);
     }

     /// <summary>
     /// Remove the card specified from the list.
     /// </summary>
     /// <param name="card"></param>
     public void RemoveCard(PlayingCard card)
     {
         if (card != null)
         {
             _cards.Remove(card);
         }
     }

    }
}
