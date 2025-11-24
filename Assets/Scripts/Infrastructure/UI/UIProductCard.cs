using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class UIProductCard : MonoBehaviour
{
    [SerializeField] private TMP_Text _title;
    [SerializeField] private Image _icon;

    private GameObject _prefab;

    public void Initialize(string title, Sprite icon, GameObject prefab)
    {
        _title.text = title;
        _icon.sprite = icon;
        _prefab = prefab;

        Debug.Log($"Initialized ui card | {transform.parent.name}");
    }

    public void Buy()
    {
        //MoneyMager
        //SpawnManager
        Debug.Log("Spawned");
    }
}
