using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[CreateAssetMenu(fileName = "Data", menuName = "ScriptableObjects/FightingUnit", order = 1)]

public class FightingUnit : ScriptableObject
{
    public string displayName;
    public Sprite sprite;

    [Header("Slider Stats")]
    public int level;
    public int hp;
    public int currentHp;
    public int mp;
    public int currentMp;
    public int totalExp;
    public int expLastLevel;
    public int expToNext;

    [Header("Battle Stats")]
    public int attack;
    public float accuracy;
    public int defense;
    public float evasion;
    public int magicDefense;
    public float magicEvasion;
    public float critChance;
    public int critBonus;

    [Header("Character Stats")]
    public int strength;
    public int speed;
    public int stamina;
    public int intellect;
    public int spirit;

    [Header("Affinities")]
    public float[] elementalAffinity = new float[6];
    public bool[] statusImmunities = new bool[17];
    public float restorativeAffinity;
    public float drainOsmoseAffinity;

    public Action[] actions;
}