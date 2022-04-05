using UnityEngine;
using System.Collections;

public class MonsterController : BaseController
{
    protected override void Init()
    {
        base.Init();
    }

    protected override void UpdateController()
    {
        base.UpdateController();
    }

    public override void OnDamaged(GameObject attacker, int damage)
    {
        base.OnDamaged(attacker, damage);
        Debug.Log($"Name : {gameObject.name}, Damaged By : {attacker.name}, Damage : {damage}");
        _anim.Play("DAMAGED");
    }


    public override void UpdateIdle()
    {
        base.UpdateIdle();
    }

    public override void UpdateAttack()
    {
        base.UpdateAttack();
    }

    public override void UpdateMoving()
    {
        base.UpdateMoving();
    }

    public override void UpdateDead()
    {
        base.UpdateDead();
    }
}
