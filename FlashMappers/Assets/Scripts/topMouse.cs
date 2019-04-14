﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class topMouse : MonoBehaviour
{
    // Start is called before the first frame update
    Camera mainCam;
    void Start()
    {
        mainCam = Camera.main;
    }

    // Update is called once per frame
    void Update()
    {

    }

    void OnMouseDown()
    {
        diamondButtons.leftButton.SetActive(false);
        diamondButtons.rightButton.SetActive(false);
        diamondButtons.bottomButton.SetActive(false);
        if (playerMovement.fromLeft)
        {
            saveData.selectedAnswer = 1;
        }
        else if (playerMovement.fromRight)
        {
            saveData.selectedAnswer = 1;
        }
        else
        {
            saveData.selectedAnswer = 2;
        }
        if (saveData.selectedAnswer == saveData.questionSlot)
        {
            saveData.chosenCard.seenYet = true;
            saveData.numCardsLeft--;
            if (saveData.numCardsLeft == 0)
            {
                SceneManager.LoadScene("mainMenu", LoadSceneMode.Single);
            }
        }
        playerMovement.player.GetComponent<playerMovement>().StartCoroutine(playerMovement.moveUp());
        Debug.Log("top");
    }
}