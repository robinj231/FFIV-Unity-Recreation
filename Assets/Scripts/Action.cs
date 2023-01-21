using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Data", menuName = "ScriptableObjects/Action", order = 3)]
public class Action : ScriptableObject
{
    public actions actionType;
    public elements elementType;
    public int power;
    public int castingTime;
    public float hitChance;
    public int mPCost;
    public int hPCost;
}
