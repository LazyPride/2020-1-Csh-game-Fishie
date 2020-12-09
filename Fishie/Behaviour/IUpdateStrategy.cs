using System;
using System.Collections.Generic;
using System.Text;

namespace Fishie.Behaviour
{
    interface IUpdateStrategy
    {
        public void Update(float DeltaTime);
    }
}
