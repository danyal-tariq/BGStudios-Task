using System.Collections;
using DG.Tweening;
using TMPro;
using UnityEngine;

namespace _Scripts.UI
{
    public class DialogueManager : MonoBehaviour
    {
        [SerializeField] private TextMeshProUGUI dialogueText;
        [SerializeField] private CanvasGroup canvasGroup;

        public void SetDialogueText(string text)
        {
            dialogueText.SetText(text);
            dialogueText.maxVisibleCharacters = 0;
            canvasGroup.DOFade(1, 0.5f).OnComplete(() =>
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


            while (wordCount != dialogueText.maxVisibleCharacters)
            {
                dialogueText.maxVisibleCharacters++;
                yield return new WaitForSeconds(0.05f);
            }

            yield return new WaitForSeconds(2f);
            CloseDialogueText();
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
}