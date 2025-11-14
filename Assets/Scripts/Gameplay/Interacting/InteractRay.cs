using UnityEngine;

public class InteractRay : MonoBehaviour
{
    private RaycastHit _rayHit;
    private GameObject _hit = null;
    private Interactable _target = null;

    private bool _enabled = true;
    private bool _UIenabled = false;
    private bool _eventState = true;

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

    private void Update()
    {
        if (!_enabled && _UIenabled)
            return;

        Raycasting();
    }

    private void TryInvokeOnUIEvent()
    {
        if (!_eventState)
        {
            EventBus<UIInteractionEvent>.Raise(new UIInteractionEvent
            {
                Enabled = true,
                KeyCode = null,
            });

            _eventState = true;
        }
    }

    private void TryInvokeOffUIEvent()
    {
        if (_eventState)
        {
            EventBus<UIInteractionEvent>.Raise(new UIInteractionEvent
            {
                Enabled = false,
                KeyCode = null,
            });

            _eventState = false;
        }
    }

    private void HandleUIOpen(UIOpenEvent UIOpenEvent)
    {
        if(UIOpenEvent.opened)
            _UIenabled = false;
        else
            _UIenabled = true;
    }

    private void Raycasting()
    {
        if (Physics.Raycast(transform.position, transform.TransformDirection(Vector3.forward), out _rayHit, 10, ~3))
        {
            Debug.DrawRay(transform.position, transform.TransformDirection(Vector3.forward) * _rayHit.distance, Color.yellow);

            if (_hit != _rayHit.collider.gameObject)
            {
                _hit = _rayHit.collider.gameObject;
                _target = _hit.GetComponent<Interactable>();

                EventBus<UIInteractionEvent>.Raise(new UIInteractionEvent
                {
                    KeyCode = _target.GetKeyCode(),
                    Enabled = null,
                });
            }

            if (_target.ActableDistance >= _rayHit.distance)
            {
                TryInvokeOnUIEvent();

                Debug.DrawRay(transform.position, transform.TransformDirection(Vector3.forward) * _rayHit.distance, Color.green);

                if (Input.GetKeyDown(_target.GetKeyCode()))
                {
                    if (_hit.tag == "Item")
                    {
                        EventBus<ItemPickUpEvent>.Raise(new ItemPickUpEvent
                        {
                            ItemObject = _hit,
                            ItemScript = _hit.GetComponent<ItemBase>(),
                        });
                    }
                    else
                        _target.InvokeAction();
                }
            }
            else
            {
                TryInvokeOffUIEvent();
            }
        }
        else
        {
            TryInvokeOffUIEvent();
        }
    }
}
