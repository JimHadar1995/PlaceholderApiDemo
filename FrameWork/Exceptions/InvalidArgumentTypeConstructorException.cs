using System;
using System.Collections.Generic;
using System.Text;

namespace FrameWork.Exceptions {
    public class InvalidArgumentTypeConstructorException : Exception {
        public InvalidArgumentTypeConstructorException(string argumentName) 
            :base($"Параметр {argumentName} имеет недопустимый тип"){

        }
    }
}
