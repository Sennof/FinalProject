using TMPro;
using UnityEngine;

public class DelieverySideMenu : MonoBehaviour
{
    [SerializeField] private GameObject _buyButtonFrame;

    [SerializeField] private TMP_Text _title;
    [SerializeField] private TMP_Text _description;

    [SerializeField] private TMP_Text _buyAmountText;
    private int _buyAmount = 1;

    private EventBinding<UIProductCardClickEvent> _eventBinding;
    private ProductData _productData;

    public void Initialize()
    {
        UpdateAmountText();

        _eventBinding = new EventBinding<UIProductCardClickEvent>(HandleUIProductCardClickEvent);
        EventBus<UIProductCardClickEvent>.Register(_eventBinding);

        _buyButtonFrame.SetActive(false);
    }

    public void DeInitialize()
    {
        EventBus<UIProductCardClickEvent>.Deregister(_eventBinding);
    }

    public void ChangeAmount(string op) //inspector feature
    {
        if (op == "-")
        {
            if (_buyAmount > 1)
                _buyAmount--;
        }
        else if (op == "+")
            _buyAmount++;
        else
            _buyAmount = 1;

        UpdateAmountText();
    }

    private void HandleUIProductCardClickEvent(UIProductCardClickEvent eventData)
    {
        if(!_buyButtonFrame.activeInHierarchy)
            _buyButtonFrame.SetActive(true);

        _productData = eventData.ItemData;
        UpdateUI();
    }

    private void UpdateUI()
    {
        _title.text = _productData.TitleName;
        _description.text = _productData.Description;

        _buyAmount = 1;
        UpdateAmountText();
    }

    public void RequestDelivery()
    {
        EventBus<DelieveryRequestEvent>.Raise(new DelieveryRequestEvent
        {
            ProductAmount = _buyAmount,
            Prefab = _productData.Prefab,
        });
    }

    private void UpdateAmountText() => _buyAmountText.text = $"Количество: {_buyAmount.ToString()}";
}
