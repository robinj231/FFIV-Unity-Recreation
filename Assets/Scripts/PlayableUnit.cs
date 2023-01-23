using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Data", menuName = "ScriptableObjects/PlayableUnit", order = 2)]

public class PlayableUnit : FightingUnit
{
    [Header("Experience")]
    public int totalExp;
    public int expLastLevel;
    public int expToNext;

    [Header("Commands")]
    public commands[] commands = new commands[7];

    [Header("Character Stats")]
    public int strength;
    public int agility;
    public int stamina;
    public int intellect;
    public int spirit;

    [Header("Handedness")]
    public handedness handedness;

    [Header("Equipment")]
    public Item rightHand;
    public Item leftHand;
    public Item helmet;
    public Item armor;
    public Item gloves;

    [Header("Flags")]
    public bool isYang;

    public override int GetAttack()
    {
        if(!isYang)
        {
            if(handedness != handedness.Both)
            {
                int wpnAttack = 0;
                if (handedness == handedness.Left)
                {
                    if(leftHand != null)
                    {
                        wpnAttack = leftHand.attack;
                    }
                }
                else if(handedness == handedness.Right)
                {
                    if (rightHand != null)
                    {
                        wpnAttack = rightHand.attack;
                    }
                }

                return wpnAttack + strength / 4 + level / 4;
            }
            else
            {
                if(leftHand != null && rightHand != null)
                {
                    return leftHand.attack + rightHand.attack + 2 * (strength / 4 + level / 4);
                }
                else if (leftHand != null)
                {
                    return leftHand.attack;
                }
                else if (rightHand != null)
                {
                    return rightHand.attack;
                }
                else
                {
                    return strength / 4 + level / 4;
                }
            }
        }
        else
        {
            // special formula only used for Yang
            return 2 * (level + 1) + strength / 4;
        }
    }
    public override float GetAccuracy()
    {
        float wpnAccuracy = .5f;

        if(handedness != handedness.Both)
        {
            if (handedness == handedness.Left)
            {
                if (leftHand != null)
                {
                    wpnAccuracy = leftHand.accuracy;
                }
            }
            else if (handedness == handedness.Right)
            {
                if (rightHand != null)
                {
                    wpnAccuracy = rightHand.accuracy;
                }
            }
        }
        else
        {
            if (leftHand != null && rightHand != null)
            {
                wpnAccuracy = (leftHand.accuracy + rightHand.accuracy) / 2;
            }
            else if (leftHand != null)
            {
                wpnAccuracy = leftHand.accuracy;
            }
            else if (rightHand != null)
            {
                wpnAccuracy = rightHand.accuracy;
            }
        }

        return wpnAccuracy + (float)level / 400;
    }

    public override int GetAttackMult()
    {
        return strength / 8 + agility / 16 + 1;
    }

    public override int GetDefense()
    {
        int equipDefense = 0;
        //if(leftHand != null) equipDefense += leftHand
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
