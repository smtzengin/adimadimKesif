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
        Vector3 mousePos = this.transform.position;
        player.GetComponent<PlayerMovementController>().Move(mousePos, .5f);
    }
}
