using AssemblyBrowser;

namespace AssemblyBrowserView.Model
{
    public class AssemblyBrowserModel
    {
        private AssemblyBrowser.AssemblyBrowser _browser;

        public AssemblyBrowserModel()
        {
            _browser = new AssemblyBrowser.AssemblyBrowser();
        }

        public AssemblyResult GetResult(string filename)
        {
            return _browser.Browse(filename);
        }
    }
}
