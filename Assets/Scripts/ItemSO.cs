using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu]
public class ItemSO : ScriptableObject
{
    public List<Items> itemList = new List<Items>();

    [System.Serializable]
    public class Items
    {
        [SerializeField] itemType type;
        [SerializeField] string itemName;
        [TextArea]
        [SerializeField] string description;
        public enum itemType
        {
            coin,
            weapon,
            armour,
            tool,
        }
        public string ItemName { get => itemName; }
    }
}
