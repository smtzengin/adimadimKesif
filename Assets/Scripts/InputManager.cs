using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InputManager : MonoBehaviour
{
    GameObject player;

    private void Awake()
    {
        player = GameObject.Find("Player");
    }

    private void OnMouseDown()
    {

        if (this.transform.position.z > player.transform.position.z && this.transform.position.z < player.transform.position.z+2)
        {
            Vector3 mousePos = this.transform.position;
            player.GetComponent<PlayerMovementController>().Move(mousePos, .2f);
        }
        
    }
}
