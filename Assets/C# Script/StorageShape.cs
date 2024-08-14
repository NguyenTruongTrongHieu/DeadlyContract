using System.Collections;
using System.Collections.Generic;
using System.Drawing;
using UnityEngine;

public class StorageShape : MonoBehaviour
{
    public List<GameObject> shapes = new List<GameObject>();
    public List<GameObject> shapeInGame = new List<GameObject>();

    public GameObject Storage;
    public GameObject Puzzle;
    public Transform point;

    public float distance = 5.0f;
    public float distanceRow = 2;
    public float ShapeScale = 1;

    public int shapesNumber = 1;//Tong so luong item
    public int shapeNumberInRow = 1;//So luong item tren 1 hang

    // Start is called before the first frame update
    void Start()
    {

        SpawnItems();
    }

    private void Update()
    {
        if (Puzzle.gameObject.activeSelf)
        {
            Storage.transform.SetParent(Puzzle.transform) ;
        }
    }

    public void SpawnItems()
    {
        for (int i = 0; i < shapesNumber; i++)
        {
            int j = Random.Range(0, shapes.Count - 1);
            shapeInGame.Add(shapes[j]);
        }

        int shapeNumberInRowTmp = shapeNumberInRow;//bien tam de duyet qua tung hang trong vong lap

        for (int i = 0; i < shapeInGame.Count; i++)
        {
            bool isFirstItem = false;
            if (i == 0)
            { 
                isFirstItem = true;
            }

            point.position = new Vector3(point.position.x - (isFirstItem ? 0 : distance), point.position.y, point.position.z);
            GameObject Shape = Instantiate(shapeInGame[i], point.position, Quaternion.identity);
            Shape.transform.SetParent(this.transform);
            Shape.transform.localScale = new Vector3(ShapeScale, ShapeScale, ShapeScale);

            shapeNumberInRowTmp--;

            if (shapeNumberInRowTmp == 0)
            {
                /*shapeNumberInRow--;*/
                shapeNumberInRowTmp = shapeNumberInRow;
                point.position = new Vector3(point.position.x + distance * (shapeNumberInRow ), point.position.y - distanceRow, point.position.z);
            }
        }
    }

    public void CalculateScore()
    {

    }
}
