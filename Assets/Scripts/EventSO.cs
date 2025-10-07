using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu]
public class EventSO : ScriptableObject
{
    public List<Events> eventList = new List<Events>();

    [System.Serializable]
    public class Events
    {
        [SerializeField] string name;
        [TextArea]
        [SerializeField] string words;
        [SerializeField] int yes;
        [SerializeField] int no;
        public string Name { get => name; }
        public string Words { get => words; }
        public int Yes { get => yes; }
        public int No { get => no; }
    }
}
