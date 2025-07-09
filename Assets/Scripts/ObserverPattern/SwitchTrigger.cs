using Sirenix.OdinInspector;
using UnityEngine;

public class SwitchTrigger : PuzzleSubject
{
    [SerializeField, OnValueChanged("ToggleSwitchEditor")] private bool _isActive;

    private Animator animator;
    private int SWITCH_ON = Animator.StringToHash("SwitchOn");
    private int SWITCH_OFF = Animator.StringToHash("SwitchOff");

    private EventBasedSwitch eventBasedSwitch = null;
    void Awake()
    {
        animator = GetComponent<Animator>();
        if (!animator)
        {
            animator = GetComponentInChildren<Animator>();
        }
    }

    private void SetActivate()
    {
        _isActive = true;
        TriggerSwitch();
    }

    private void SetDeactivate()
    {
        _isActive = false;
        TriggerSwitch();
    }

    private void TriggerSwitch()
    {
        NotifyObservers(_isActive ? "SWITCH_ON" : "SWITCH_OFF");

        if (_isActive)
        {
            animator.Play(SWITCH_ON);
            if (TryGetComponent(out eventBasedSwitch))
            {
                eventBasedSwitch.ActivateEvent();
            }
        }

        else
        {
            animator.Play(SWITCH_OFF);
            if (TryGetComponent(out eventBasedSwitch))
            {
                eventBasedSwitch.DeactivateEvent();
            }
        }
    }

    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            SetActivate();
        }
    }

    void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            SetDeactivate();
        }
    }

#if UNITY_EDITOR
    private void ToggleSwitchEditor()
    {
        TriggerSwitch();
    }
#endif
}