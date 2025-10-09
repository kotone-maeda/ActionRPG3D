using UnityEngine;
using TMPro;

public class ItemBoxManager : MonoBehaviour
{
    [SerializeField] ItemSO itemSO;
    // [SerializeField] TextMeshProUGUI coinValue;
    // [SerializeField] TextMeshProUGUI potionValue;
    [SerializeField] TextMeshProUGUI itemOpenText;
    [SerializeField] GameObject player;
    [SerializeField] GameObject itemImage_prefab;
    [SerializeField] GameObject itemQty_prefab;
    [SerializeField] Transform itemBox3Image;
    [SerializeField] Transform itemBox3Text;
    
    public int getItem;
    private int[] itemQtyAry;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        itemQtyAry = new int[itemSO.itemList.Count];
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void ItemGet()
    {
        itemQtyAry[getItem] += 1;
    }

    public void ItemOpen()
    {
        // coinValue.text = itemQtyAry[0].ToString();
        // potionValue.text = itemQtyAry[1].ToString();
        string itemText = "";
        for (int i = 0; i < itemQtyAry.Length; i++)
        {
            itemText += itemSO.itemList[i].ItemName + " : " + itemQtyAry[i].ToString() + "\n";
        }
        itemOpenText.text = itemText;
    }

    public void UseItem(int itemNo)
    {
        
    }
}
