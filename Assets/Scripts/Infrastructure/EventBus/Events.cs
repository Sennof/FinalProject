using UnityEngine;

public interface IEvent { }

#region UI
public struct UIOpenEvent : IEvent
{
    public bool opened;
}

public struct UIInteractionEvent : IEvent
{
    public bool? Enabled;
    public KeyCode? KeyCode;
}

public struct UIProductCardClickEvent: IEvent
{
    public ProductData ItemData;
}

#endregion

#region Core
public struct ItemPickUpEvent : IEvent
{
    public GameObject ItemObject;
    public ItemBase ItemScript;
}

public struct DelieveryRequestEvent: IEvent
{
    public int ProductAmount;
    public GameObject Prefab;
}
#endregion