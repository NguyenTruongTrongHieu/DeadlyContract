using UnityEngine.SceneManagement;
using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class MenuManager : MonoBehaviour
{
    [Header("Main Menu")]
    public Button StartButton;
    public Button OptionsButton;
    public Button LoadButton;
    public Button ExitButton;

    [Header("Options")]
    public GameObject OptionsForm;
    public Button Volume;
    public Button OptionsToMainMenu;

    [Header("Volume")]
    public GameObject VolumeMenu;
    public Slider MusicSlider;
    public Slider SFXSlider;
    public Button VolumeToMainMenu;


    void Start()
    {
        StartButton.onClick.AddListener(StartTheGame);
        OptionsButton.onClick.AddListener(OptionsScene);
        ExitButton.onClick.AddListener(Exit);
        Volume.onClick.AddListener(VolumeScene);
        OptionsToMainMenu.onClick.AddListener(OptionsScene);
        VolumeToMainMenu.onClick.AddListener(VolumeScene);
    }

    public void StartTheGame()
    {
        SceneManager.LoadScene(2);
    }

    public void OptionsScene()
    {
        OptionsForm.SetActive(OptionsForm.activeSelf);
    }

    public void VolumeScene()
    {
        VolumeMenu.SetActive(VolumeMenu.activeSelf);
    }

    public void Exit()
    {
        Application.Quit();
    }
}
