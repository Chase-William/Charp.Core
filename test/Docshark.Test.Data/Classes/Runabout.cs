using Docshark.Test.Data.Enumerations;
using Docshark.Test.Data.Interfaces;
using System;

namespace Docshark.Test.Data.Classes
{
    /// <summary>
    /// The most common type of boat used in medium to large size bodies of water.
    /// </summary>
    public class Runabout : Boat, IPowerable
    {
        public EngineSize Engine { get => throw new System.NotImplementedException(); set => throw new System.NotImplementedException(); }
        public int EngineCount { get => throw new System.NotImplementedException(); set => throw new System.NotImplementedException(); }
        public override int AbstractProperty { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }

        public override int AbstractNoSetProperty => throw new NotImplementedException();

        public override int AbstractNoGetProperty { set => throw new NotImplementedException(); }

        public override event EventHandler Docked;

        public override bool TryDock()
        {
            throw new System.NotImplementedException();
        }

        public override bool TryUndock()
        {
            throw new System.NotImplementedException();
        }
    }
}
