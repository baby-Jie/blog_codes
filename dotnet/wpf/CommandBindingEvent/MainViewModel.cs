using System.Windows;

namespace CommandBindingEvent
{
    internal class MainViewModel: ViewModelBase
    {
        #region CommandProperty HelloCmd

        private RelayArgCommand _helloCmd;

        public RelayArgCommand HelloCmd
        {
            get
            {
                return _helloCmd ?? (_helloCmd = new RelayArgCommand((e) =>
                {
                    MessageBox.Show("hello wpf!");
                }));
            }
        }

        #endregion
    }
}
