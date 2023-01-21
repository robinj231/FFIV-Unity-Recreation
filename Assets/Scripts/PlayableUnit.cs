using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Data", menuName = "ScriptableObjects/PlayableUnit", order = 2)]

public class PlayableUnit : FightingUnit
{
    [Header("Commands")]
    public commands[] commands = new commands[7];
}
