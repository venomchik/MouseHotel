using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class SlotBS : MonoBehaviour
{
    public SLManager sals;
    public SlotMGCS ms;
    public int price;
    public float buster;
    public int id;
    public Button button;
    public Color color1;
    public Color color2;
    [SerializeField] public TMP_Text _buster;
    [SerializeField] public TMP_Text _price;
    public bool slotBoosterChek;
    public float slotBoosterCoef;

    public void BusterUpdate()
    {
        _buster.text = "X" + ms.buster[id - 1]/10f;
        ms.UpdateCheese();
        for (int i = 0; i < sals.busters.Length; i++)
        {
            sals.busters[i].CheckButtons();
        }
    }

    public void LvlUp()
    {
        ms.buster[id - 1] += 1;
        ms.cheese -= price;
        BusterUpdate();
    }
    public void CheckButtons()
    {
        if (ms.cheese < price) 
        {
            button.interactable = false;
            button.gameObject.GetComponent<Image>().color = color2;

        }
        else
        {
            button.interactable = true;
            button.gameObject.GetComponent<Image>().color = color1;
        }
        _price.text = "" + price;
    }
}
