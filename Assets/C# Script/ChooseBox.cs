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

    public GameObject Vien3;
    public GameObject Vien4;
    public GameObject Vien5;

    // Start is called before the first frame update
    void Start()
    {
        box3x3.onClick.AddListener(Box3x3);
        box4x4.onClick.AddListener(Box4x4);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void Box3x3()
    { 
        Puzzle.SetActive(true);
        var grid = GameObject.FindGameObjectWithTag("Grid").GetComponent<Grid>();
        Vien4.SetActive(false);
        Vien5.SetActive(false);
        if (grid == null)
        {
            Debug.Log("Cut");
            return;
        }
        grid.rows = 3;
        grid.columns = 3;
        grid.startPosition = new Vector2(-220, 33);

        //Score.scoreInstance.scoreTmp = 20;
    }

    public void Box4x4()
    {
        Puzzle.SetActive(true);
        var grid = GameObject.FindGameObjectWithTag("Grid").GetComponent<Grid>();
        Vien3.SetActive(false);
        Vien5.SetActive(false);
        if (grid == null)
        {
            Debug.Log("Cut");
            return;
        }
        grid.rows = 4;
        grid.columns = 4;
        grid.startPosition = new Vector2(-212, 94);

        //Score.scoreInstance.scoreTmp = 10;
    }
}
