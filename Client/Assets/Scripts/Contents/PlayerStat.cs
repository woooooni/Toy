using UnityEngine;
using System.Collections;

public class PlayerStat : Stat
{
    // Use this for initialization
    [SerializeField] int _exp;
    public int Exp
    {
        get { return _exp; }
        set { _exp = value; }
    }

    void Start()
    {
        Level = 1;
        Hp = 100;
        MaxHp = 100;
        Att = 10;
        Def = 1;
        MoveSpeed = 5;
        Range = 8;
        Exp = 0;
    }

    // Update is called once per frame
    void Update()
    {

    }
}
