using UnityEngine;

[CreateAssetMenu(fileName = "ItemData", menuName = "Scriptable Objects/ItemData")]
public class ItemData : ScriptableObject
{
    public string Itemname;
    public ItemType itemType;
    public int ItemValue;
    public AudioClip collectSound;
}

public enum ItemType
{
    Apple,
    Orange,
    Kiwi,
    Banana,
    Coin,
    Weapon,
    Armor,
    Cherries,
}


