using System;
using System.Windows.Input;
using System.Diagnostics;

namespace BingoManager.SystemManager.Commands
{
  public  class RelayCommand:ICommand
    {
      static Action<object> _execute;
      static Predicate<object> _canExecute;


      #region Constructors
      public RelayCommand(Action<object> execute)
       :this(execute, null)
      {
      }

        public RelayCommand(Action<object> execute, Predicate<object> canExecute)
      {
          if (execute == null)
          { throw new ArgumentNullException("execute"); }
          _execute = execute;
          _canExecute = canExecute;
      }

      #endregion //constructors
     
      //[DebuggerStepThrough] 
      public bool CanExecute(object parameter)
        {
            return _canExecute==null?true:_canExecute(parameter);
        }

      public event EventHandler CanExecuteChanged 
      {
          add { CommandManager.RequerySuggested += value; }
          remove { CommandManager.RequerySuggested -= value; }
      }

        public void Execute(object parameter)
        {
            _execute(parameter);
        }
    }
}
