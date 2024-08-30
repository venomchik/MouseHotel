using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class CheeseGS : MonoBehaviour
{
    public GridLayoutGroup mainGridLayoutGroup; 
    public GridLayoutGroup backGridLayoutGroup; 

    public int gridSize = 6; 
    public ScoreCS score;
    public int winScore;
    public int winCheese;
    [SerializeField] public TMP_Text _score;
    private int[,] map; 
    private Image[,] cells;
    private Image[,] backCells; 

    public MDB maps;
    public SlotMGCS mp;
    public Hotel hotel;
    public GameObject YouWin;
    public GameObject arrows;
    public GameObject upA;
    public GameObject rightA;
    public GameObject downA;
    public GameObject leftA;
    public Sprite[] MouseTrap;
    public Sprite mouse;
    public Sprite cell;
    public Sprite tile;
    public Sprite cheeseCell;
    public Sprite exitCell;

    public Vector2Int emptyCellPosition; 
    public Vector2Int goldCell1;
    public Vector2Int goldCell2;

    public Color emptyCellColor = new Color(0.5f, 0.5f, 0.5f, 0.5f); 


    public Color goldCellColor = Color.yellow; 
    private bool first = false;

    public void Start()
    {
        
    }
    public void GameStart()
    {


        InitializeMap(score.map);
        


        
        InitializeCells();


        ShowEmptyCell();
        UpdateGrid();
        ShowGoldCell();
        EmptyCellRender();
        ShowWinCell();
        if(first)
        {
            ArrowsTransform();
        }
        CheckArrows();
        first = true;
    }

    void InitializeMap(int[,] initialMap)
    {

        int rows = initialMap.GetLength(0);
        int cols = initialMap.GetLength(1);


        map = new int[rows, cols];


        for (int i = 0; i < rows; i++)
        {
            for (int j = 0; j < cols; j++)
            {
                map[i, j] = initialMap[i, j];
            }
        }
    }

    void InitializeCells()
    {

        cells = new Image[gridSize, gridSize];
        backCells = new Image[gridSize, gridSize];

        Image[] mainChildImages = mainGridLayoutGroup.GetComponentsInChildren<Image>();

        Image[] backChildImages = backGridLayoutGroup.GetComponentsInChildren<Image>();


        int index = 0;
        for (int i = 0; i < gridSize; i++)
        {
            for (int j = 0; j < gridSize; j++)
            {
                cells[i, j] = mainChildImages[index];
                backCells[i, j] = backChildImages[index];
                index++;
            }
        }
    }

    void ShowEmptyCell()
    {
        emptyCellPosition = new Vector2Int(0, 0);
        cells[emptyCellPosition.x, emptyCellPosition.y].sprite = mouse;
    }
    void ShowGoldCell()
    {

        int randomRow = Random.Range(0, gridSize);
        int randomCol = Random.Range(0, gridSize);

 
        while (map[randomRow, randomCol] == 1 || IsGoldCellPosition(randomRow, randomCol))
        {
            randomRow = Random.Range(0, gridSize);
            randomCol = Random.Range(0, gridSize);
        }
        goldCell1 = new Vector2Int(randomRow, randomCol);
        map[goldCell1.x, goldCell1.y] = 2;
        backCells[goldCell1.x, goldCell1.y].color = goldCellColor;
        backCells[goldCell1.x, goldCell1.y].sprite = exitCell;
        
        
        
        if (score.twoCell)
        {
            randomRow = Random.Range(0, gridSize);
            randomCol = Random.Range(0, gridSize);
            while (map[randomRow, randomCol] == 1 || IsGoldCellPosition(randomRow, randomCol))
            {
                randomRow = Random.Range(0, gridSize);
                randomCol = Random.Range(0, gridSize);
            }
            goldCell2 = new Vector2Int(randomRow, randomCol);
            
            map[goldCell2.x, goldCell2.y] = 2;
            backCells[goldCell2.x, goldCell2.y].color = goldCellColor;
            backCells[goldCell2.x, goldCell2.y].sprite = exitCell;
        }


    }
    void ShowWinCell()
    {
        Vector2Int winCell1 = Vector2Int.zero;
        int randomRow = Random.Range(0, gridSize);
        int randomCol = Random.Range(0, gridSize);
        while (map[randomRow, randomCol] == 1 || IsGoldCellPosition(randomRow, randomCol) || IsWinCellPosition(randomRow, randomCol, winCell1) || IsEmptyCell(randomRow, randomCol))
        {
            randomRow = Random.Range(0, gridSize);
            randomCol = Random.Range(0, gridSize);
        }
        winCell1.x = randomRow;
        winCell1.y = randomCol;
        cells[randomRow, randomCol].sprite = cheeseCell;
        cells[randomRow, randomCol].color = Color.white;

        if (score.twoCell)
        {
            randomRow = Random.Range(0, gridSize);
            randomCol = Random.Range(0, gridSize);
            while (map[randomRow, randomCol] == 1 || IsGoldCellPosition(randomRow, randomCol) || IsWinCellPosition(randomRow, randomCol, winCell1) || IsEmptyCell(randomRow, randomCol))
            {
                randomRow = Random.Range(0, gridSize);
                randomCol = Random.Range(0, gridSize);
            }
            cells[randomRow, randomCol].sprite = cheeseCell;
            cells[randomRow, randomCol].color = Color.white;
        }

    }
    bool IsEmptyCell(int row, int col)
    {

        return row == emptyCellPosition.x && col == emptyCellPosition.y;
    }
    bool IsWinCellPosition(int row, int col, Vector2Int position)
    {
        return row == position.x && col == position.y;
    }
    bool IsGoldCellPosition(int row, int col)
    {

        bool isGoldCell = (map[row, col] == 2);

        if (isGoldCell)
        {
            Debug.Log("Cell at row " + row + ", column " + col + " is a gold cell.");
        }
        return isGoldCell;
    }

    void UpdateGrid()
    {

        for (int i = 0; i < gridSize; i++)
        {
            for (int j = 0; j < gridSize; j++)
            {
                if (map[i, j] == 0)
                {
                    cells[i, j].color = Color.white;
                    cells[i, j].sprite = cell;
                }
                else if (map[i, j] == 1)
                {
                    cells[i, j].sprite = MouseTrap[Random.Range(0, MouseTrap.Length)];
                }
                backCells[i, j].color = new Color(1f, 1f, 1f, 1f);
                backCells[i, j].sprite = tile;
            }
        }
    }
    void EmptyCellRender()
    {
        cells[emptyCellPosition.x, emptyCellPosition.y].color = emptyCellColor;
        cells[emptyCellPosition.x, emptyCellPosition.y].sprite = mouse;

    }


    void MoveEmptyCell(int newRow, int newCol)
    {

        if (newRow >= 0 && newRow < gridSize && newCol >= 0 && newCol < gridSize && map[newRow, newCol] != 1)
        {

            Sprite emptyCellSprite = cells[emptyCellPosition.x, emptyCellPosition.y].sprite;

            Sprite targetCellSprite = cells[newRow, newCol].sprite;


            cells[emptyCellPosition.x, emptyCellPosition.y].sprite = targetCellSprite;
            cells[newRow, newCol].sprite = emptyCellSprite;


            Color emptyCellImage = cells[emptyCellPosition.x, emptyCellPosition.y].color;


            Color targetCellImage = cells[newRow, newCol].color;
            cells[emptyCellPosition.x, emptyCellPosition.y].color = targetCellImage;
            cells[newRow, newCol].color = emptyCellImage;


            emptyCellPosition.x = newRow;  
            emptyCellPosition.y = newCol;
            CheckWin();
            ArrowsTransform();



        }
        
       
    }
    void ArrowsTransform()
    {
        Transform parentTransform = cells[emptyCellPosition.x, emptyCellPosition.y].gameObject.transform;
        arrows.transform.localPosition = parentTransform.localPosition;
        CheckArrows();
       

    }
    void CheckArrows()
    {

        int emptyCellRow = emptyCellPosition.x;
        int emptyCellCol = emptyCellPosition.y;

        if (emptyCellCol > 0 && map[emptyCellRow, emptyCellCol - 1] != 1) 
        {
            leftA.SetActive(true);
        }
        else
        {
            leftA.SetActive(false);
        }

        if (emptyCellRow > 0 && map[emptyCellRow - 1, emptyCellCol] != 1) 
        {
            upA.SetActive(true);
        }
        else
        {
            upA.SetActive(false);
        }


        if (emptyCellCol < gridSize - 1 && map[emptyCellRow, emptyCellCol + 1] != 1) 
        {
            rightA.SetActive(true);
        }
        else
        {
            rightA.SetActive(false);
        }


        if (emptyCellRow < gridSize - 1 && map[emptyCellRow + 1, emptyCellCol] != 1) 
        {
            downA.SetActive(true);
        }
        else
        {
            downA.SetActive(false);
        }
    }
    void CheckWin()
    {

        if (score.twoCell)
        {
            if (cells[goldCell1.x, goldCell1.y].sprite == cheeseCell && cells[goldCell2.x, goldCell2.y].sprite == cheeseCell)
            {
                Debug.Log("You win!");
                score.OpenYouWin();
                mp.cheese += Mathf.RoundToInt((winCheese*score.selectedMap)*(1f+hotel.restaurantLevel/10f));
                if (score.activateCreditsBoost)
                {
                    mp.cheese += Mathf.RoundToInt((winCheese * score.selectedMap) * (1f + hotel.restaurantLevel / 10f)); score.activateCreditsBoost = false;
                }
                score.score += Mathf.RoundToInt((winScore * score.selectedMap) * (1f + hotel.roomLevel / 10f));
                score.scoreLvl += Mathf.RoundToInt((winScore * score.selectedMap) * (1f + hotel.roomLevel / 10f));
                if (score.activateScoreBoost)
                {
                    score.score += Mathf.RoundToInt((winScore * score.selectedMap) * (1f + hotel.roomLevel / 10f)); score.activateScoreBoost = false;
                    score.scoreLvl += Mathf.RoundToInt((winScore * score.selectedMap) * (1f + hotel.roomLevel / 10f));
                }
                score.AddBoost();
                score.UpdateScore();
                mp.UpdateCheese();
                score.youWin++;
                score.lvl++;
                if(score.youWin==8)
                {
                    score.youWin = 0;
                    if(score.maplvl<6)
                    {
                        score.maplvl++;
                    }
                }
                score.StartPlay();
            }
            else
            {
                Debug.Log("Keep trying...");
            }
        }
        else
        {
            if (cells[goldCell1.x, goldCell1.y].sprite == cheeseCell)
            {
                Debug.Log("You win!");
                score.OpenYouWin();
                mp.cheese += winCheese * score.selectedMap;
                if (score.activateCreditsBoost)
                {
                    mp.cheese += winCheese * score.selectedMap; score.activateCreditsBoost = false;
                }
                score.score += winScore * score.selectedMap;
                score.scoreLvl += winScore * score.selectedMap;
                if (score.activateScoreBoost)
                {
                    score.score += winScore * score.selectedMap; score.activateScoreBoost = false;
                    score.scoreLvl += winScore * score.selectedMap;
                }
                score.AddBoost();
                score.UpdateScore();
                mp.UpdateCheese();
                score.lvl++;
                score.youWin++;
                if (score.youWin == 8)
                {
                    score.youWin = 0;
                    if (score.maplvl < 6)
                    {
                        score.maplvl++;
                    }
                }
                score.StartPlay();
            }
            else
            {
                Debug.Log("Keep trying...");
            }
        }
       
    }



    public void MoveEmptyCellUp() { MoveEmptyCell(emptyCellPosition.x - 1, emptyCellPosition.y); }
    public void MoveEmptyCellDown() { MoveEmptyCell(emptyCellPosition.x + 1, emptyCellPosition.y); }
    public void MoveEmptyCellLeft() { MoveEmptyCell(emptyCellPosition.x, emptyCellPosition.y - 1); }
    public void MoveEmptyCellRight() { MoveEmptyCell(emptyCellPosition.x, emptyCellPosition.y + 1); }
}
