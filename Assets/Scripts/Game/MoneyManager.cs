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
    /// <summary>
    /// Add money to the current total
    /// </summary>
    /// <param name="value">The amount of money to add</param>
    public void AddMoney(int value)
    {
        money += value;
        mTMP.text = "Money: " + money;
    }
    
    /// <summary>
    /// Subtract money from the current total
    /// </summary>
    /// <param name="value">The amount of money that should be subtracted</param>
    /// <returns>A bool saying if money was able to be subtracted</returns>
    public bool SubMoney(int value)
    {
        if (value > money)
        {
            return false;
        }
        money -= value;
        mTMP.text = "Money: " + money;
        
        return true;
    }
}
