using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class DamageTextEffect : MonoBehaviour
{
    public int duration;

    int curFrame = 0;

    // Update is called once per frame
    void FixedUpdate()
    {
        if(curFrame < duration)
        {
            curFrame++;
        }
        else
        {
            Destroy(gameObject);
        }
    }

    public void SetText(string text)
    {
        GetComponentInChildren<TMP_Text>().text = text;
    }
}
