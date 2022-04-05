using UnityEngine;
using System.Collections;
using UnityEngine.AI;
using static Define;
public class BaseController : MonoBehaviour
{
    [SerializeField]
    public GameObject _target;

    [SerializeField]
    private State _state;
    public virtual State State
    {
        get { return _state; }
        set
        {
            if (_state == value)
                return;
            switch (value)
            {
                case State.Idle:
                    break;
                case State.Move:
                    break;
                case State.Attack:
                    break;
                case State.Die:
                    break;
            }
            _state = value;
        }
    }

    [SerializeField] protected int _speed;
    public int Speed
    {
        get { return _speed; }
        set { _speed = value; }
    }

    [SerializeField] private float _range;
    public float Range
    {
        get { return _range; }
        set { _range = value; }
    }


    [SerializeField] int _hp;
    public int Hp
    {
        get { return _hp; }
        set { _hp = value; }
    }


    [SerializeField]
    protected bool _canMove = true;
    protected Animator _anim;

    // Use this for initialization
    void Start()
    {
        Init();
    }

    // Update is called once per frame
    void Update()
    {
        UpdateController();
    }

    protected virtual void Init()
    {
        _anim = GetComponent<Animator>();
    }

    protected virtual void UpdateController()
    {
        switch (State)
        {
            case State.Idle:
                UpdateIdle();
                break;
            case State.Move:
                UpdateMoving();
                break;
            case State.Attack:
                UpdateAttack();
                break;
            case State.Die:
                UpdateDead();
                break;
            default:
                break;
        }
    }


    public virtual void OnDamaged(GameObject attacker, int damage) { }
    public virtual void UpdateIdle() { }
    public virtual void UpdateMoving() { }
    public virtual void UpdateAttack() { }
    public virtual void UpdateDead() { }

}
