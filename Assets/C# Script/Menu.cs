using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Menu : MonoBehaviour
{
    public Button ChoiGame;
    public Button Thoat;
    // Start is called before the first frame update
    void Start()
    {
        ChoiGame.onClick.AddListener(PlayGame);
        Thoat.onClick.AddListener(QuitGame);
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void PlayGame()
    {
        SceneManager.LoadScene("SceneBoiCanh");
    }   
    
    public void QuitGame()
    {
        Application.Quit();
    }
}
