using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class DamageTextEffect : MonoBehaviour
{
    public int duration;

    int curFrame = 0;

    public float speed;

    private void Start()
    {
        GetComponent<Canvas>().worldCamera = Camera.main;
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if(curFrame < duration)
        {
            curFrame++;
            transform.position += (Vector3)Vector2.up * speed;
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
