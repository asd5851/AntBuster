using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : SingleTone<GameManager>
{
    // Start is called before the first frame update
    static int score = 0;
    static int money = 300;
    static int lv = 1;
    private GameObject scoreTxtObj = default;
    private GameObject MoneyTxtObj = default;
    private GameObject stageTxtObj = default;

    void Awake()
    {
        GameObject uiObjs = GFunc.GetRootObj("GameObjs");
        scoreTxtObj = uiObjs.FindChildObj("ScoreTxt");
        stageTxtObj = uiObjs.FindChildObj("LvTxt");
        MoneyTxtObj = uiObjs.FindChildObj("MoneyTxt");
    }
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        //GetScore();
    }

    //! 점수를 추가한다.
    public void GetScore()
    {
        score += 100;
        scoreTxtObj.SetTmpText($"{score}");
    }

    //! 돈을 추가한다.
    public void GetMoney()
    {
        money += 10;
        MoneyTxtObj.SetTmpText($"{money}");
    }
    public void SpendMoney()
    {
        money -= 45;
        MoneyTxtObj.SetTmpText($"{money}");
    }
}
