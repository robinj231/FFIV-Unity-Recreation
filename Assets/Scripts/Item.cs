using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[CreateAssetMenu(fileName = "Data", menuName = "ScriptableObjects/Item", order = 1)]

public class Item : ScriptableObject
{
    public string displayName;
    public Sprite sprite;

    public int attack;
    public float accuracy;

    [Header("Spell")]
    public int spellCast;
    public int spellPower;

    [Header("Equipability")]
    public bool darkCecil;
    public bool kain;
    public bool rydia;
    public bool tellah;
    public bool edward;
    public bool rosa;
    public bool yang;
    public bool palom;
    public bool porom;
    public bool cecil;
    public bool cid;
    public bool edge;
    public bool fusoya;

    [Header("Element/Status")]
    public elements element;
    public int status;

    [Header("Stat Mods")]
    public int strength;
    public int speed;
    public int stamina;
    public int intellect;
    public int spirit;

    [Header("Type")]
    public bool twoHanded;
    public bool arrow;
    public bool bow;
    public bool shield;
    public bool metallic;

    [Header("Flags")]
    public bool noCritical;
    public bool hammer;
    public bool litArrow;
    public bool noBackRowPenalty;
    public bool canThrow;

    [Header("Race Advantage: Dragon, Mech, Reptile, Spirit, Giant, Flan, Mage, Undead")]
    public bool[] raceAdvantage = new bool[8];
}
