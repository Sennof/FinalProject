using UnityEngine;
using UnityEngine.Events;

public class Interactable : MonoBehaviour
{
    [SerializeField] private UnityEvent _action;

    [Tooltip("The distance for interaction")]
    [SerializeField] private float _actableDistance ;
    public float ActableDistance { get; private set; }

    [Tooltip("The key for interaction")]
    [SerializeField] private KeyCode KeyCode = KeyCode.E;

    [SerializeField] private bool _isInteractable = true;

    public void Initialize()
    {
        ActableDistance = _actableDistance;
    }

    public void InvokeAction()
    {
        if (_isInteractable)
        {
            if (_action != null)
            {
                _action.Invoke();
                Debug.Log("Action invoked");
            }
            else
                Debug.LogError($"Cant invoke action because its null | {name} | Interactable");
        }
        else
        {
            Debug.Log("Action was invoked because it is not availiable");
        }
    }

    public KeyCode GetKeyCode() => KeyCode;
}
