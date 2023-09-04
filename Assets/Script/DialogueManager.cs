using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public enum EXPRESSION
{
    NEUTRAL, BLUSH, PISSED
}
[System.Serializable]
public class Dialogue
{
    public CharacterNovel characterNovel;
    public string dialogueCharacter;
    public bool headDown;
    public EXPRESSION expression;
}
public class DialogueManager : MonoBehaviour
{
    public static DialogueManager instance;
    public TextMeshProUGUI characterName;
    public TextMeshProUGUI dialogue;
    public Image portrait;
    public List<Dialogue> dialogues;
    private int indexDialogue = 0;
    public CanvasGroup cg;
    public bool isTalking;
    public PlatformPlayerController player;

    private void Awake()
    {
        instance = this;
    }

    private void Start()
    {
        cg.alpha = 0;
        cg.interactable = false;
        cg.blocksRaycasts = false;
    }

    private void Update()
    {
        if (isTalking)
        {
            player.canMove = false;
        }
    }

    public void ShowDialogue(Dialogue d)
    {
        isTalking = true;
        cg.alpha = 1;
        cg.interactable = true;
        cg.blocksRaycasts = true;
        characterName.text = d.characterNovel.nameCharacter;
        dialogue.text = d.dialogueCharacter;
        portrait.sprite = d.characterNovel.GetSpriteExpression(d.expression, d.headDown);
    }

    public void NextDialogue()
    {
        indexDialogue++;
        if (indexDialogue >= dialogues.Count)
        {
            isTalking = false;
            cg.alpha = 0;
            cg.interactable = false;
            cg.blocksRaycasts = false;
            indexDialogue = 0;
            player.canMove = true;
        }
        else
        {
            ShowDialogue(dialogues[indexDialogue]);
        }
    }
    public void AddDialogues(List<Dialogue> dialoguesToAdd)
    {
        dialogues.Clear();
        dialogues.AddRange(dialoguesToAdd);
    }

}
