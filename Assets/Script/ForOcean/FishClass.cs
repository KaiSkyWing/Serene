using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class FishClass : MonoBehaviour
{
    protected int hp;
    protected int maxHp = 100;

    public Possesion possesion;

    
    /*public int Hp
    {
        get { return hp; }
        set { hp = Mathf.Clamp(value, 0, maxHp); } // 最大値を意識
    }*/

    public bool isAlive = true;

    public enum FishType
    {
        ClownFish,
        JerryFish,
        Shark,
        Crab,
        Squid,
    }

    public FishType fishType;

    public abstract void Move();

    [SerializeField] private BagButton bagButton;

    public void TakeDamage()
    {
        hp -= 5;
        if (hp <= 0)
        {
            Destroy(gameObject);
            Capture();
            bagButton.OnGetFish();
        }
    }

    public abstract void Capture();
}

