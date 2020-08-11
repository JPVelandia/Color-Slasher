using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IObserverColor
{
    void ColorMechUpdate(ColorMech colorMech);
}

public interface ISubject
{
    void Notify();
}

public interface IObserverHUD
{
    void SubjectUpdate();
}
