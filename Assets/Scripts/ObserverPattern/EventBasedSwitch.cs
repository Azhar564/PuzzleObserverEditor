using UnityEngine;
using UnityEngine.Events;

public class EventBasedSwitch : MonoBehaviour
{
    [SerializeField] private UnityEvent OnSwitchActivated;
    [SerializeField] private UnityEvent OnSwitchDeactivated;

    public void ActivateEvent() => OnSwitchActivated.Invoke();
    public void DeactivateEvent() => OnSwitchDeactivated.Invoke();
}