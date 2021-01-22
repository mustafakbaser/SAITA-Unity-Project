using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HudController : MonoBehaviour
{

    public Fighter player1;
    public Fighter player2;

    public Scrollbar leftBar;
    public Scrollbar rightBar;

    public BattleController battle;

    public Text timerText;

    void Update()
    {
        timerText.text = battle.roundTime.ToString();
        if(leftBar.size > player1.healthPercent){
            leftBar.size -= 0.01f;
        }
        if(rightBar.size > player2.healthPercent)
        {
            rightBar.size -= 0.01f;
        }
    }
}
