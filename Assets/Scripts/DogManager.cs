using UnityEngine;
using TMPro;

public class DogManager : MonoBehaviour
{
    public TextMeshProUGUI talkText;
    [SerializeField] GameObject talkWindow;
    [SerializeField] EventSO eventSO;
    private int eventStep = 0;
    private string currentText = "";
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

    void OnTriggerEnter(Collider col)
    {
        if (col.gameObject.CompareTag("Weapon"))
        {
            EventProgress();
            talkText.text = currentText;
            talkWindow.SetActive(!talkWindow.activeSelf);

        }
    }

    private void EventProgress()
    {
        currentText = eventSO.eventList[eventStep].Words;
    }

    public void ClickEventButton(bool isYes)
    {
        Debug.Log("step: " + eventStep + ", isYes: " + isYes);
        switch (isYes)
        {
            case true:
                eventStep = eventSO.eventList[eventStep].Yes;
                break;
            case false:
                eventStep = eventSO.eventList[eventStep].No;
                break;
        }
    }
}
