using Sirenix.OdinInspector;
using UnityEngine;

public class SwitchTrigger : PuzzleSubject
{
    [SerializeField, OnValueChanged("ToggleSwitchEditor")] private bool _isActive;

    public void ToggleSwitch()
    {
        _isActive = !_isActive;
        NotifyObservers(_isActive ? "SWITCH_ON" : "SWITCH_OFF");
    }

    private void ToggleSwitchEditor()
    {
        NotifyObservers(_isActive ? "SWITCH_ON" : "SWITCH_OFF");
    }
}