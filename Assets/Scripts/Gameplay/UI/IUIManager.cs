public interface IUIManager
{
    public abstract void Initialize();

    public abstract void ToWindow(UIWindowsEnum type);

    public abstract void OffWindows();

    public abstract void OnWindow(UIWindowsEnum type);
}

