using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Wrapper
{
    public interface IRepositoryWrapper
    {
        IRepositoryWrapper Repository { get; }

        object User { get; set; }

        void Save();
    }
}
