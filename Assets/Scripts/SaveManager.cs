using UnityEngine;

public class SaveManager : MonoBehaviour
{
    [SerializeField] GameObject player;
    public void Save()
    {
        PlayerPrefs.SetInt("currentHP", player.GetComponent<PlayerController>().currentHP);
        PlayerPrefs.Save();
    }
    
    public void Load()
    {
        player.GetComponent<PlayerController>().currentHP = PlayerPrefs.GetInt("currentHP", 0);
    }
}
