using UnityEngine;

[CreateAssetMenu(fileName = "ProductConf", menuName = "Data/Product", order = 0)]
public class ProductData : UIBaseData
{
    #region Core
    [Header("Core")]

    [Tooltip("")]
    public int Price;
    [Tooltip("")][Range(0, 1)]
    public float DiscountMax;
    #endregion

    #region InGame
    [Header("InGame")]

    [Tooltip("")]
    public GameObject Prefab;

    #endregion
}


