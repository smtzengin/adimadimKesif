using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;
using TMPro;
using DG.Tweening;
using UnityEngine.UI;

public class QuestionManager : MonoBehaviour
{
    [SerializeField] List<QuestionsItem> questionsList;


    [SerializeField] TMP_Text questionTxt;

    [SerializeField] GameObject answerPrefab;

    [SerializeField] Transform answerContainer;

    public string truthAnswer;

    int whichQuestion;

    int numberOfAnswers;

    string[] options = { "A", "B", "C" };

    private void Start()
    {
        questionsList = questionsList.OrderBy(i => Random.value).ToList(); // listedeki sorularý karýþtýrýp tekrar liste haline getiriyoruz.

        PrintQuestions();

    }

    void PrintQuestions()
    {
        questionTxt.text = questionsList[whichQuestion].questions;

        questionTxt.GetComponent<CanvasGroup>().alpha = 0f;
        questionTxt.GetComponent<RectTransform>().localScale = Vector3.zero;

        CreateAnswers();
    }

    void CreateAnswers()
    {
        for (int i = 0; i < 3; i++)
        {
            GameObject answerObject = Instantiate(answerPrefab);

            answerObject.transform.GetChild(0).GetComponent<TextMeshProUGUI>().text = options[i];

            answerObject.transform.GetChild(1).GetComponent<TextMeshProUGUI>().text = questionsList[whichQuestion].answers[i].ToString();

            answerObject.transform.SetParent(answerContainer);

            answerObject.GetComponent<Transform>().localScale = Vector3.zero;
        }

        truthAnswer = questionsList[whichQuestion].trueAnswer;

        StartCoroutine(OpenAnswersRoutine());

    }

    IEnumerator OpenAnswersRoutine()
    {
        yield return new WaitForSeconds(.5f);

        questionTxt.GetComponent<CanvasGroup>().DOFade(1, .3f);
        questionTxt.GetComponent<RectTransform>().DOScale(1, .3f);

        yield return new WaitForSeconds(.3f);

        while(numberOfAnswers < 3)
        {
            answerContainer.GetChild(numberOfAnswers).DOScale(1, .2f);
            yield return new WaitForSeconds(.1f);

            numberOfAnswers++;
        }
    }
}
