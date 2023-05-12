using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum AttackType { SLICE, STAB, HEAL }
public class AttackBase : MonoBehaviour
{
    public AttackType attackType ;
    public string type;
    public int damage;
    public int damageCritical;
    public int damageReduced;
    public int damageBlocked;
    public int damageMissed;
    public int heal;

    public void SetAttacks()
    {
        attackType = AttackType.SLICE;
        damage = 5;
        damageReduced = 3;
        damageBlocked = 2;
        damageMissed = 0;
    }
    public virtual int DamageOpponent()
    {
        //this method is meant to be overwritten
        return damage;
    }
}
