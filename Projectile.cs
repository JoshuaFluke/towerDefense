using System.Collections;
using System.Collections.Generic;
using UnityEngine;


//projectile types will & gives dropdown in the inspector
public enum proType
{
    rock,arrow,fireball
};

public class Projectile : MonoBehaviour {

    [SerializeField] private int attackStrength;
    [SerializeField] private proType projectileType;

    public int AttackStrength
    {
        get
        {
            return attackStrength;
        }
    }

    public proType ProjectileType
    {
        get
        {
            return projectileType;
        }
    }

}
