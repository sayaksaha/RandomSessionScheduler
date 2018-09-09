using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RandomScheduler.src
    {
    [Serializable]
    public class CustomException : Exception
        {
        public CustomException()
            {

            }
        public void DumpException()
            {
            Console.WriteLine("--------- Outer Exception Data ---------");
            WriteExceptionInfo(this);
            if (null != this)
                {
                Console.WriteLine("--------- Inner Exception Data ---------");
                WriteExceptionInfo(this.InnerException);

                }
            }
        public void WriteExceptionInfo(Exception ex)
            {
            Console.WriteLine("Message: {0}", ex.Message);
            Console.WriteLine("Exception Type: {0}", ex.GetType().FullName);
            Console.WriteLine("Source: {0}", ex.Source);
            Console.WriteLine("StrackTrace: {0}", ex.StackTrace);
            Console.WriteLine("TargetSite: {0}", ex.TargetSite);
            }

        }
    }
