using UnityEngine;

public class MoneyManager : MonoBehaviour, IMoneyManager
{
    public int Money { get; private set; }


    public void Initialize()
    {
        Money = 100; //TODO: saving system
        Debug.Log($"Money {Money} | MoneyManager");
    }

    public void AddMoney(int amount)
    {
        Debug.Log($"Money: {Money}\n" +
            $"then Money: {Money + amount} | MoneyManager");
        
        Money += amount;
    }

    public void SetMoney(int value)
    {
        Debug.Log($"Money: {Money}\n" +
            $"then Money: {value} | MoneyManager");

        Money = value;
    }

    public bool Subtract(int amount)
    {
        if (amount <= Money)
        {
            Debug.Log($"Money: {Money}\n" +
                $"then Money: {Money - amount} | MoneyManager");

            Money -= amount;
            return true;
        }
        else
        {
            Debug.Log("Not enough money | MoneyManager");
            return false;
        }
    }
}
