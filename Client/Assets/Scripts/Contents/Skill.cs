using UnityEngine;
using System.Collections;
using System;
using static Define;
public class Skill : MonoBehaviour
{
    private IEnumerator _coSkill;
    public Skill(IEnumerator coSkill)
    {
        _coSkill = coSkill;
    }

    public Coroutine UseSkill()
    {
        return StartCoroutine(_coSkill);
    }


}
