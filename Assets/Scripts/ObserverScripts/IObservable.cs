using System.Collections;
using System.Collections.Generic;
using UnityEngine;

interface IObservable
{
    void RegisterObserver(IObserver item);
    void RemoveObserver(IObserver item);
    void NotifyObservers();
}
