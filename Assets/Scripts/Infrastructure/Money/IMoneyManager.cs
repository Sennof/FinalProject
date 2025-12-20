public interface IMoneyManager
{
    public void Initialize();

    public void AddMoney(int amount);

    public void SetMoney(int value);

    public bool Subtract(int amount);
}
