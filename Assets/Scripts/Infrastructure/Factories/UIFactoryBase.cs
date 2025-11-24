using System.Collections.Generic;
using UnityEngine;

public class UIFactoryBase : MonoBehaviour, IUIFactoryBase
{
    [SerializeField] private string _dataPath;
    [SerializeField] private Transform _folder;

    public List<GameObject> _generatedUICards = new(); //PUBLIC <- DEBUG, LATER: PUBLIC -> PRIVATE

    //PUBLIC <- DEBUG, LATER: PUBLIC -> PRIVATE
    public UIBaseData[] _data; //storage for importing data from resources

    public void Initialize()
    {
        _data = Resources.LoadAll<ProductData>(_dataPath);

        GenerateUI();
        InitializeGenItems();
    }

    public void GenerateUI()
    {
        if (_data.Length == 0)
            return;

        foreach (UIBaseData data in _data)
        {
            GameObject card = Instantiate(data.UICardPrefab, _folder);
            _generatedUICards.Add(card);
        }
    }

    public void InitializeGenItems()
    {
        for(int i = 0; i < _generatedUICards.Count; i++)
        {
            _generatedUICards[i].GetComponent<UIProductCard>().Initialize(_data[i].TitleName, _data[i].Icon, ((_data[i]) as ProductData).Prefab);
        }
    }

    public void KillUI()
    {
        for(int i = 0; i < _generatedUICards.Count; i++)
        {
            Destroy(_generatedUICards[i]);
            _generatedUICards[i] = null;
        }
    }

    public void ClearData()
    {
        _generatedUICards.Clear();
    }
}
