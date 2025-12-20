using UnityEngine;

public class MoneyManager : MonoBehaviour, IMoneyManager
{
    public int Money { get; private set; }


    public void Initialize()
    {
        Money = 0; //TODO: saving system
        Debug.Log($"Money {Money} | MoneyManager");

        SetMoney(100);
    }

    public void AddMoney(int amount)
    {
        Debug.Log($"Money: {Money}\n" +
            $"then Money: {Money + amount} | MoneyManager");
        
        Money += amount;
        EventBus<MoneyAmountChangeEvent>.Raise(new MoneyAmountChangeEvent
        {
            Money = Money,
        });
    }

    public void SetMoney(int value)
    {
        Debug.Log($"Money: {Money}\n" +
            $"then Money: {value} | MoneyManager");

        Money = value;
        EventBus<MoneyAmountChangeEvent>.Raise(new MoneyAmountChangeEvent
        {
            Money = Money,
        });
    }

    public bool Subtract(int amount)
    {
        if (amount <= Money)
        {
            Debug.Log($"Money: {Money}\n" +
                $"then Money: {Money - amount} | MoneyManager");

            Money -= amount;
            EventBus<MoneyAmountChangeEvent>.Raise(new MoneyAmountChangeEvent
            {
                Money = Money,
            });

            return true;
        }
        else
        {
            Debug.Log("Not enough money | MoneyManager");
            return false;
        }
    }
}
