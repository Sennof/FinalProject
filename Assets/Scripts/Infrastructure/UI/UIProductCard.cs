using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class UIProductCard : MonoBehaviour
{
    [SerializeField] private TMP_Text _title;
    [SerializeField] private Image _icon;

    private GameObject _prefab;
    private ProductData _productData;

    public void Initialize(ProductData data)
    {
        _productData = data;

        _title.text = data.TitleName;
        _icon.sprite = data.Icon;
        _prefab = data.Prefab;

        Debug.Log($"Initialized ui card | {transform.parent.name}");
    }

    public void SetCurrent()
    {
        EventBus<UIProductCardClickEvent>.Raise(new UIProductCardClickEvent { 
        ItemData = _productData,
        });
    }
}
