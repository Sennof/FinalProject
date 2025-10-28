using System;
using UnityEngine;

public class Interactable : MonoBehaviour
{
    [Tooltip("The action that will be performed")]
    [SerializeField] private Action Action;
    [Tooltip("The distance for interaction")]
    [SerializeField] private float _actableDistance;
    [Tooltip("The key for interaction")]
    [SerializeField] private KeyCode KeyCode = KeyCode.E;

    [SerializeField] private bool _isInteractable = true;

    public void InvokeAction()
    {
        if (_isInteractable)
        {
            if (Action != null)
                Action();
            else
                Debug.LogError($"Cant invoke action because its null | {name} | Interactable");

            Debug.Log("Action invoked");
        }
        else
        {
            Debug.Log("Action was invoked because it is not availiable");
        }
    }
    
    public float GetActableDistance() => _actableDistance;

    public KeyCode GetKeyCode() => KeyCode;
}
