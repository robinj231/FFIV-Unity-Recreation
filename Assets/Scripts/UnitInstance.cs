using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UnitInstance : MonoBehaviour
{
    public FightingUnit statModule;
    public float aTBMeter;
    public bool charging;
    public float chargeMeter;
    public float chargeMult = 1;
    public QueuedAction chargeAction;
    public void UpdateATB()
    {
        if(!charging)
        {
            aTBMeter += (float)statModule.GetAgility() / 1650;
        }
        else
        {
            aTBMeter += (float)statModule.GetAgility() / 1650 / chargeMult;
        }
    }

    public void SetSprite()
    {
        GetComponent<SpriteRenderer>().sprite = statModule.sprite;
    }
}
