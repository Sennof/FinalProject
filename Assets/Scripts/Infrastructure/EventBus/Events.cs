public interface IEvent { }

public struct UIOpenEvent : IEvent
{
    public bool opened;
}
