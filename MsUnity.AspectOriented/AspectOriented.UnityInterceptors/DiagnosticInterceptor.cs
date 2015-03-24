using System;
using System.Collections.Generic;
using Microsoft.Practices.Unity.InterceptionExtension;

namespace AspectOriented.UnityInterceptors
{
    public class DiagnosticInterceptor : IInterceptionBehavior
    {
        public DiagnosticInterceptor()
        {
        }

        #region IInterceptionBehavior implementation
        public IMethodReturn Invoke(IMethodInvocation input, GetNextInterceptionBehaviorDelegate getNext)
        {
            System.Console.WriteLine(String.Format("[{0}:{1}]", this.GetType().Name, "Invoke"));

            // BEFORE the target method execution 
            System.Console.WriteLine(String.Format("{0}", input.MethodBase.ToString()));

            // Yield to the next module in the pipeline
            var methodReturn = getNext().Invoke(input, getNext);

            // AFTER the target method execution 
            if (methodReturn.Exception == null)
            {
                System.Console.WriteLine(String.Format("Successfully finished {0}", input.MethodBase.ToString()));
            }
            else
            {
                System.Console.WriteLine(String.Format("Finished {0} with exception {1}: {2}", input.MethodBase.ToString(), methodReturn.Exception.GetType().Name, methodReturn.Exception.Message));
            }


            return methodReturn;
        }

        public IEnumerable<Type> GetRequiredInterfaces()
        {
            System.Console.WriteLine(String.Format("[{0}:{1}]", this.GetType().Name, "GetRequiredInterfaces"));
            return Type.EmptyTypes;
        }

        public bool WillExecute
        {
            get
            {
                System.Console.WriteLine(String.Format("[{0}:{1}]", this.GetType().Name, "WillExecute"));
                return true;
            }
        }
        #endregion
    }
}

