using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TalkManager : MonoBehaviour
{
    public Text NameText;
    public Text TalkText;
    public GameObject StartPart;   //开场对话
    public GameObject NextPart;
    public GameObject CharacterImage;
    public GameObject BackgroundImage;


    private Queue<string>Sentences;

    void Start()
    {
        Sentences = new Queue<string>();
        if (StartPart != null)
        {
            StartPart.GetComponent<TalkTrigger>().TriggerTalk();
        }
    }

    public void StartTalk(Talk talk)
    {
        if (talk.NextText != null)
        {
            NextPart = talk.NextText;
        }
        else
        {
            NextPart = null;
        }

        if (talk.CharacterImage != null)
        {
            Debug.Log("出现人物图片");
            talk.CharacterImage.SetActive(true);
            CharacterImage = talk.CharacterImage;
        }
        else
        {
            CharacterImage = null;
        }

        if (talk.BlackgroundImage != null)
        {
            Debug.Log("出现场景图片");
            talk.BlackgroundImage.SetActive(true);
            BackgroundImage = talk.BlackgroundImage;
        }
        else
        {
            BackgroundImage = null;
        }


        NameText.text = talk.name;
        TalkText.fontSize = talk.TextSize;
        Sentences.Clear();

        foreach (string sentence in talk.sentences)
        {
            Sentences.Enqueue(sentence);
        }
        DisplayNextSentence();
    }

    public void DisplayNextSentence()
    {
        if (Sentences.Count == 0)
        {
            EndTalk();
            return;
        }
        string sentence = Sentences.Dequeue();
        TalkText.text = sentence;
        StopAllCoroutines();
        StartCoroutine(TypeSentence(sentence));

    }

    IEnumerator TypeSentence(string sentence)
    {
        TalkText.text = "";
        foreach (char letter in sentence.ToCharArray())
        {
            TalkText.text += letter;
            yield return new WaitForSeconds(0.05f);
        }
        yield return null;
    }

    public void EndTalk()
    {
        if (CharacterImage != null)
        {
            Debug.Log("关闭角色图片");
            CharacterImage.SetActive(false);
        }

        if (BackgroundImage != null)
        {
            Debug.Log("关闭场景图片");
            BackgroundImage.SetActive(false);
        }

        if (NextPart != null)
        {
            NextPart.GetComponent<TalkTrigger>().TriggerTalk(); 
        }
        else TalkText.text = "";
    }

}