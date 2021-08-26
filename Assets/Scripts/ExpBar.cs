using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ExpBar : MonoBehaviour
{
    private Image bar;
    public float fill = 1f;

    void Start()
    {
        bar = GetComponent<Image>();
    }

    void Update()
    {
        bar.fillAmount = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerMove>().exp / 100;
    }
}
