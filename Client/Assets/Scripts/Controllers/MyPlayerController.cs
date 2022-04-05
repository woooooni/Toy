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

    int _mask = (1 << (int)Layer.Terrain) | (1 << (int)Layer.Enemy);
    void GetInput()
    {
        if (Input.GetMouseButton(1))
        {
            //if (State == State.Attack)
            //    return;
            
            RaycastHit hit;
            if (Physics.Raycast(Camera.main.ScreenPointToRay(Input.mousePosition), out hit, _mask))
            {
                if(hit.collider.gameObject.layer == ((int)Layer.Enemy))
                {
                    Debug.Log($"[Hit Info]\n[Hit Name] {hit.collider.gameObject.name}\n[Hit Layer] {hit.collider.gameObject.layer.ToString()}");
                    Target = hit.collider.gameObject;
                    SetDest(Target.gameObject.transform.position, _stat.Range);
                }

                else if(hit.collider.gameObject.layer == ((int)Layer.Terrain))
                {
                    Target = null;
                    SetDest(hit.point);
                }
            }

        }

        if (Input.GetKeyDown(KeyCode.Q))
        {
            
        }

        if (Input.GetKeyDown(KeyCode.W))
        {
            
        }

        if (Input.GetKeyDown(KeyCode.E))
        {
            
        }

        if (Input.GetKeyDown(KeyCode.R))
        {
            
        }
    }
}
