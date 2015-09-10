using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Common.Contracts
{
    public interface IDirtyCapable
    {
        bool IsDirty { get; }

        bool IsAnythingDirty();

        List<IDirtyCapable> GetDirtyObjects();

        void CleanAll();
    }

}
