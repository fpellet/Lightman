using System;
using System.Windows.Input;

namespace LightManWP.ViewModels
{
    public abstract class CommandBase : ICommand
    {
        public event EventHandler CanExecuteChanged;

        public virtual bool CanExecute(object parameter)
        {
            return true;
        }

        public abstract void Execute(object parameter);
    }

    public abstract class CommandBase<T> : CommandBase
    {
        private static T ConvertParameter(object parameter)
        {
            return parameter is T ? (T)parameter : default(T);
        }

        protected virtual bool CanExecute(T parameter)
        {
            return true;
        }

        protected abstract void Execute(T lightman);
        
        public override sealed void Execute(object parameter)
        {
            Execute(ConvertParameter(parameter));
        }

        public override sealed bool CanExecute(object parameter)
        {
            return CanExecute(ConvertParameter(parameter));
        }
    }
}
