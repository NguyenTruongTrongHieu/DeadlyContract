using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting.Antlr3.Runtime.Tree;
using UnityEngine;
using UnityEngine.Rendering;

public class Grid : MonoBehaviour
{
    public int columns = 0;
    public int rows = 0;
    public float squaresGap = 0.1f;
    public GameObject gridSquare;
    public Vector2 startPosition = new Vector2(0,0);
    public float squareScale = 1.0f;
    public float everySquareOffset = 0;
    public bool isReset;//bien xac dinh grid co duoc tao moi khong

    private Vector2 offset = new Vector2 (0, 0);
    private List<GameObject> gridSquares = new List<GameObject>();
    
    // Start is called before the first frame update
    void Start()
    {
        //CreateGrid();
        isReset = false;
    }

    public void CreateGrid()
    {
        ResetGrid();
        isReset = false;
        SpawnGridSquares();
        SetGridSquaresPosition();
    }

    public void SpawnGridSquares()
    {
        int squareIndex = 0;
        for (int row = 0; row < rows; row++)
        {
            for (int column = 0; column < columns; column++)
            {
                gridSquares.Add(Instantiate(gridSquare) as GameObject);

                gridSquares[gridSquares.Count - 1].GetComponent<GridSquare>().squareIndex = squareIndex;
                gridSquares[gridSquares.Count - 1].transform.SetParent(this.transform);
                gridSquares[gridSquares.Count - 1].transform.localScale = new Vector3(squareScale, squareScale, squareScale);
                gridSquares[gridSquares.Count - 1].GetComponent<GridSquare>().SetImage();
                squareIndex++;

            }
        }
    }

    public void SetGridSquaresPosition()
    {
        int columnNumber = 0;
        int rowNumber = 0;
        Vector2 squareGapNumber = new Vector2(0, 0);
        bool rowMoved = false;

        var squareRect = gridSquares[0].GetComponent<RectTransform>();

        offset.x = squareRect.rect.width * squareRect.transform.localScale.x + everySquareOffset;
        offset.y = squareRect.rect.height * squareRect.transform.localScale.y + everySquareOffset;

        foreach (GameObject square in gridSquares)
        {
            if (columnNumber + 1 > columns)
            { 
                squareGapNumber.x = 0;
                columnNumber = 0;
                rowNumber++;
                rowMoved = false;
            }

            var posXOffset = offset.x * columnNumber + (squareGapNumber.x * squaresGap);
            var posYOffset = offset.y * rowNumber + (squareGapNumber.y * squaresGap);

            if (columnNumber > 0 && columnNumber % 3 == 0)
            {
                squareGapNumber.x++;
                posXOffset += squaresGap;
            }

            if (rowNumber > 0 && rowNumber % 3 == 0 && rowMoved == false)
            {
                rowMoved = true;
                squareGapNumber.x++;
                posXOffset += squaresGap;
            }

            square.GetComponent<RectTransform>().anchoredPosition = new Vector2 (startPosition.x + posXOffset, startPosition.y - posYOffset);
            square.GetComponent<RectTransform>().localPosition = new Vector3(startPosition.x + posXOffset, startPosition.y - posYOffset, 0);

            columnNumber++;
        }
    }

    private void OnDisable()
    {
        GameEvent.checkIfShapeCanBePlaced += checkIfShapeCanBePlaced;
    }

    private void OnEnable()
    {
        GameEvent.checkIfShapeCanBePlaced += checkIfShapeCanBePlaced;
    }

    private void checkIfShapeCanBePlaced()
    {
        var squareIndex = new List<int>();

        foreach (var square in gridSquares)
        {
            var gridSquare = square.GetComponent<GridSquare>();

            if (gridSquare.selected && !gridSquare.squareOccupied)
            {
                squareIndex.Add(gridSquare.squareIndex);
                gridSquare.selected = false;
                //gridSquare.ActivateSquare();
            }
        }
    }
    public void ResetGrid()
    {
        isReset = true;
        gridSquares.Clear();
    }
}
