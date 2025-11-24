using UnityEngine;

public class UIBaseData : ScriptableObject
{
    #region UI
    [Header("UI")]

    [Tooltip("")]
    public string TitleName;
    [Tooltip("")]
    public Sprite Icon;
    [Tooltip("")]
    public GameObject UICardPrefab;
    #endregion
}
