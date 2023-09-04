using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NPCDialogueTrigger : MonoBehaviour
{
    public List<Dialogue> npcDialogues;
    public bool playerInZone;

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            DialogueManager.instance.AddDialogues(npcDialogues);
            playerInZone = true;
        }
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            playerInZone = false;
        }
    }

    private void Update()
    {
        if (playerInZone)
        {
            if (Input.GetKeyDown(KeyCode.E))
            {
                if (!DialogueManager.instance.isTalking)
                {
                    DialogueManager.instance.ShowDialogue(DialogueManager.instance.dialogues[0]);
                }
                else
                {
                    DialogueManager.instance.NextDialogue();
                }
               
            }
        }
    }
}
