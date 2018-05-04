using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;

public abstract class Observer : MonoBehaviour
{
    public abstract void OnNotify(GameObject g);
}
