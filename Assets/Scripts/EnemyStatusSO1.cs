using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu]
public class EnemyStatusSO : ScriptableObject
{
    public List<EnemyStatus> enemyStatusList = new List<EnemyStatus>();

    [System.Serializable]
    public class EnemyStatus
    {
        [SerializeField] int hP;
        [SerializeField] int mP;
        [SerializeField] int attack;
        [SerializeField] int defence;

        // getがないとほかのファイルから参照できない。setがないとほかのファイルから書き換えができない
        // setはよろしくない
        // SpecializeFieldではなく普通にpublicと上で定義しても同じ感じになるが、こっちの方法がいいらしい
        public int HP { get => hP; }
    }
    
}
