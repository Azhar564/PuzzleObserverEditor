using UnityEngine;

public abstract class PuzzleObserver : MonoBehaviour
{
    public System.Action onDestroy;
    public abstract void OnNotify(PuzzleSubject subject, string eventType);

    protected virtual void OnDestroy()
    {
        onDestroy?.Invoke();
    }
}
