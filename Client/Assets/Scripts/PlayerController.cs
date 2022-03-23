using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static Define;

public class PlayerController : MonoBehaviour
{
    Vector3 _dest;
    float _speed = 5.0f;
    float _move_ratio = 0f;

    [SerializeField]
    private PState _state;
    public PState State
    {
        get { return _state; }
        set
        {
            _state = value;
        }
    }
    Animator _anim;

    void Init()
    {
        _anim = GetComponent<Animator>();
    }


    /* Unity */
    void Start()
    {
        Init();
    }

    void Update()
    {
        GetInput();
        Move();
        UpdateAnimation();
    }

    void GetInput()
    {
        if (Input.GetMouseButton(1))
        {
            RaycastHit hit;
            if (Physics.Raycast(Camera.main.ScreenPointToRay(Input.mousePosition), out hit))
                SetDest(hit.point);
        }
    }

    void SetDest(Vector3 dest)
    {
        State = PState.Move;
        _dest = dest;
    }

    void Move() 
    {
        if(_dest == null)
            return;

        if (Vector3.Distance(_dest, transform.position) <= 0.1f) 
        {
            State = PState.Idle;
            return; 
        }
        
        Vector3 dir = _dest - transform.position; //방향 구하기
        transform.rotation = Quaternion.Lerp(transform.rotation, Quaternion.LookRotation(dir), _speed * Time.deltaTime);
        transform.position += dir.normalized * Time.deltaTime * _speed;
    }

    void UpdateAnimation()
    {
        switch (State)
        {
            case PState.Idle:
                _move_ratio = Mathf.Lerp(_move_ratio, 0, 10.0f * Time.deltaTime);
                _anim.SetFloat("move_ratio", _move_ratio);
                _anim.Play("IDLE_MOVE");
                break;

            case PState.Move:
                _move_ratio = Mathf.Lerp(_move_ratio, 1, 10.0f * Time.deltaTime);
                _anim.SetFloat("move_ratio", _move_ratio);
                _anim.Play("IDLE_MOVE");
                break;
        }
    }

    
}
