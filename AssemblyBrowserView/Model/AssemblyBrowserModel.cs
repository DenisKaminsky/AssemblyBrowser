using System.ComponentModel;
using System.Runtime.CompilerServices;
using AssemblyBrowser;

namespace AssemblyBrowserView.Model
{
    public class AssemblyBrowserModel: INotifyPropertyChanged
    {
        private AssemblyResult _result;
        private AssemblyBrowser.AssemblyBrowser _browser;

        public AssemblyResult Result
        {
            get
            {
                return _result;
            }
            set
            {
                _result = value;
                OnPropertyChanged();
            }
        }

        public AssemblyBrowserModel()
        {
            _browser = new AssemblyBrowser.AssemblyBrowser();
        }

        public void GetResult(string filename)
        {
            Result = _browser.Browse(filename);
        }

        public event PropertyChangedEventHandler PropertyChanged;

        public void OnPropertyChanged([CallerMemberName]string prop = "")
        {
            if (PropertyChanged != null)
                PropertyChanged(this, new PropertyChangedEventArgs(prop));
        }
    }
}
