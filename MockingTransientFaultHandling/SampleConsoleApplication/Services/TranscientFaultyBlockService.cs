using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SampleConsoleApplication.Services
{
    public class TranscientFaultyBlockService : IBlockService
    {
        public TranscientFaultyBehavior FaultBehavior { get; set; }

        #region Probability based
        private static readonly Random _random = new Random();
        private double _probabilityOfFailure = 0.25d;
        #endregion

        #region Cooldown based
        private TimeSpan _elapsedTime = TimeSpan.Zero;
        private DateTime _executionDateTime = DateTime.UtcNow;
        private TimeSpan _coolDowntime = TimeSpan.FromMilliseconds(200);
        #endregion

        public TranscientFaultyBlockService()
        {
            FaultBehavior = TranscientFaultyBehavior.CoolDownBased;
        }

        public void PutBlock(string id, object userState)
        {
            switch (FaultBehavior)
            {
                case TranscientFaultyBehavior.ProbabilityBased:
                    var randomNumber = _random.NextDouble();
                    if (randomNumber <= _probabilityOfFailure)
                    {
                        System.Threading.Thread.Sleep(100);
                        throw new BlockServiceException(string.Format("Failed on Processing Id: {0}. Chances of Failure  {1:##.##}% ({2:##.##}%)", id, _probabilityOfFailure * 100, randomNumber * 100));
                    }
                    break;
                case TranscientFaultyBehavior.CoolDownBased:
                    var now = DateTime.UtcNow;
                    _elapsedTime += (now - _executionDateTime);
                    if (_elapsedTime < _coolDowntime)
                    {
                        System.Threading.Thread.Sleep(100);
                        throw new BlockServiceException(string.Format("Please wait to process Id: {0}", id));
                    }
                    System.Threading.Thread.Sleep(1000);
                    System.Diagnostics.Trace.WriteLine(string.Format("[{0}]", DateTime.Now.ToString("o"), id, userState));
                    _executionDateTime = now;
                    _elapsedTime = TimeSpan.Zero;
                    break;
            }




        }
    }
}
