using System;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.Serialization;

public class TestActionInspector : MonoBehaviour
{
    [Serializable]
    /// <summary>
    /// Function definition for a button click event.
    /// </summary>
    public class ButtonClickedEvent : UnityEvent { }

    // Event delegates triggered on click.
    [FormerlySerializedAs("onClick")]
    [SerializeField]
    private ButtonClickedEvent m_OnClick = new ButtonClickedEvent();

}
