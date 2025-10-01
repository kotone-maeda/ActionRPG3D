using UnityEngine;
using TMPro;

public class StatusWindowManager : MonoBehaviour
{
    [SerializeField] PlayerStatusSO playerStatusSO;
    public TextMeshProUGUI nameValue;
    public TextMeshProUGUI hpValue;
    public TextMeshProUGUI mpValue;
    public TextMeshProUGUI attackValue;
    public TextMeshProUGUI defenceValue;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        nameValue.text = "yusha";
        hpValue.text = GameObject.Find("MaleCharacterPBR").GetComponent<PlayerController>().currentHP.ToString();
        mpValue.text = playerStatusSO.MP.ToString();
        attackValue.text = playerStatusSO.ATTACK.ToString();
        defenceValue.text = playerStatusSO.DEFENCE.ToString();

    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
