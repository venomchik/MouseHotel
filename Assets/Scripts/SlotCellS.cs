using UnityEngine;
using UnityEngine.UI;

public class SlotCellS : MonoBehaviour
{
    public int id;
    public int numberCell;
    public int numberWinCell;
    public void InitialisationCell(int _id,int _numberCell,Sprite sprite)
    {
        id = _id;
        numberCell = _numberCell;
        this.GetComponent<Image>().sprite = sprite;
    }

}
