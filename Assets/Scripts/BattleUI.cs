using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;
//using UnityEditor.Events;

public class BattleUI : MonoBehaviour
{
    public BattleScene battleScene;

    public TMP_Text[] unitUINames = new TMP_Text[14];
    public TMP_Text[] unitUIHealth = new TMP_Text[5];
    public Slider[] unitUIATBMeter = new Slider[14];

    public GameObject[] enemyNames;

    public GameObject commandPanel;
    public GameObject[] commandButtons;

    public bool targetSelecting;

    public Action chosenAction;

    private void Start()
    {
        SetUIValues();
    }

    private void SetUIValues()
    {
        for (int i = 0; i < 14; i++)
        {
            if (battleScene.instances[i].isActiveAndEnabled)
            {
                battleScene.instances[i].SetSprite();
                unitUINames[i].text = battleScene.statModules[i].displayName;
                UpdateSlider(unitUIATBMeter[i], battleScene.instances[i].aTBMeter, battleScene.instances[i].charging);
                unitUIHealth[i].text = UpdateHealth(battleScene.statModules[i]);
            }
            else
            {
                unitUINames[i].gameObject.SetActive(false);
                unitUIATBMeter[i].gameObject.SetActive(false);
                unitUIHealth[i].gameObject.SetActive(false);
            }
        }
    }

    private void Update()
    {
        if (targetSelecting)
        {
            if (Input.GetMouseButtonDown(0))
            {
                Vector2 castPoint = Camera.main.ScreenToWorldPoint(Input.mousePosition);
                RaycastHit2D getTarget = Physics2D.Raycast(castPoint, Vector2.zero, 0);
                if (getTarget)
                {
                    targetSelecting = false;

                    if(chosenAction.actionType == actions.EffectAll)
                    {
                        List<UnitInstance> targets = new List<UnitInstance>();

                        if (getTarget.collider.GetComponent<UnitInstance>().statModule is PlayableUnit)
                        {
                            foreach(UnitInstance unit in battleScene.instances)
                            {
                                if(unit.isActiveAndEnabled && unit.statModule is PlayableUnit)
                                {
                                    targets.Add(unit);
                                }
                            }
                        }
                        else
                        {
                            foreach(UnitInstance unit in battleScene.instances)
                            {
                                if (unit.isActiveAndEnabled && unit.statModule is not PlayableUnit)
                                {
                                    targets.Add(unit);
                                }
                            }
                        }

                        battleScene.SetAction(chosenAction, targets);
                    }
                    else
                    {
                        battleScene.SetAction(chosenAction, new List<UnitInstance> { getTarget.collider.GetComponent<UnitInstance>() });
                    }
                }
            }
        }
    }

    private void FixedUpdate()
    {
        SetUIValues();

        UpdateCommands();
    }

    private string UpdateHealth(FightingUnit unit)
    {
        return unit.currentHp + " / " + unit.hp;
    }

    private void UpdateSlider(Slider aTBMeter, float currentVal, bool isCharging)
    {
        aTBMeter.value = currentVal;

        if(isCharging)
        {
            aTBMeter.GetComponentsInChildren<Image>()[1].color = Color.yellow;
        }
        else
        {
            aTBMeter.GetComponentsInChildren<Image>()[1].color = Color.white;
        }
    }

    private void UpdateCommands()
    {
        bool setToActive = (battleScene.actionableUnits.Count > 0 && !targetSelecting);
        commandPanel.SetActive(setToActive);
        if(setToActive)
        {
            PlayableUnit statModule = (PlayableUnit)battleScene.actionableUnits.Peek().statModule;
            for(int iter = 0; iter < 7; iter++)
            {
                if(statModule.commands[iter] != commands.None)
                {
                    commandButtons[iter].gameObject.SetActive(true);
                    commandButtons[iter].GetComponentInChildren<TMP_Text>().text = statModule.commands[iter].ToString();
                    commands commandType = statModule.commands[iter];
                    commandButtons[iter].GetComponent<Button>().onClick.RemoveAllListeners();
                    commandButtons[iter].GetComponent<Button>().onClick.AddListener(delegate { CommandButton(commandType); });
                }
                else
                {
                    commandButtons[iter].SetActive(false);
                }
            }
        }
    }

    void CommandButton(commands commandType)
    {
        if(commandType == commands.Attack)
        {
            targetSelecting = true;
            chosenAction = battleScene.attack;
        }
        else if(commandType == commands.Jump)
        {
            targetSelecting = true;
            chosenAction = battleScene.jump;
        }
        else if(commandType == commands.Darkness)
        {
            targetSelecting = true;
            chosenAction = battleScene.darkness;
        }
    }
}
