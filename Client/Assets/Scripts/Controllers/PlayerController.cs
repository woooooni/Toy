using System.Collections;
using UnityEngine;
using UnityEngine.AI;
using static Define;

public class PlayerController : BaseController
{
    
    private NavMeshAgent _agent;
    protected PlayerStat _stat;

    protected override void Init()
    {
        base.Init();
        _agent = GetComponent<NavMeshAgent>();
        _agent.updateRotation = false;
        _stat = gameObject.GetOrAddComponent<PlayerStat>();
        if(_stat != null)
            _agent.speed = _stat.MoveSpeed;

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
        if (Target != null)
        {
            transform.forward = Target.transform.position - transform.position;
            return;
        }
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        RaycastHit hit;
        if (Physics.Raycast(ray, out hit))
        {
            Vector3 mouseDir = new Vector3(hit.point.x, transform.position.y, hit.point.z) - transform.position;
            transform.forward = mouseDir;
        }
    }

    #region Skills
    protected Coroutine _coSkill;
    public void NormalAttack()
    {
        Debug.Log("NormalAtt!");
        BaseController bc = Target.GetComponent<BaseController>();
        if (bc == null)
            return;
        bc.OnDamaged(gameObject, _stat.Att);
    }


    public void QSkill()
    {
        
    }

    public void WSkill()
    {
        
    }

    public void ESkill()
    {
        
    }

    public void RSkill()
    {
        
    }
    #endregion



    #region Override Update Method
    public override void UpdateIdle()
    {
        base.UpdateIdle();
        
    }

    public override void UpdateMoving()
    {
        base.UpdateMoving();
        if (_agent.destination == null || Vector3.Distance(_agent.destination, transform.position) <= 0.1f)
        {
            State = State.Idle;
            return;
        }

        if ((Target != null) && (Vector3.Distance(Target.transform.position, transform.position) <= _stat.Range))
        {
            _agent.ResetPath();
            State = State.Attack;
            return;
        }
        transform.rotation = Quaternion.Slerp(transform.rotation, Quaternion.LookRotation(_agent.destination - transform.position), 10.0f * Time.deltaTime);
    }

    public override void UpdateAttack()
    {
        base.UpdateAttack();
        Turn();
        if (Target == null)
            State = State.Idle;
        else
            _anim.Play("NORMAL_ATTACK");
    }

    public override void UpdateDead()
    {
        base.UpdateDead();
    }
    #endregion
}
