using System;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Windows.Forms;

namespace AssemblyBrowserView.ViewModel
{
    public class AssemblyBrowserViewModel : INotifyPropertyChanged
    {
        private string _filename;
        private DelegateCommand _openFileCommand;
        private Model.AssemblyBrowserModel _browserModel;

        public string Filename
        {
            get
            {
                return _filename;
            }
            set
            {
                _filename = value;
                OnPropertyChanged();
            }
        }

        public DelegateCommand OpenFileCommand
        {
            get
            {
                return _openFileCommand ?? (_openFileCommand = new DelegateCommand(OpenFileMethod));
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;

        public void OnPropertyChanged([CallerMemberName]string prop = "")
        {
            if (PropertyChanged != null)
                PropertyChanged(this, new PropertyChangedEventArgs(prop));
        }

        public void OpenFileMethod(object obj)
        {
            try
            {
                OpenFileDialog openFileDialog = new OpenFileDialog();
                if (openFileDialog.ShowDialog() == DialogResult.OK)
                {
                    Filename = openFileDialog.FileName;
                    //if (_browserModel == null)
                       // _browserModel = new Model.AssemblyBrowserModel();
                    //_browserModel.GetResult(Filename);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }

    }
}
