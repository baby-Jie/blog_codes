using System;

namespace CommandBindingEvent
{
    using System.ComponentModel;
    using System.Runtime.CompilerServices;
    using System.Windows.Input;
    public class ViewModelBase : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;
        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null) => PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        public void Set<T>(ref T val1, T val2, [CallerMemberName] string propertyName = null)
        {
            val1 = val2;
            OnPropertyChanged(propertyName);
        }
        public void SetProperty<T>(ref T val1, T val2, [CallerMemberName] string propertyName = null)
        {
            val1 = val2;
            OnPropertyChanged(propertyName);
        }
    }

    public class RelayCommand : ICommand
    {
        private readonly Action _executeAction;
        private readonly Predicate<object> _canExecuteFunc;
        public RelayCommand(Action execution) : this(execution, null) { }
        public RelayCommand(Action execution, Predicate<object> canExecuteFunc)
        {
            this._canExecuteFunc = canExecuteFunc;
            this._executeAction = execution;
        }
        public bool CanExecute(object parameter) => _canExecuteFunc?.Invoke(parameter) ?? true;
        public void Execute(object paramter) => this._executeAction?.Invoke();
        public event EventHandler CanExecuteChanged
        {
            add => CommandManager.RequerySuggested += value;
            remove => CommandManager.RequerySuggested -= value;
        }
    }

    public class RelayArgCommand : ICommand
    {
        private readonly Action<object> _executeAction;
        private readonly Predicate<object> _canExecuteFunc;
        public RelayArgCommand(Action<object> execution) : this(execution, null) { }
        public RelayArgCommand(Action<object> execution, Predicate<object> canExecuteFunc)
        {
            this._canExecuteFunc = canExecuteFunc;
            this._executeAction = execution;
        }
        public bool CanExecute(object parameter) => _canExecuteFunc?.Invoke(parameter) ?? true;
        public void Execute(object paramter) => this._executeAction?.Invoke(paramter);
        public event EventHandler CanExecuteChanged
        {
            add => CommandManager.RequerySuggested += value;
            remove => CommandManager.RequerySuggested -= value;
        }
    }
}
