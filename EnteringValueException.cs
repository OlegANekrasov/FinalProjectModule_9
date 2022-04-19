using System;

namespace FinalProjectModule_9
{
    class EnteringValueException : ApplicationException
    {
        public EnteringValueException() { }

        public EnteringValueException(string message, DateTime time, string value) 
                                    : this(message, time, value, null) { }
        
        public EnteringValueException(string message, DateTime time, string value, System.Exception inner) 
                                    : base(message, inner) 
        {
            Data.Add("Дата и время исключения: ", time);
            Data.Add("Значение введенное пользователем: ", value);
        }
    }
}
