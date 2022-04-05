using UnityEngine;
using System.Collections;

public class Stat : MonoBehaviour
{

    [SerializeField] protected int _level;
    [SerializeField] protected int _hp;
    [SerializeField] protected int _maxHp;

    [SerializeField] protected int _att;
    [SerializeField] protected int _def;

    [SerializeField] protected float _speed;
    [SerializeField] protected float _range;

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

    public float Range
    {
        get { return _range; }
        set { _range = value; }
    }

    private void Start()
    {
        Level = 1;
        Hp = 100;
        MaxHp = 100;
        Att = 10;
        Def = 1;
        MoveSpeed = 5f;
        Range = 8f;
    }
}
