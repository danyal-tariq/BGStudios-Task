using DG.Tweening;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class DialogueManager : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI dialogueText;
    [SerializeField] private CanvasGroup canvasGroup;

    public void SetDialogueText(string text)
    {
        dialogueText.SetText(text);
        dialogueText.maxVisibleCharacters = 0;
        canvasGroup.DOFade(1, 0.5f).OnComplete(()=>
        {
            canvasGroup.interactable = true;
            canvasGroup.blocksRaycasts = true;

            StartCoroutine(nameof(ShowTextSequence));
        });
       
    }
    private IEnumerator ShowTextSequence()
    {
        var wordCount = dialogueText.textInfo.characterCount;
        Debug.Log(wordCount);
   

        while (wordCount!=dialogueText.maxVisibleWords)
        {
            dialogueText.maxVisibleCharacters++;
            yield return new WaitForSeconds(0.05f);
        }
    }
    public void CloseDialogueText()
    {
        canvasGroup.DOFade(0, 0.5f).OnComplete(() =>
        {
            canvasGroup.interactable = false;
            canvasGroup.blocksRaycasts = false;
  
        });
    }
}
