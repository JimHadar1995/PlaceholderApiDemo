using System;
using System.Collections.Generic;
using System.Text;

namespace FrameWork.Exceptions {
    public class NotContainKeyInDictionaryException : Exception {
        public NotContainKeyInDictionaryException(string key) 
            :base($"В словаре не найдено значения, соответствуюшего ключу \"{key}\""){

        }
    }
}
