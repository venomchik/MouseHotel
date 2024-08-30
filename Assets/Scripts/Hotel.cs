using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class Hotel : MonoBehaviour
{
    private const int MAX_LEVEL = 99;
    public int hotelLevel = 1;
    public int restaurantLevel = 0;
    public int casinoLevel = 0;
    public int roomLevel = 0;
    public SlotMGCS gms;

    [SerializeField] public TMP_Text lvlHotel;
    [SerializeField] public TMP_Text lvlRestaurant;
    [SerializeField] public TMP_Text lvlCasino;
    [SerializeField] public TMP_Text lvlRooms;
    [SerializeField] public TMP_Text priceHotel;
    [SerializeField] public TMP_Text priceRestaurant;
    [SerializeField] public TMP_Text priceCasino;
    [SerializeField] public TMP_Text priceRooms;

    public Button upHotel;
    public Button upRestaurant;
    public Button upCasino;
    public Button upRooms;

    public void UpdateButton()
    {
        priceHotel.text = (100 + 150 * hotelLevel).ToString();
        priceRestaurant.text = (100 + 100 * restaurantLevel).ToString();
        priceCasino.text = (100 + 100 * casinoLevel).ToString();
        priceRooms.text = (100 + 100 * roomLevel).ToString();

        CheckButtons();
    }

    public void CheckButtons()
    {
        int maxHotelLevel = Mathf.Min(hotelLevel, 99);
        upHotel.interactable = gms.cheese >= (100 + 150 * hotelLevel) && hotelLevel < 99;
        upRestaurant.interactable = hotelLevel > 0 && gms.cheese >= (100 + 100 * restaurantLevel) && restaurantLevel < maxHotelLevel;
        upCasino.interactable = hotelLevel > 0 && gms.cheese >= (100 + 100 * casinoLevel) && casinoLevel < maxHotelLevel;
        upRooms.interactable = hotelLevel > 0 && gms.cheese >= (100 + 100 * roomLevel) && roomLevel < maxHotelLevel;
        UpdateLevelsText();
    }

    public void UpgradeHotel()
    {
        if (hotelLevel < MAX_LEVEL && gms.cheese >= 100 + 150 * hotelLevel)
        {
            gms.cheese -= 100 + 150 * hotelLevel;
            hotelLevel++;
            Debug.Log("Hotel upgraded to level " + hotelLevel);
            UpdateButton();
            gms.UpdateCheese();
        }
        else
        {
            Debug.Log(hotelLevel >= MAX_LEVEL ? "Hotel is already at maximum level!" : "Not enough credits to upgrade hotel!");
        }
    }

    public void UpgradeRestaurant()
    {
        if (hotelLevel > 0 && restaurantLevel < MAX_LEVEL && gms.cheese >= 100 + 100 * restaurantLevel)
        {
            gms.cheese -= 100 + 100 * restaurantLevel;
            restaurantLevel++;
            Debug.Log("Restaurant upgraded to level " + restaurantLevel);
            UpdateButton();
            gms.UpdateCheese();
        }
        else
        {
            Debug.Log(restaurantLevel >= MAX_LEVEL ? "Restaurant is already at maximum level!" : "Not enough credits to upgrade restaurant or upgrade the hotel first!");
        }
    }

    public void UpgradeCasino()
    {
        if (hotelLevel > 0 && casinoLevel < MAX_LEVEL && gms.cheese >= 100 + 100 * casinoLevel)
        {
            gms.cheese -= 100 + 100 * casinoLevel;
            casinoLevel++;
            Debug.Log("Casino upgraded to level " + casinoLevel);
            UpdateButton();
            gms.UpdateCheese();
        }
        else
        {
            Debug.Log(casinoLevel >= MAX_LEVEL ? "Casino is already at maximum level!" : "Not enough credits to upgrade casino or upgrade the hotel first!");
        }
    }

    public void UpgradeRoom()
    {
        if (hotelLevel > 0 && roomLevel < MAX_LEVEL && gms.cheese >= 100 + 100 * roomLevel)
        {
            gms.cheese -= 100 + 100 * roomLevel;
            roomLevel++;
            Debug.Log("Room upgraded to level " + roomLevel);
            UpdateButton();
            gms.UpdateCheese();
        }
        else
        {
            Debug.Log(roomLevel >= MAX_LEVEL ? "Room is already at maximum level!" : "Not enough credits to upgrade rooms or upgrade the hotel first!");
        }
    }

    private void UpdateLevelsText()
    {
        lvlHotel.text = hotelLevel >= MAX_LEVEL ? "MAX" : "Lvl: " + hotelLevel;
        lvlRestaurant.text = restaurantLevel >= MAX_LEVEL ? "MAX" : "Lvl: " + restaurantLevel;
        lvlCasino.text = casinoLevel >= MAX_LEVEL ? "MAX" : "Lvl: " + casinoLevel;
        lvlRooms.text = roomLevel >= MAX_LEVEL ? "MAX" : "Lvl: " + roomLevel;
    }
}
