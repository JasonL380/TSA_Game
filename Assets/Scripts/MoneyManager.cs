using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class MoneyManager : MonoBehaviour
{

    public int money;

    public TMP_Text mTMP;
    // Start is called before the first frame update
    void Start()
    {
        money = 20;
    }

    // Update is called once per frame
    void Update()
    {
        mTMP.text = "Money: " + money;
    }

    void addMoney(int value)
    {
        money += value;
    }

    void subMoney(int value)
    {
        money -= value;
    }
}
