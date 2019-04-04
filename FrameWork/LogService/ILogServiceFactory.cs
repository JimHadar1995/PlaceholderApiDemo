using System;
using System.Collections.Generic;
using System.Text;

namespace FrameWork.LogService {
    public interface ILogServiceFactory {
        ILogService Create();
    }
}
