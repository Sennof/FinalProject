using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class InventoryUI : MonoBehaviour
{
    [SerializeField] private Color _defaultFrameColor;

    [SerializeField] private List<Image> _frameImages;
    [SerializeField] private List<Image> _iconImages;

    public void Initialize()
    {
        if (_frameImages.Count != 2 || _iconImages.Count != 2 || _defaultFrameColor == null)
            Debug.LogError($"Some necessary data is missing. Instability is possible | {name}");

        foreach(Image image in _frameImages)
        {
            image.color = _defaultFrameColor;
        }

        SelectSlot(0);
    }

    public void SetIcon(Sprite sprite, int index)
    {
        if (index > 1 || index < 0)
        {
            Debug.LogError($"Invalid inventory slot index | {name}");
            return;
        }

        _iconImages[index].sprite = sprite;
        _iconImages[index].color = Color.white;
    }

    public void ClearIcon(int index)
    {
        _iconImages[index].sprite = null;
        _iconImages[index].color = new Color(0, 0, 0, 0);
    }

    public void SelectSlot(int index)
    {
        int disableSlot = 1 - index;

        _frameImages[disableSlot].color = _defaultFrameColor;
        _frameImages[index].color = new Color(_defaultFrameColor.r, _defaultFrameColor.g, _defaultFrameColor.b-35, _defaultFrameColor.a);
    }
}
