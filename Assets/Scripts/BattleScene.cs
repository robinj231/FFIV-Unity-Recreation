using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public struct QueuedAction
{
    public UnitInstance actor;
    public List<UnitInstance> targets;
    public Action action;
}

public class BattleScene : MonoBehaviour
{
    public FightingUnit[] enemyUnits = new FightingUnit[9];
    public PlayableUnit[] playableUnits = new PlayableUnit[14];

    public UnitInstance[] instances = new UnitInstance[14];
    public FightingUnit[] statModules = new FightingUnit[14];

    public int enemyNo = 0;
    public int playableNo = 0;

    public Queue<UnitInstance> actionableUnits = new Queue<UnitInstance>();

    public Queue<QueuedAction> actionQueue = new Queue<QueuedAction>();

    public int animationWait = 0;

    public GameObject damageEffectPrefab;

    public UnityEvent damageMove;

    public Action attack;
    public Action jump;
    public Action darkness;

    private void Awake()
    {
        for (int i = 0; i < playableUnits.Length; i++)
        {
            if (playableUnits[i] != null)
            {
                statModules[i] = instances[i].statModule = Instantiate(playableUnits[i]);
                playableNo++;
            }
            else
            {
                instances[i].gameObject.SetActive(false);
            }
        }

        for (int i = 0; i < enemyUnits.Length; i++)
        {
            if(enemyUnits[i] != null)
            {
                statModules[i+5] = instances[i+5].statModule = Instantiate(enemyUnits[i]);
                enemyNo++;
            }
            else
            {
                instances[i+5].gameObject.SetActive(false);
            }
        }
    }

    private void FixedUpdate()
    {
        if(animationWait == 0)
        {
            for (int i = 0; i < instances.Length; i++)
            {
                if (instances[i].isActiveAndEnabled)
                {
                    if (instances[i].aTBMeter < 1)
                    {
                        instances[i].UpdateATB();
                        if (instances[i].aTBMeter >= 1)
                        {
                            instances[i].aTBMeter = 1;

                            if (i < 5)
                            {
                                if(!instances[i].charging)
                                {
                                    actionableUnits.Enqueue(instances[i]);
                                }
                                else
                                {
                                    actionQueue.Enqueue(instances[i].chargeAction);
                                    instances[i].charging = false;
                                }
                            }
                            else
                            {
                                QueuedAction action = new QueuedAction();
                                action.actor = instances[i];
                                action.targets = new List<UnitInstance> { instances[0] };
                                action.action = statModules[i].actions[0];
                                actionQueue.Enqueue(action);
                            }
                        }
                    }
                }
            }

            if (actionQueue.Count > 0)
            {
                animationWait = 100;
                QueuedAction toPerform = actionQueue.Peek();
                toPerform.actor.GetComponent<SpriteRenderer>().color = Color.green;
                foreach(UnitInstance target in toPerform.targets)
                {
                    target.GetComponent<SpriteRenderer>().color = Color.red;
                    //Instantiate(damageEffectPrefab, target.transform.position, Quaternion.identity).GetComponent<DamageTextEffect>().SetText((toPerform.action.power + toPerform.actor.statModule.attack).ToString());
                }
            }
        }
        else
        {
            animationWait--;

            if(animationWait == 0)
            {
                QueuedAction toDequeue = actionQueue.Dequeue();
                toDequeue.actor.GetComponent<SpriteRenderer>().color = Color.white;
                toDequeue.actor.aTBMeter = 0;
                foreach (UnitInstance target in toDequeue.targets)
                {
                    target.GetComponent<SpriteRenderer>().color = Color.white;
                }
                ExecuteAction(toDequeue);
            }
        }
    }

    void ExecuteAction(QueuedAction action)
    {
        foreach (UnitInstance target in action.targets)
        {
            //target.statModule.currentHp -= action.action.power + action.actor.statModule.attack;
        }
        action.actor.statModule.currentMp -= action.action.mPCost;
        action.actor.statModule.currentHp -= action.action.hPCost;
    }

    public void SetAction(Action action, List<UnitInstance> targets)
    {
        QueuedAction newAction = new QueuedAction();
        newAction.actor = actionableUnits.Dequeue();
        newAction.targets = targets;
        newAction.action = action;

        if (action.castingTime > 0)
        {
            UnitInstance toCharge = newAction.actor;
            toCharge.charging = true;
            toCharge.aTBMeter = 0;
            toCharge.chargeMult = action.castingTime;
            toCharge.chargeAction = newAction;
        }
        else
        {
            actionQueue.Enqueue(newAction);
        }
    }
}
