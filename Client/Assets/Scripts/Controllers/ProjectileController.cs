using UnityEngine;
using System.Collections;
using static Define;
public class ProjectileController : BaseController
{
    int power = 10;
    protected override void Init()
    {
        base.Init();
        Speed = 20;
        State = State.Move;
    }

    public override void UpdateIdle()
    {
        base.UpdateIdle();
    }

    public override void UpdateMoving()
    {
        transform.Translate(transform.forward * Speed * Time.deltaTime);
    }

    private void OnTriggerEnter(Collider other)
    {
        Debug.Log($"Name{other.name}");
        BaseController bc = other.GetComponent<BaseController>();
        if (bc == null)
            Debug.Log("못찾음");
        bc.OnDamaged(gameObject, damage: power);
        Destroy(this.gameObject);
    }
}
