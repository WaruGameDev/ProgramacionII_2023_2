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
    public TextMeshProUGUI characterName;
    public TextMeshProUGUI dialogue;
    public Image portrait;
    public List<Dialogue> dialogues;
    private int indexDialogue = 0;

    private void Start()
    {
        ShowDialogue(dialogues[0]);
    }

    public void ShowDialogue(Dialogue d)
    {
        characterName.text = d.characterNovel.nameCharacter;
        dialogue.text = d.dialogueCharacter;
        portrait.sprite = d.characterNovel.GetSpriteExpression(d.expression, d.headDown);
    }

    public void NextDialogue()
    {
        indexDialogue++;
        ShowDialogue(dialogues[indexDialogue]);
    }
}
