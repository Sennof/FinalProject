using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Interactable : MonoBehaviour
{
    [SerializeField] private UnityEvent _action;

    [Tooltip("The distance for interaction")]
    [SerializeField] private float _actableDistance;

    [Tooltip("The key for interaction")]
    [SerializeField] private KeyCode KeyCode = KeyCode.E;

    [SerializeField] private bool _isInteractable = true;

    public void InvokeAction()
    {
        if (_isInteractable)
        {
            if (_action != null)
            {
                _action.Invoke();
            }
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
