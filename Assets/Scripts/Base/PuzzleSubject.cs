using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class PuzzleSubject : MonoBehaviour
{
    private List<PuzzleObserver> _observers = new List<PuzzleObserver>();

    public void AddObserver(PuzzleObserver observer) => _observers.Add(observer);
    public void RemoveObserver(PuzzleObserver observer) => _observers.Remove(observer);

    protected void NotifyObservers(string eventType)
    {
        foreach (var observer in _observers)
        {
            observer.OnNotify(this, eventType);
        }
    }
}
