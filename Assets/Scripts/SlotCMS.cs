using System.Collections.Generic;
using UnityEngine;


public class SlotCMS : MonoBehaviour
{
    public GameObject cellPrefab;
    public List<Sprite> CellSprites;
    
    public List<SlotCellS> cells;
    public bool spin;
    private float startTime;
    private int numberCell;
    private Time time;
    private int creditsWin;
    private bool chekWin;
    public void LateUpdate()
    {
        if(spin)
        {
            for (int i = 0; i < cells.Count; i++)
            {
                cells[i].transform.localPosition = new Vector3(0, -((Time.time - startTime) * 4000 - (200 * (cells[i].numberCell))), 0);
              
            }
            if (cells[cells.Count - 1].transform.localPosition.y <= 0)
            {
                while (cells.Count > 3)
                {
                    DestroyCell(cells[0]);
                }
                ResetNumberCell();
                StopSpin();
            }
        }
        else
        {
            for (int i = 0; i < cells.Count; i++)
            {
                cells[i].transform.localPosition = new Vector3(0, (200 * (cells[i].numberCell - 2)), 0);
            }
        }


    }
    

    public void GoSpin(float _time, int _length)
    {
        
        spin = true;
        startTime = _time;
        while (numberCell < _length)
        {
            CreateCell(cells[cells.Count - 1].transform.position + Vector3.down * 160f);
        }
    }
    public void StopSpin()
    {
        spin = false;
    }

    public void CreateCell(Vector3 position)
    {
        GameObject cell = Instantiate(cellPrefab, position, Quaternion.identity, transform);
        int id = Random.Range(0, 56);
        int _id = 0;

        if (id <= 0) _id = 10;
        else if (id <= 1) _id = 9;
        else if (id <= 3) _id = 8;
        else if (id <= 6) _id = 7;
        else if (id <= 10) _id = 6;
        else if (id <= 15) _id = 5;
        else if (id <= 21) _id = 4;
        else if (id <= 28) _id = 3;
        else if (id <= 36) _id = 2;
        else if (id <= 55) _id = 1;

        cell.GetComponent<SlotCellS>().InitialisationCell(_id, numberCell, CellSprites[_id - 1]);
        cells.Add(cell.GetComponent<SlotCellS>());
        numberCell++;

    }

    public void StartCreateCell()
    {
        for (int i = 0; i < 3; i++)
        {
            CreateCell(new Vector3(0, (i * 200), 0));
        }
    }
    public void ResetNumberCell()
    {
        numberCell = 0;
        for (int i = 0; i < cells.Count; i++)
        {
            cells[i].GetComponent<SlotCellS>().numberCell = numberCell;
            numberCell++;
        }
    }
    public void DestroyCell(SlotCellS cell)
    {
        cells.Remove(cell);
        Destroy(cell.gameObject);
    }

}
