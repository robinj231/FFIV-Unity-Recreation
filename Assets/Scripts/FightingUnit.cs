using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[CreateAssetMenu(fileName = "Data", menuName = "ScriptableObjects/FightingUnit", order = 1)]

public class FightingUnit : ScriptableObject
{
    public string displayName;
    public Sprite sprite;

    [Header("HP/MP")]
    public int hp;
    public int currentHp;
    public int mp;
    public int currentMp;

    //
    // Battle stat functions
    //
    public virtual int GetAttack()
    {
        return 0;
    }

    public virtual float GetAccuracy()
    {
        return 0;
    }

    public virtual int GetAttackMult()
    {
        return 0;
    }

    public virtual int GetDefense()
    {
        return 0;
    }

    public virtual float GetEvasion()
    {
        return 0;
    }

    public virtual int GetDefenseMult()
    {
        return 0;
    }

    public virtual int GetMagicDef()
    {
        return 0;
    }

    public virtual float GetMagicEvade()
    {
        return 0;
    }

    public virtual int GetMgcDefMult()
    {
        return 0;
    }

    public virtual float GetCritChance()
    {
        return 0;
    }

    public virtual int GetCritBonus()
    {
        return 0;
    }

    public virtual float GetAgility()
    {
        return 0;
    }

    [Header("Affinities")]
    public float[] elementalAffinity = new float[6];
    public bool[] statusImmunities = new bool[17];
    public float restorativeAffinity;
    public float drainOsmoseAffinity;

    public Action[] actions;

    [Header("Experience")]
    public int level;
}