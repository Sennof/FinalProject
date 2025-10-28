using UnityEngine;

public class InteractRay : MonoBehaviour
{
    private RaycastHit _rayHit;
    private GameObject _hit = null;
    private Interactable _target = null;

    private bool _enabled = true;

    private EventBinding<UIOpenEvent> _eventBinding;

    public void LateInitialize()
    {
        _eventBinding = new EventBinding<UIOpenEvent>(HandleUIOpen);
        EventBus<UIOpenEvent>.Register(_eventBinding);
    }

    private void OnDisable()
    {
        EventBus<UIOpenEvent>.Deregister(_eventBinding);
    }

    private void FixedUpdate()
    {
        if (!_enabled)
            return;

        if (Physics.Raycast(transform.position, transform.TransformDirection(Vector3.forward), out _rayHit, 15, ~3))
        {
            Debug.DrawRay(transform.position, transform.TransformDirection(Vector3.forward) * _rayHit.distance, Color.yellow);

            if (_hit != _rayHit.collider.gameObject)
            {
                _hit = _rayHit.collider.gameObject;
                _target = _hit.GetComponent<Interactable>();
            }
            else
            {
                if(_target.GetActableDistance() >= Vector3.Distance(transform.position, _target.transform.position))
                {
                    EventBus<UIInteractionEvent>.Raise(new UIInteractionEvent
                    {
                        KeyCode = _target.GetKeyCode(),
                    });

                    Debug.DrawRay(transform.position, transform.TransformDirection(Vector3.forward) * _rayHit.distance, Color.green);
                    if (Input.GetKeyDown(_target.GetKeyCode()))
                    {
                        _target.InvokeAction();
                    }
                }
            }
        }
    }

    private void HandleUIOpen(UIOpenEvent UIOpenEvent)
    {
        if(UIOpenEvent.opened)
            _enabled = false;
        else
            _enabled = true;
    }
}
