using UnityEngine;
using System.Collections;

public class GangBadge : CharacterSkill
{
    Animator _anim;
    GameObject _player;
    public GangBadge(Animator anim, GameObject player)
    {
        _anim = anim;
    }

    public override IEnumerator NormalAttack()
    {
        _anim.Play("NORMAL_ATTACK");
        yield return new WaitForSeconds(0.973f);
    }

    public override IEnumerator QSkill()
    {
        return base.QSkill();
    }

    public override IEnumerator WSkill()
    {
        return base.WSkill();
    }

    public override IEnumerator ESkill()
    {
        return base.ESkill();
    }

    public override IEnumerator RSkill()
    {
        return base.RSkill();
    }
}
