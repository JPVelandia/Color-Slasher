using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IObserver
{
    void ColorMechUpdate(ColorMech colorMech);
}

public interface ISubject
{
    void Notify();
}
