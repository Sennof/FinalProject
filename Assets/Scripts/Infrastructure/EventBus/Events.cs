using UnityEngine;

public interface IEvent { }

public struct UIOpenEvent : IEvent
{
    public bool opened;
}

public struct UIInteractionEvent : IEvent
{
    public bool? Enabled;
    public KeyCode? KeyCode;
}

public struct ItemPickUpEvent : IEvent
{
    public GameObject ItemObject;
    public ItemBase ItemScript;
}