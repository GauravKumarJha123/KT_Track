using System;
using System.Runtime.Serialization;

namespace KT_10_02_23
{
    [Serializable]
    internal class OddNumberException : Exception
    {
        public override string Message
        {
            get
            {
                return "Divisor Cannot be Odd Number";
            }
        }
        public override string HelpLink
        {
            get
            {
                return "Get More Information from here: https://dotnettutorials.net/lesson/create-custom-exception-csharp/";
            }
        }
    }
}