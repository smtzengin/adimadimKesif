using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class PlayerMovementController : MonoBehaviour
{

    bool isMove;

    Vector3 whichDirection;

    Quaternion returnDirection;

    private void Start()
    {

        
    }

    public void Move(Vector3 targetPos, float delayTime = 0.2f)
    {
        if (!isMove)
        {
            StartCoroutine(MovementRoutine(targetPos, delayTime));
        }
    }


    IEnumerator MovementRoutine(Vector3 targetPos,float delayTime)
    {
        isMove = true;

        whichDirection = new Vector3(targetPos.x - transform.position.x, transform.position.y, targetPos.z - transform.position.z);

        returnDirection = Quaternion.LookRotation(whichDirection);

        transform.DORotateQuaternion(returnDirection, .2f);

        yield return new WaitForSeconds(delayTime);

        this.transform.DOMove(targetPos, delayTime);

        while(Vector3.Distance(targetPos, this.transform.position) > 0.01f)
        {
            yield return null;
        }

        returnDirection = Quaternion.LookRotation(Vector3.zero);
        transform.DORotateQuaternion(returnDirection, .1f);

        this.transform.position = targetPos;

        isMove = false;
    }
}
