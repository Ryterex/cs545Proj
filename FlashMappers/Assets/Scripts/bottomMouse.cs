﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class bottomMouse : MonoBehaviour
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
        diamondButtons.topButton.SetActive(false);
        if (playerMovement.fromLeft)
        {
            saveData.selectedAnswer = 3;
            Debug.Log(saveData.selectedAnswer);
        }
        else if (playerMovement.fromRight)
        {
            saveData.selectedAnswer = 3;
            Debug.Log(saveData.selectedAnswer);
        }
        else
        {
            saveData.selectedAnswer = 2;
            Debug.Log(saveData.selectedAnswer);
        }
        if (saveData.selectedAnswer == saveData.questionSlot)
        {
            saveData.chosenCard.seenYet = true;
            saveData.numCardsLeft--;
            if (saveData.numCardsLeft <= 0)
            {
                StartCoroutine(playerMovement.moveDown());
                StartCoroutine(waiting());
                
                return;
            }
        }
        playerMovement.player.GetComponent<playerMovement>().StartCoroutine(playerMovement.moveDown());
        Debug.Log("bottom");
    }

    IEnumerator waiting(){
        while(!playerMovement.fromTop){
            yield return new WaitForSeconds(0.1f);
        }
        SceneManager.LoadScene("winScreen", LoadSceneMode.Single);
    }
}
