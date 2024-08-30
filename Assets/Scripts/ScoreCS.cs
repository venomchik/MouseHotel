using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class ScoreCS : MonoBehaviour
{
    public List<TMP_Text> texts;
    public List<TMP_Text> textsLvl;
    public TMP_Text SBNumber;
    public TMP_Text CBNumber;
    public int score;
    public int scoreLvl;
    public int scoreBoost;
    public int creditsBoost;
    public bool activateScoreBoost;
    public bool activateCreditsBoost;
    public Button activateSB;
    public Button activateCB;
    public Slider slider;

    public int lvl;
    public int maplvl;
    public bool twoCell;
    public MDB maps;
    public int[,] map;
    public int youWin;
    public WindowsCM windows;
    public GameObject YouWin;

    public GameObject map5x5;
    public GameObject map6x6;
    public GameObject map7x7;
    public GameObject map8x8;

    public int selectedMap=1;



    public void UpdateScore()
    {
        foreach(TMP_Text text in texts)
        {
            text.text = score+"";
        }
    }
    public void UpdateLvl()
    {
        foreach (TMP_Text text in textsLvl)
        {
            text.text = lvl + "";
        }
    }

    public void ActivateSB()
    {
        activateSB.interactable = false;
        activateScoreBoost = true;
        scoreBoost--;
        SBNumber.text = "" + scoreBoost;
    }
    public void ActivateCB()
    {
        activateCB.interactable = false;
        activateCreditsBoost = true;
        creditsBoost--;
        CBNumber.text = "" + creditsBoost;
    }
    public void Deactivate()
    {
        activateSB.interactable = true;
        activateCB.interactable = true;
        activateScoreBoost = false;
        activateCreditsBoost = false;
    }
    public void AddBoost()
    {
        if(scoreLvl>=100)
        {
            scoreLvl -=100;
            scoreBoost++;
            creditsBoost++;
            
        }
        slider.value = scoreLvl;
        Deactivate();
        UpdateButtons();

    }
    public void UpdateButtons()
    {
        SBNumber.text = "" + scoreBoost;
        CBNumber.text = "" + creditsBoost;
        if(scoreBoost<=0)
        {
            activateSB.interactable = false;
        }
        else { activateSB.interactable = true; }
        if(creditsBoost<=0)
        {
            activateCB.interactable = false;
        }
        else { activateCB.interactable = true; }
        slider.value = scoreLvl;
    }

    public void StartPlay()
    {
        if(selectedMap==1)
        {
            Start5x5Game();
        }
        else if(selectedMap==2)
        {
            Start6x6Game();
        }
        else if(selectedMap==3)
        {
            Start7x7Game();
        }
        else if(selectedMap==4)
        {
            Start8x8Game();
        }
    }

    public void Start5x5Game()
    {
        maplvl = Random.Range(1, 6); 
        map = maps.GetMap5x5(maplvl);
        map5x5.GetComponent<CheeseGS>().GameStart();
        windows.MiniGame5x5();
        map6x6.SetActive(false);
        map7x7.SetActive(false);
        map8x8.SetActive(false);
        selectedMap = 1;
    }

    public void Start6x6Game()
    {
        maplvl = Random.Range(1, 6);
        map = maps.GetMap6x6(maplvl);
        map6x6.GetComponent<CheeseGS>().GameStart();
        windows.MiniGame6x6();
        map5x5.SetActive(false);
        map7x7.SetActive(false);
        map8x8.SetActive(false);
        selectedMap = 2;
    }

    public void Start7x7Game()
    {
        maplvl = Random.Range(1, 6);
        map = maps.GetMap7x7(maplvl);
        map7x7.GetComponent<CheeseGS>().GameStart();
        windows.MiniGame7x7();
        map5x5.SetActive(false);
        map6x6.SetActive(false);
        map8x8.SetActive(false);
        selectedMap = 3;
    }

    public void Start8x8Game()
    {
        maplvl = Random.Range(1, 6);
        map = maps.GetMap8x8(maplvl);
        map8x8.GetComponent<CheeseGS>().GameStart();
        windows.MiniGame8x8();
        map5x5.SetActive(false);
        map6x6.SetActive(false);
        map7x7.SetActive(false);
        selectedMap = 4;
    }
    public void OpenYouWin()
    {
        YouWin.SetActive(true);
    }
    public void CloseYouWin()
    {
        YouWin.SetActive(false);
    }
}
