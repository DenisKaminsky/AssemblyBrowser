using System;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Windows.Forms;
using System.IO;

namespace AssemblyBrowserView.ViewModel
{
    public class AssemblyBrowserViewModel : INotifyPropertyChanged
    {
        private string _filename;
        private AssemblyBrowser.AssemblyResult _result;
        private DelegateCommand _openFileCommand;
        private Model.AssemblyBrowserModel _browserModel;

        public string Filename
        {
            get
            {
                return Path.GetFileName(_filename);                
            }
            set
            {
                _filename = value;
                OnPropertyChanged();
            }
        }

        public AssemblyBrowser.AssemblyResult Result
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
                openFileDialog.Filter = "Library Files (*.dll)|*.dll";

                if (openFileDialog.ShowDialog() == DialogResult.OK)
                {
                    Filename = openFileDialog.FileName;
                    if (_browserModel == null)
                        _browserModel = new Model.AssemblyBrowserModel();
                    //Result = _browserModel.GetResult(Filename);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }

    }
}
