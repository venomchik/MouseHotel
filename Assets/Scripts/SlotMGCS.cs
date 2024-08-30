using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;


public class SlotMGCS : MonoBehaviour
{
    public SLManager sals;
    public WindowsCM wm;
    public Hotel hotel;
    public int cheese;
    public int bid;
    public int winCheese;
    public List<SlotCMS> slots;
    [SerializeField] public TMP_Text _cheese1;
    [SerializeField] public TMP_Text _cheese2;
    [SerializeField] public TMP_Text _cheese3;
    [SerializeField] public TMP_Text _cheese4;
    [SerializeField] public TMP_Text _cheese5;
    [SerializeField] public TMP_Text _cheese6;
    [SerializeField] public TMP_Text _bid;
    [SerializeField] public TMP_Text bigWinCheese;
    [SerializeField] public TMP_Text YouWinCheese;
    public Button spin;
    public Button plus;
    public Button minus;
    private bool endSpin=true;
    private bool cheeseWin;
    private bool bigCheeseWin;
    private int[,] lines = new int[5, 5]
    {
    { 1, 1, 1, 1, 1 },
    { 2, 2, 2, 2, 2 },
    { 0, 0, 0, 0, 0 },
    { 0, 0, 1, 2, 2 },
    { 2, 2, 1, 0, 0 }
    };
    public int[] buster = { 0, 0, 0, 0, 0, 0, 0, 0, 0, 0 };
    public void StartSlot()
    {
        for (int i = 0; i < 5; i++)
        {
            slots[i].StartCreateCell();
        }
        bid = 10;
        _bid.text = "" + bid;
        UpdateCheese(); 

    }

    public void Spin()
    {
        cheese -= bid;
        float startSpin = Time.time;
        for (int i = 0; i < 5; i++)
        {
            slots[i].GetComponent<SlotCMS>().GoSpin(startSpin, (10 * (2 + i)));
        }
        endSpin = false;
        spin.interactable = false;
        plus.interactable = false;
        minus.interactable = false;
        UpdateCheese();


    }
    public void FixedUpdate()
    {
        if (!endSpin)
        {
            bool allBoolMoveFalse = true;
            foreach (SlotCMS slotObj in slots)
            {
                
                
                    if (slotObj.spin)
                    { 
                        allBoolMoveFalse = false;
                        break;
                    }
                
            }
            if (allBoolMoveFalse)
            {
                Debug.Log("End");
                cheese += CheckWin();
                UpdateCheese();
                CheckButtons();
                endSpin = true;
            }
        }
    }
    public void CheckButtons()
    {
        if (bid > cheese) spin.interactable = false;
        else spin.interactable = true;
        if (bid >= 500)
        {
            plus.interactable = false;
        }
        else
        {
            plus.interactable = true;
        }
        if (bid <= 10)
        {
            minus.interactable = false;
        }
        else
        {
            minus.interactable = true;
        }

    }
    public void UpdateCheese()
    {
        _cheese1.text = cheese + "";
        _cheese2.text = cheese + "";
        _cheese3.text = cheese + "";
        _cheese4.text = cheese + "";
        _cheese5.text = cheese + "";
        _cheese6.text = cheese + "";

        for (int i = 0; i < sals.busters.Length; i++)
        {
            sals.busters[i].CheckButtons();
        }
    }
    public void PlusBid()
    {
        bid += 10;
        _bid.text = "" + bid;
        CheckButtons();
    }
    public void MinusBid()
    {
        bid -= 10;
        CheckButtons();
        _bid.text = "" + bid;
    }



    public List<SlotCellS> CheckLine(int lineIndex)
    {
        List<SlotCellS> cells = new List<SlotCellS>();
        for (int i = 0; i < 5; i++)
        {
            for (int j = 0; j < 3; j++)
            {
                if (lines[lineIndex , i] == slots[i].cells[j].numberCell)
                {
                    cells.Add(slots[i].cells[j]);
                }
            }
        }
        return cells;
    }
    public int CheckWin()
    {
        float winCheese = 0;

        for (int i = 0; i < slots.Count; i++)
        {
            List<SlotCellS> cells=CheckLine(i);
            winCheese += Mathf.RoundToInt(CheckSameIdObjects(cells,1)*(1f+hotel.casinoLevel/10f));
        }

        Debug.Log("Win: " + winCheese);
        if (winCheese > bid * 2)
        {
            bigWinCheese.text=winCheese+"";
            wm.BigWin();
        }
        else if (winCheese <= bid * 2&& winCheese>0)
        {
            YouWinCheese.text = winCheese + "";
            wm.YouWin();
        }
        return Mathf.RoundToInt(winCheese);
    }


    private float CheckSameIdObjects(List<SlotCellS> cells, int lineIndex)
    {
        Dictionary<int, int> idCounts = new Dictionary<int, int>();

        foreach (SlotCellS cell in cells)
        {
            if (idCounts.ContainsKey(cell.id))
            {
                idCounts[cell.id]++;
            }
            else
            {
                idCounts[cell.id] = 1;
            }
        }

        foreach (KeyValuePair<int, int> pair in idCounts)
        {
            int count = pair.Value;
            int id = pair.Key;

            if (count > 4)
            {
                Debug.Log("BigWin on line " + lineIndex + ", ID: " + id + ", кількість: " + count);
                float coef = id + buster[id] / 10 + 2;
                return  bid *coef/5 ;
            }
            else if (count > 3)
            {
                Debug.Log("MidWin on line " + lineIndex + ", ID: " + id + ", кількість: " + count);
                float coef = id + buster[id] / 10 + 1;
                return bid * coef/5;
            }
            else if (count > 2)
            {
                Debug.Log("Win on line " + lineIndex + ", ID: " + id + ", кількість: " + count);
                float coef = id + buster[id] / 10;
                return  bid * coef/5;
            }
        }

        return 0;
    }
}
