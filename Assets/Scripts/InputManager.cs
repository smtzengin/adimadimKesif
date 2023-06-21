using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InputManager : MonoBehaviour
{
    GameObject player;

    GameManager gameManager;

    AudioManager audioManager;

    public string name;

    private void Awake()
    {
        audioManager = Object.FindObjectOfType<AudioManager>();
        gameManager = Object.FindObjectOfType<GameManager>();
        player = GameObject.Find("Player");
    }

    private void OnMouseDown()
    {
        if (!gameManager.QuestionsAnswermi)
            return;

        if (this.transform.position.z > player.transform.position.z && this.transform.position.z < player.transform.position.z+2)
        {
            Vector3 mousePos = this.transform.position;
            player.GetComponent<PlayerMovementController>().Move(mousePos, .2f);
            gameManager.AnswersCheckIt(name);
            gameManager.QuestionsAnswermi = false;
            audioManager.ButonSesiCikar();
        }
        
    }
}
