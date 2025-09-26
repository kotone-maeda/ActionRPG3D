using UnityEngine;

[CreateAssetMenu]
public class PlayerStatusSO : ScriptableObject
{
    [SerializeField] int hP;
    [SerializeField] int mP;
    [SerializeField] int attack;
    [SerializeField] int defence;

    // getがないとほかのファイルから参照できない。setがないとほかのファイルから書き換えができない
    // setはでもよろしくない。
    // SpecializeFieldではなく普通にpublicと上で定義しても同じ感じになるが、こっちの方法がいいらしい
    public int HP { get => hP; }
}
