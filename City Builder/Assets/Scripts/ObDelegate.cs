using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

class ObDelegate : Observer
{
    public bool obFlag;

    public override void OnNotify()
    {
        obFlag = true;
    }
}
