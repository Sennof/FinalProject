public interface IUIManager
{
    public abstract void Initialize();

    public abstract void ToWindow(int type);

    public abstract void OffWindows();

    public abstract void OnWindow(UIWindowsEnum type);
}

