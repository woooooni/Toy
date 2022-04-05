using UnityEngine;
using System.Collections;

public class CharacterSkill : MonoBehaviour
{
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
}