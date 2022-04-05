using UnityEngine;
using System.Collections;
using static Define;
public class MyPlayerController : PlayerController
{
    protected override void Init()
    {
        base.Init();
    }

    protected override void UpdateController()
    {
        base.UpdateController();
        GetInput();
    }

    void GetInput()
    {
        if (Input.GetMouseButton(1))
        {
            //if (State == State.Attack)
            //    return;
            RaycastHit hit;
            if (Physics.Raycast(Camera.main.ScreenPointToRay(Input.mousePosition), out hit))
            {
                BaseController bc = hit.transform.gameObject.GetComponent<BaseController>();
                if (bc != null)
                {
                    _target = bc.gameObject;
                    SetDest(_target.gameObject.transform.position, Range);
                }
                else
                {
                    _target = null;
                    SetDest(hit.point);
                    State = State.Move;
                }
            }

        }

        if (Input.GetKeyDown(KeyCode.Q))
        {
            if (_coSkill != null)
                return;
            _coSkill = StartCoroutine("QSkill");
        }

        if (Input.GetKeyDown(KeyCode.W))
        {
            if (_coSkill != null)
                return;
            _coSkill = StartCoroutine("QSkill");
        }

        if (Input.GetKeyDown(KeyCode.E))
        {
            if (_coSkill != null)
                return;
            _coSkill = StartCoroutine("QSkill");
        }

        if (Input.GetKeyDown(KeyCode.R))
        {
            if (_coSkill != null)
                return;
            _coSkill = StartCoroutine("QSkill");
        }
    }
}
