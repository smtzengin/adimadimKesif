using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
using System;


public class GameManager : MonoBehaviour
{

    [SerializeField]
    GameObject questionsBackImg;

    [SerializeField]
    GameObject TrueIcon, FalseIcon;

  /*  [SerializeField]
    Animator PlayerAnim;*/

    public bool QuestionsAnswermi;

    public string CorrectAnswer;

   QuestionManager questionManager;

   private void Awake()
    {
        questionManager = GameObject.FindObjectOfType<QuestionManager>();
    }

    private void Start()
    {
        StartCoroutine(GameOpenRouitine());
    }

    private void StartCoroutine(IEnumerable enumerable)
    {
        throw new NotImplementedException();
    }

    IEnumerator GameOpenRouitine()
    {
        yield return new WaitForSeconds(.1f);
        questionsBackImg.GetComponent<RectTransform>().DOAnchorPosX(30, 1f);

        yield return new WaitForSeconds(1.1f);
        questionManager.PrintQuestions();
    }

    

    public void AnswersCheckIt (string CommingAnswer)
    {
        if(CommingAnswer == CorrectAnswer)
        {
            //Sonu� do�ru ise yap�lacak i�lemler
            TrueIconActive();
        }
        else
        {
            // Sonu� yanl�� ise yap�lacak i�lemler
            FalseIconActive();
         //   PlayerAnim.SetTrigger("Error");
 

        }
    }


    void TrueIconActive()
    {
        TrueIcon.GetComponent<CanvasGroup>().DOFade(1, .3f);
        Invoke("TrueIconClose", .8f);
    }
    void FalseIconActive()
    {
        FalseIcon.GetComponent<CanvasGroup>().DOFade(1, .3f);
        Invoke("FalseIconClose", .8f);
    }
    void TrueIconClose()
    {
        TrueIcon.GetComponent<CanvasGroup>().DOFade(0, .3f);
    }
    void FalseIconClose()
    {
        FalseIcon.GetComponent<CanvasGroup>().DOFade(0, .3f);
    }

}
