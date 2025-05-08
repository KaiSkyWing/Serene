using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CrabController : FishClass
{
    void Start()
    {
        hp = 10;
        maxHp = hp;
        fishType = FishType.Crab;
    }

    void Update()
    {
        Move();
    }

    public override void Move()
    {
        //
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.tag == "Bullet")
        {
            TakeDamage();
            Destroy(other.gameObject);
        }
    }

    public override void Capture()
    {
        possesion.CaptureFish(fishType);
    }
}
