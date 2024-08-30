using UnityEngine;

public class SLManager : MonoBehaviour
{
    public SlotMGCS ms;
    public CheeseGS mgs;
    public SlotBS[] busters;
    public ScoreCS score;
    public Hotel hotel;
    public AudioC audioC;
    public bool tutorial1;
    public bool tutorial2;
    private const string HOTEL_LEVEL_KEY = "HotelLevel";
    private const string RESTAURANT_LEVEL_KEY = "RestaurantLevel";
    private const string CASINO_LEVEL_KEY = "CasinoLevel";
    private const string ROOM_LEVEL_KEY = "RoomLevel";
    public void Start()
    {
        Load();
        
    }

    public void Save()
    {
        for (int i = 0; i < ms.buster.Length; i++)
        {

            PlayerPrefs.SetInt("buster" + i, ms.buster[i]);
        }
        PlayerPrefs.SetInt("credits",ms.cheese);
        PlayerPrefs.SetInt("score", score.score);
        PlayerPrefs.SetInt("scorelvl", score.scoreLvl);
        PlayerPrefs.SetInt("scoreboost", score.scoreBoost);
        PlayerPrefs.SetInt("creditsboost", score.creditsBoost);

        PlayerPrefs.SetInt("lvl", score.lvl);
        PlayerPrefs.SetInt("maplvl", score.maplvl);
        PlayerPrefs.SetInt("youwinnum", score.youWin);

        PlayerPrefs.SetInt(HOTEL_LEVEL_KEY, hotel.hotelLevel);
        PlayerPrefs.SetInt(RESTAURANT_LEVEL_KEY, hotel.restaurantLevel);
        PlayerPrefs.SetInt(CASINO_LEVEL_KEY, hotel.casinoLevel);
        PlayerPrefs.SetInt(ROOM_LEVEL_KEY, hotel.roomLevel);

        if (tutorial1)
        {
            PlayerPrefs.SetInt("tutorial", 1);
        }
        else
        {
            PlayerPrefs.SetInt("tutorial", 0);
        }
        if (audioC.e.isOn == true) PlayerPrefs.SetInt("e", 1);
        else PlayerPrefs.SetInt("e", 0);
        if (audioC.m.isOn == true) PlayerPrefs.SetInt("m", 1);
        else PlayerPrefs.SetInt("m", 0);
        PlayerPrefs.Save();
        Debug.Log("Save");
    }

    public void Load()
    {
        for(int i =0; i<ms.buster.Length;i++)
        {
            ms.buster[i] = PlayerPrefs.GetInt("buster"+i,0);
            busters[i].CheckButtons();
            busters[i].BusterUpdate();
        }
        ms.cheese = PlayerPrefs.GetInt("credits", 1000);
        score.score = PlayerPrefs.GetInt("score", 0);
        score.scoreLvl = PlayerPrefs.GetInt("scorelvl", 0);
        score.scoreBoost = PlayerPrefs.GetInt("scoreboost", 3);
        score.creditsBoost = PlayerPrefs.GetInt("creditsboost", 3);

        score.lvl= PlayerPrefs.GetInt("lvl", 1);
        score.maplvl = PlayerPrefs.GetInt("maplvl", 1);
        score.youWin = PlayerPrefs.GetInt("youwinnum", 0);
        hotel.hotelLevel = PlayerPrefs.GetInt(HOTEL_LEVEL_KEY, 1);
        hotel.restaurantLevel = PlayerPrefs.GetInt(RESTAURANT_LEVEL_KEY, 0);
        hotel.casinoLevel = PlayerPrefs.GetInt(CASINO_LEVEL_KEY, 0);
        hotel.roomLevel = PlayerPrefs.GetInt(ROOM_LEVEL_KEY, 0); 
        
        
        if(PlayerPrefs.GetInt("e", 0) == 1)
        {
            audioC.e.isOn = true;
        }
        else
        {
            audioC.e.isOn = false;
        }
        if (PlayerPrefs.GetInt("m", 0) == 1)
        {
            audioC.m.isOn = true;
        }
        else
        {
            audioC.m.isOn = false;
        }


        if (PlayerPrefs.GetInt("tutorial", 0)==1)
        {
            tutorial1 = true;
        }
        else
        {
            tutorial1 = false;
        }
        score.UpdateScore();
        score.UpdateButtons();
        ms.StartSlot();
        hotel.UpdateButton();
    }
    public void OnApplicationPause(bool isPaused)
    {
        if (isPaused)
        {
            Save();
        }
    }

    public void OnApplicationQuit()
    {
        Save();
    }
    public void Exit()
    {
        Save();
        Application.Quit();
    }
}
