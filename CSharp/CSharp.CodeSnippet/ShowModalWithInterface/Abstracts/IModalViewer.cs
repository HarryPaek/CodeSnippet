using System;

namespace ShowModalWithInterface.Abstracts
{
    public interface IModalViewer: IDisposable
    {
        void View(string key, string description);

        // DialogResult ShowDialog();

        // DialogResult ShowDialog(IWin32Window owner);
    }
}
