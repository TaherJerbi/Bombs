﻿using UnityEngine;
using DG.Tweening;
using UnityEngine.UI;
using UnityEditor.SceneManagement;
using UnityEditor;

public class GameManager : MonoBehaviour {
    [SerializeField]
    GameObject[] UiItems;
    [SerializeField]
    GameObject CameraAnimator;
    [SerializeField]
    Sprite[] SoundIcons;
    [SerializeField]
    AudioSource Audio;

    // Use this for initialization
	void Start () {
        UiItems[3].SetActive(false);
        Audio.PlayDelayed(2f);
        CameraAnimator.transform.DOMoveY(0, 3f).OnComplete(BringUI);
	}

    void BringUI () {
        foreach (GameObject ui in UiItems)
        {
            ui.transform.DOLocalMoveX(0f, 2f);
        }
    }
    public void StartGame () {
        GetComponent<ScoreManager>().score = 0;
        GameObject.FindGameObjectWithTag("SpawnManager").GetComponent<BombSpawner>().enabled = true;
        GameObject.FindGameObjectWithTag("SpawnManager").GetComponent<BombSpawner>().Dead = false;
        GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerScript>().enabled = true;
        foreach(GameObject ui in UiItems) {
            ui.transform.DOLocalMoveX(500f, 2f);
        }
    }
    public void Rate () {
        #if UNITY_ANDROID
        Application.OpenURL("market://details?id=YOUR_ID");
        #elif UNITY_IPHONE
        Application.OpenURL("itms-apps://itunes.apple.com/app/idYOUR_ID");
        #endif
    }
    public void Levels () {
        if(UiItems[3].activeSelf) {
            UiItems[3].SetActive(false);
        } else{
            UiItems[3].SetActive(true);

        }
    }
    public void Settings  () {
        
    }
    public void ToggleSound (Button button) {
        Debug.Log(button.name);
        if(button.GetComponent<Image>().sprite.name == "mute") {
            button.GetComponent<Image>().sprite = SoundIcons[0];
            Audio.mute = false;
        } else {
            button.GetComponent<Image>().sprite = SoundIcons[1];
            Audio.mute = true;
        }
    }
    public void RestartGame ( ) {
        foreach (GameObject ui in UiItems)
        {
            ui.transform.DOLocalMoveX(0f, 0.5f);
        }
    }
}
