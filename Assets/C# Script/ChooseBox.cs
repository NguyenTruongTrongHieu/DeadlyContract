using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ChooseBox : MonoBehaviour
{
    public Button box3x3;
    public Button box4x4;
    public Button box5x5;

    public GameObject Puzzle;
    public GameObject Grid;

    public GameObject Vien3;
    public GameObject Vien4;
    public GameObject Vien5;

    private Grid gridInstance;

    // Start is called before the first frame update
    void Start()
    {
        gridInstance = Grid.GetComponent<Grid>();
        box3x3.onClick.AddListener(Box3x3);
        box4x4.onClick.AddListener(Box4x4);
        box5x5.onClick.AddListener(Box5x5);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void Box3x3()
    { 
        Puzzle.SetActive(true);
        var grid = GameObject.FindGameObjectWithTag("Grid").GetComponent<Grid>();
        Vien3.SetActive(true);
        Vien4.SetActive(false);
        Vien5.SetActive(false);
        if (grid == null)
        {
            Debug.Log("Cut");
            return;
        }
        grid.rows = 3;
        grid.columns = 3;
        grid.startPosition = new Vector2(-239, -140);

        //Score.scoreInstance.scoreTmp = 20;
        gridInstance.CreateGrid();
    }

    public void Box4x4()
    {
        Puzzle.SetActive(true);
        var grid = GameObject.FindGameObjectWithTag("Grid").GetComponent<Grid>();
        Vien3.SetActive(false);
        Vien4.SetActive(true);
        Vien5.SetActive(false);
        if (grid == null)
        {
            Debug.Log("Cut");
            return;
        }
        grid.rows = 4;
        grid.columns = 4;
        grid.startPosition = new Vector2(-272, -161);

        //Score.scoreInstance.scoreTmp = 10;
        gridInstance.CreateGrid();
    }

    public void Box5x5()
    {
        Puzzle.SetActive(true);
        var grid = GameObject.FindGameObjectWithTag("Grid").GetComponent<Grid>();
        Vien3.SetActive(false);
        Vien4.SetActive(false);
        Vien5.SetActive(true);
        if (grid == null)
        {
            Debug.Log("Cut");
            return;
        }
        grid.rows = 5;
        grid.columns = 5;
        grid.startPosition = new Vector2(-345, -148);

        //Score.scoreInstance.scoreTmp = 10;
        gridInstance.CreateGrid();
    }
}
