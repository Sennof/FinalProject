using TMPro;
using UnityEngine;

public class DelieverySideMenu : MonoBehaviour
{
    [SerializeField] private TMP_Text _title;
    [SerializeField] private TMP_Text _description;

    [SerializeField] private TMP_Text _buyAmountText;
    private int _buyAmount = 0;

    private EventBinding<UIProductCardClickEvent> _eventBinding;
    private ProductData _productData;

    public void Initialize()
    {
        UpdateAmountText();

        _eventBinding = new EventBinding<UIProductCardClickEvent>(HandleUIProductCardClickEvent);
        EventBus<UIProductCardClickEvent>.Register(_eventBinding);
    }

    public void DeInitialize()
    {
        EventBus<UIProductCardClickEvent>.Deregister(_eventBinding);
    }

    public void ChangeAmount(string op) //inspector feature
    {
        if (op == "-")
        {
            if (_buyAmount > 0)
                _buyAmount--;
        }
        else if (op == "+")
            _buyAmount++;
        else
            _buyAmount = 0;

        UpdateAmountText();
    }

    private void HandleUIProductCardClickEvent(UIProductCardClickEvent eventData)
    {
        _productData = eventData.ItemData;
        UpdateUI();
    }

    private void UpdateUI()
    {
        _title.text = _productData.TitleName;
        _description.text = _productData.Description;

        _buyAmount = 0;
        UpdateAmountText();
    }

    private void UpdateAmountText() => _buyAmountText.text = $"Количество: {_buyAmount.ToString()}";
}
