using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
using System;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{

    [SerializeField]
    GameObject questionsBackImg;

    [SerializeField]
    GameObject TrueIcon, FalseIcon;

    [SerializeField]
    GameObject robot1,robot2,robot3;
    [SerializeField]
    GameObject dogruSonuc, yanlisSonuc;

    public bool QuestionsAnswermi;

    public string CorrectAnswer;
    int kalanHak;

    QuestionManager questionManager;

    PlayerMovementController playerMovementController;

    AudioManager audioManager;

    int dogruAdet;

   private void Awake()
    {
        audioManager = GameObject.FindObjectOfType<AudioManager>();
        playerMovementController =  GameObject.FindObjectOfType<PlayerMovementController>();
        questionManager = GameObject.FindObjectOfType<QuestionManager>();
    }

    private void Start()
    {
        kalanHak = 3;
        dogruAdet = 0;
        StartCoroutine(GameOpenRouitine());
    }


    IEnumerator GameOpenRouitine()
    {
        yield return new WaitForSeconds(.1f);
        audioManager.BaslaSesiCikar();
        questionsBackImg.GetComponent<RectTransform>().DOAnchorPosX(30, 1f);

        yield return new WaitForSeconds(1.1f);
        questionManager.PrintQuestions();
    }

    

    public void AnswersCheckIt (string CommingAnswer)
    {
        if(CommingAnswer == CorrectAnswer)
        {
            dogruAdet++;
            audioManager.DogruSesiCikar();
            if (dogruAdet >= 10)
            {
                DogruSonucGoster();
            }
            else
            {
                questionManager.PrintQuestions();
            }
            TrueIconActive();
        }
        else
        {
            // Sonuç yanlýþ ise yapýlacak iþlemler
            audioManager.YanlisSesiCikar();
            FalseIconActive();
            StartCoroutine(OyuncuHataYaptiGeriGeldi());

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

    IEnumerator OyuncuHataYaptiGeriGeldi()
    {
        yield return new WaitForSeconds(1f);
        playerMovementController.PlayerMadeMistake();
        yield return new WaitForSeconds(1.4f);
        kalanHak--;
        HakKaybet();
        if(kalanHak > 0)
        {
            playerMovementController.PlayerComeBack();
            yield return new WaitForSeconds(1f);
            questionManager.PrintQuestions();
        }
        else
        {
            YanlisSonucGoster();
            print("oyun bitti");
        }
        
    }

    void HakKaybet()
    {
        if(kalanHak == 2)
        {
            robot3.SetActive(false);
            robot2.SetActive(true);
            robot1.SetActive(true);
            dogruAdet = 0;
        }
        if (kalanHak == 1)
        {
            robot3.SetActive(false);
            robot2.SetActive(false);
            robot1.SetActive(true);
            dogruAdet = 0;
        }
        if (kalanHak == 0)
        {
            robot3.SetActive(false);
            robot2.SetActive(false);
            robot1.SetActive(false);
        }
    }

    void DogruSonucGoster()
    {
        audioManager.BitisSesiCikar();
        questionsBackImg.GetComponent<RectTransform>().DOAnchorPosX(-658f, 1f);
        dogruSonuc.GetComponent<CanvasGroup>().DOFade(1, .5f);
        dogruSonuc.GetComponent<RectTransform>().DOScale(1, .5f).SetEase(Ease.OutBack);
    }
    void YanlisSonucGoster()
    {
        audioManager.BitisSesiCikar();
        questionsBackImg.GetComponent<RectTransform>().DOAnchorPosX(-658f, 1f);
        yanlisSonuc.GetComponent<CanvasGroup>().DOFade(1, .5f);
        yanlisSonuc.GetComponent<RectTransform>().DOScale(1, .5f).SetEase(Ease.OutBack);
    }

    public void PlayAgain()
    {
        SceneManager.LoadScene(0);
    }
    public void ExitGame()
    {
        Application.Quit();
    }
}
