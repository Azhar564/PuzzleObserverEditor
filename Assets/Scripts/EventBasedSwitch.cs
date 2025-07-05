using UnityEngine;
using UnityEngine.Events;

public class EventBasedSwitch : MonoBehaviour
{
    [SerializeField] private UnityEvent OnSwitchActivated;

    public void TriggerEvent() => OnSwitchActivated.Invoke();
}