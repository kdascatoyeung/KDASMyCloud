using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace KDTHK_DM_SP.uninstaller
{
    public interface IUninstallStep : IDisposable
    {
        void Prepare(List<string> componentsToRemove);

        void PrintDebugInformation();

        void Execute();
    }
}
