using UnityEngine;

public class Door : PuzzleObserver
{
    [SerializeField] private Animator _animator;

    public override void OnNotify(PuzzleSubject subject, string eventType)
    {
        if (eventType == "SWITCH_ON")
        {
            _animator.Play("DoorOpen");
        }
        else if (eventType == "SWITCH_OFF")
        {
            _animator.Play("DoorClose");
        }
    }
}