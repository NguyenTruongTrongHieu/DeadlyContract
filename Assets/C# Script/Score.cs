using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Score : MonoBehaviour
{
    public int totalScore;
    public int scoreTmp;

    public Text scoreText;
    public Button complete;
    public Button play;

    public GameObject Puzzle;
    public GameObject XepHinh;
    public GameObject ChooseBox;
    public GameObject Storage;

    public bool isReturnNewLevel = false;//bien xac dnh nguoi choi bam complete chua de xoa cac shape cu

    public void Start()
    {
        if (complete == null)
        {
            Debug.Log("complete null");
        }
        complete.onClick.AddListener(Complete);
    }

    public void AddScore()
    { 
        totalScore += scoreTmp;
        scoreTmp = 0;
    }

    public void SetScore()
    { 
        scoreText.text = $"Score: {totalScore}";
    }

    public void Complete()
    { 
        Puzzle.SetActive(false);
        ChooseBox.SetActive(true);
        XepHinh.SetActive(false);

        isReturnNewLevel = true;
        Storage.transform.SetParent(play.transform);
        //Storage.gameObject.GetComponent<StorageShape>().SpawnItems();
    }
}
