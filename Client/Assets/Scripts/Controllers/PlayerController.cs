using System.Collections;
using UnityEngine;
using UnityEngine.AI;
using static Define;

public class PlayerController : BaseController
{
    float _move_ratio = 0f;
    private NavMeshAgent _agent;

    protected override void Init()
    {
        base.Init();
        _agent = GetComponent<NavMeshAgent>();
        _agent.updateRotation = false;
    }

    protected override void UpdateController()
    {
        base.UpdateController();
    }

    protected void SetDest(Vector3 dest)
    {
        _agent.SetDestination(dest);
        _agent.stoppingDistance = 0;
        State = State.Move;
    }

    protected void SetDest(Vector3 dest, float distance)
    {
        _agent.SetDestination(dest);
        _agent.stoppingDistance = distance;
        State = State.Move;
    }

    protected void Turn()
    {
        if(_target != null)
        {
            transform.forward = _target.transform.position - transform.position;
            return;
        }
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        RaycastHit hit;
        if(Physics.Raycast(ray, out hit))
        {
            Vector3 mouseDir = new Vector3(hit.point.x, transform.position.y, hit.point.z) - transform.position;
            transform.forward = mouseDir;
        }
    }


    #region Skills
    protected Coroutine _coSkill;
    public virtual IEnumerator NormalAttack()
    {
        yield return null;
        ////스테이트 변경
        //Turn();
        //State = State.Attack;
        //_anim.Play(AttackType.NORMAL_ATTACK.ToString());

        //_target.GetComponent<BaseController>().OnDamaged(gameObject, 10);
        ////총알생성
        //yield return new WaitForSeconds(0.975f);

        ////초기화
        //StopCoroutine(_coSkill);
        //_coSkill = null;
    }

    public virtual IEnumerator QSkill()
    {
        yield return null;
    }

    public virtual IEnumerator WSkill()
    {
        yield return null;
    }

    public virtual IEnumerator ESkill()
    {
        yield return null;
    }

    public virtual IEnumerator RSkill()
    {
        yield return null;
    }
    #endregion



    #region Override Update Method
    public override void UpdateIdle()
    {
        base.UpdateIdle();
        _move_ratio = Mathf.Lerp(_move_ratio, 0, 10.0f * Time.deltaTime);
        _anim.SetFloat("move_ratio", _move_ratio);
        _anim.Play("IDLE_MOVE");


        if(_target != null && Vector3.Distance(_target.transform.position, transform.position) <= Range)
        {
            State = State.Attack;
        }
    }

    public override void UpdateMoving()
    {
        base.UpdateMoving();

        if ((_agent.destination == null) || (Vector3.Distance(_agent.destination, transform.position) <= 0.1f))
        {
            State = State.Idle;
            return;
        }
        _move_ratio = Mathf.Lerp(_move_ratio, 1, 10.0f * Time.deltaTime);
        _anim.SetFloat("move_ratio", _move_ratio);
        _anim.Play("IDLE_MOVE");
        transform.rotation = Quaternion.Slerp(transform.rotation, Quaternion.LookRotation(_agent.destination - transform.position), 10.0f * Time.deltaTime);

        if (_target != null && Vector3.Distance(_target.transform.position, transform.position) <= Range)
        {
            _agent.ResetPath();
            State = State.Attack;
            return;
        }
    }

    public override void UpdateAttack()
    {
        base.UpdateAttack();
        if(_coSkill == null)
        {
            if (_target == null)
                State = State.Idle;
            else
                _coSkill = StartCoroutine("NormalAttack");
        }
    }

    public override void UpdateDead()
    {
        base.UpdateDead();
    }
    #endregion
}
