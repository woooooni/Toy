using UnityEngine;
using System.Collections;

public class Stat : MonoBehaviour
{

    [SerializeField] int _level;
    [SerializeField] int _hp;
    [SerializeField] int _maxHp;

    [SerializeField] int _att;
    [SerializeField] int _def;

    [SerializeField] float _speed;

    public int Level
    {
        get { return _level; }
        set { _level = value; }
    }

    public int Hp
    {
        get { return _level; }
        set { _level = value; }
    }

    public int MaxHp
    {
        get { return _level; }
        set { _level = value; }
    }

    public int Att
    {
        get { return _level; }
        set { _level = value; }
    }

    public int Def
    {
        get { return _level; }
        set { _level = value; }
    }

    public float MoveSpeed
    {
        get { return _speed; }
        set { _speed = value; }
    }
}
