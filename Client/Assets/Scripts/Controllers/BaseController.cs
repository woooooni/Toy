using UnityEngine;
using System.Collections;
using UnityEngine.AI;
using static Define;
public class BaseController : MonoBehaviour
{
    [SerializeField]
    private GameObject _target = null;
    public GameObject Target
    {
        get { return _target; }
        set { _target = value; }
    }

    [SerializeField]
    private State _state;
    public State State
    {
        get { return _state; }
        set
        {
            if (_state == value)
                return;
            switch (value)
            {
                case State.Idle:
                    _anim.CrossFade("IDLE", 0.1f);
                    break;
                case State.Move:
                    _anim.CrossFade("MOVE", 0.1f);
                    break;
                case State.Attack:
                    break;
                case State.Die:
                    break;
            }
            _state = value;
        }
    }


    [SerializeField]
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
