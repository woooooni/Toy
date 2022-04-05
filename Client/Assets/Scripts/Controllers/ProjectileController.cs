using UnityEngine;
using System.Collections;
using static Define;
public class ProjectileController : BaseController
{
    protected override void Init()
    {
        base.Init();
        State = State.Move;
    }

    public override void UpdateIdle()
    {
        base.UpdateIdle();
    }

    public override void UpdateMoving()
    {
        transform.Translate(transform.forward * 20 * Time.deltaTime);
    }

    private void OnTriggerEnter(Collider other)
    {
        Debug.Log($"Name{other.name}");
        BaseController bc = other.GetComponent<BaseController>();
        if (bc == null)
            Debug.Log("못찾음");
        bc.OnDamaged(gameObject, damage: 10);
        Destroy(this.gameObject);
    }

    public override void OnDamaged(GameObject attacker, int damage)
    {
        
    }
}
