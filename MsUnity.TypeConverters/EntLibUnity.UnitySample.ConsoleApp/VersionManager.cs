using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using EntLibUnity.Infrastructure;

namespace EntLibUnity.UnitySample
{
    public class VersionManager : IVersionManager
    {
        private readonly Version _version;

        public string Version
        {
            get { return _version.ToString(); }
        }

        public VersionManager(Version version)
        {
            _version = version;
        }
    }
}
