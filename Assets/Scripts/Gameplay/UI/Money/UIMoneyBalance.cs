using TMPro;
using UnityEngine;

public class UIMoneyBalance : MonoBehaviour
{
    [SerializeField] private TMP_Text _moneyBalanceText;

    private EventBinding<MoneyAmountChangeEvent> _eventBinding;


   public void Initialize()
   {
        _eventBinding = new EventBinding<MoneyAmountChangeEvent>(UpdateMoneyBalanceUI);
        EventBus<MoneyAmountChangeEvent>.Register(_eventBinding);
   }

    public void UpdateMoneyBalanceUI(MoneyAmountChangeEvent eventData)
    {
        _moneyBalanceText.text = eventData.Money.ToString();
    }
}
