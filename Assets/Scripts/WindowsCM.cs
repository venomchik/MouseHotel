using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WindowsCM : MonoBehaviour
{
    public SLManager sals;
    public GameObject MenuWindow;
    public GameObject SlotsWindow;
    public GameObject SettingsWindow;
    public GameObject MiniGameWindow5x5;
    public GameObject MiniGameWindow6x6;
    public GameObject MiniGameWindow7x7;
    public GameObject MiniGameWindow8x8;
    public GameObject BigWinWindow;
    public GameObject YouWinWindow;
    public GameObject LvlWindow;
    public GameObject InformationWindow1;
    public GameObject InformationWindow2;
    public GameObject EnterLvlWindow;
    public GameObject BoostersWindow;
    public GameObject HotelWindow;


    public void Start()
    {
        Menu();        
    }
    public void Menu()
    {
        MenuWindow.SetActive(true);
        SlotsWindow.SetActive(false);
        SettingsWindow.SetActive(false);
        MiniGameWindow5x5.SetActive(false);
        MiniGameWindow6x6.SetActive(false);
        MiniGameWindow7x7.SetActive(false);
        MiniGameWindow8x8.SetActive(false);
        BigWinWindow.SetActive(false);
        LvlWindow.SetActive(false);
        InformationWindow1.SetActive(false);
    }
    public void Slots()
    {
        MenuWindow.SetActive(false);
        SlotsWindow.SetActive(true);
        SettingsWindow.SetActive(false);
        MiniGameWindow5x5.SetActive(false);
        MiniGameWindow6x6.SetActive(false);
        MiniGameWindow7x7.SetActive(false);
        MiniGameWindow8x8.SetActive(false);
        BigWinWindow.SetActive(false);
        YouWinWindow.SetActive(false);
        LvlWindow.SetActive(false);
        InformationWindow2.SetActive(false);
        //if (sals.tutorial2 == true) InformationWindow2.SetActive(false);
        //else
        //{
        //    InformationWindow2.SetActive(true);
        //    sals.tutorial2 = true;
        //}
    }
    public void EnterLvl()
    {
        MenuWindow.SetActive(false);
        SlotsWindow.SetActive(false);
        SettingsWindow.SetActive(false);
        MiniGameWindow6x6.SetActive(false);
        BigWinWindow.SetActive(false);
        YouWinWindow.SetActive(false);
        LvlWindow.SetActive(false);
        InformationWindow2.SetActive(false);
        EnterLvlWindow.SetActive(true);
    }
    public void Settings()
    {
        MenuWindow.SetActive(true);
        SlotsWindow.SetActive(false);
        SettingsWindow.SetActive(true);
        MiniGameWindow6x6.SetActive(false);
        BigWinWindow.SetActive(false);
        LvlWindow.SetActive(false);
        InformationWindow1.SetActive(false);
    }
    public void MiniGame5x5()
    {
        MenuWindow.SetActive(false);
        SlotsWindow.SetActive(false);
        SettingsWindow.SetActive(false);
        MiniGameWindow5x5.SetActive(true);
        BigWinWindow.SetActive(false);
        LvlWindow.SetActive(false);
        EnterLvlWindow.SetActive(false);
        if (sals.tutorial1 == true) InformationWindow1.SetActive(false);
        else
        {
            InformationWindow1.SetActive(true);
            sals.tutorial1 = true;
        }
    }
    public void MiniGame6x6()
    {
        MenuWindow.SetActive(false);
        SlotsWindow.SetActive(false);
        SettingsWindow.SetActive(false);
        MiniGameWindow6x6.SetActive(true);
        BigWinWindow.SetActive(false);
        LvlWindow.SetActive(false);
        EnterLvlWindow.SetActive(false);
        if (sals.tutorial1 == true) InformationWindow1.SetActive(false);
        else
        {
            InformationWindow1.SetActive(true);
            sals.tutorial1 = true;
        }
    }
    public void MiniGame7x7()
    {
        MenuWindow.SetActive(false);
        SlotsWindow.SetActive(false);
        SettingsWindow.SetActive(false);
        MiniGameWindow7x7.SetActive(true);
        BigWinWindow.SetActive(false);
        LvlWindow.SetActive(false);
        EnterLvlWindow.SetActive(false);
        if (sals.tutorial1 == true) InformationWindow1.SetActive(false);
        else
        {
            InformationWindow1.SetActive(true);
            sals.tutorial1 = true;
        }
    }
    public void MiniGame8x8()
    {
        MenuWindow.SetActive(false);
        SlotsWindow.SetActive(false);
        SettingsWindow.SetActive(false);
        MiniGameWindow8x8.SetActive(true);
        BigWinWindow.SetActive(false);
        LvlWindow.SetActive(false);
        EnterLvlWindow.SetActive(false);
        if (sals.tutorial1 == true) InformationWindow1.SetActive(false);
        else
        {
            InformationWindow1.SetActive(true);
            sals.tutorial1 = true;
        }
    }
    public void BigWin()
    {
        MenuWindow.SetActive(false);
        SlotsWindow.SetActive(true);
        SettingsWindow.SetActive(false);
        MiniGameWindow6x6.SetActive(false);
        BigWinWindow.SetActive(true);
        LvlWindow.SetActive(false);
        InformationWindow1.SetActive(false);
    }
    public void YouWin()
    {
        MenuWindow.SetActive(false);
        SlotsWindow.SetActive(true);
        SettingsWindow.SetActive(false);
        MiniGameWindow6x6.SetActive(false);
        YouWinWindow.SetActive(true);
        LvlWindow.SetActive(false);
        InformationWindow1.SetActive(false);
    }
    public void Lvl()
    {
        MenuWindow.SetActive(false);
        SlotsWindow.SetActive(true);
        SettingsWindow.SetActive(false);
        MiniGameWindow6x6.SetActive(false);
        BigWinWindow.SetActive(false);
        LvlWindow.SetActive(true);
        InformationWindow1.SetActive(false);
    }
    public void Information1()
    {
        InformationWindow1.SetActive(true);
    }
    public void Information1Close()
    {
        InformationWindow1.SetActive(false);
    }
    public void Boosters()
    {
        BoostersWindow.SetActive(true);
    }
    public void BoostersClose()
    {
        BoostersWindow.SetActive(false);
    }
    public void Information2()
    {
        MenuWindow.SetActive(false);
        SlotsWindow.SetActive(true);
        SettingsWindow.SetActive(false);
        MiniGameWindow6x6.SetActive(false);
        BigWinWindow.SetActive(false);
        LvlWindow.SetActive(false);
        InformationWindow2.SetActive(true);
    }

    public void HotelOpen()
    {
        HotelWindow.SetActive(true);
    }
    public void HotelClose()
    {
        HotelWindow.SetActive(false);
    }
}
