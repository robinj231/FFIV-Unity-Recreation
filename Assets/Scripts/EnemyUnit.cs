using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyUnit : FightingUnit
{
    [Header("Battle Stats")]
    public int attack;
    public float accuracy;
    public int attackMult;
    public int defense;
    public float evasion;
    public int defMult;
    public int magicDefense;
    public float magicEvasion;
    public int mgcDefMult;
    public float critChance;
    public int critBonus;

    [Header("Agility")]
    public int minAgility;
    public int maxAgility;
    public int agilityMod;

    public float agility;

    [Header("Races: Dragon, Mech, Reptile, Spirit, Giant, Flan, Mage, Undead")]
    public bool[] race = new bool[8];

    [Header("Flags")]
    public bool boss;
    public bool fiend;

    public void setAgility()
    {
        agility = Random.Range(minAgility, maxAgility) * agilityMod;
    }

    public override int GetAttack()
    {
        return attack;
    }
    public override float GetAccuracy()
    {
        return accuracy;
    }

    public override int GetAttackMult()
    {
        return attackMult;
    }

    public override int GetDefense()
    {
        return defense;
    }

    public override float GetEvasion()
    {
        return evasion;
    }

    public override int GetDefenseMult()
    {
        return defMult;
    }

    public override int GetMagicDef()
    {
        return magicDefense;
    }

    public override float GetMagicEvade()
    {
        return magicEvasion;
    }

    public override int GetMgcDefMult()
    {
        return mgcDefMult;
    }

    public override float GetCritChance()
    {
        return critChance;
    }

    public override int GetCritBonus()
    {
        return critBonus;
    }

    public override float GetAgility()
    {
        return agility;
    }
}
