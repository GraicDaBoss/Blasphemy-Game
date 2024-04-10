using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using TMPro;

public class ShieldTalk : MonoBehaviour
{
    public UnityEvent enteredTrigger, exitedTrigger;
    private bool isInsideTrigger;
    public GameObject ShieldTalkPanel, PlayerCapsule, OtherUI, ShieldCamera;
    public TMP_Text ShieldTalkText;
    private int currentDialogueIndex = 0;
    private string[] dialogues = { "well yes",  "" };

    // Start is called before the first frame update
    void Start()
    {
        ShieldTalkPanel.SetActive(false);
        ShieldCamera.SetActive(false);
        PlayerCapsule.SetActive(true);
        OtherUI.SetActive(false);

    }

    // Update is called once per frame
    void Update()
    {
        if (isInsideTrigger && Input.GetKeyDown(KeyCode.E))
        {
            StartDialogue();
            if (currentDialogueIndex < dialogues.Length)
            {
                ShieldTalkText.text = dialogues[currentDialogueIndex];
                currentDialogueIndex++;

                // If all dialogues have been displayed, hide the dialogue panel and show other UI elements
                if (currentDialogueIndex >= dialogues.Length)
                {
                    EndDialogue();
                }
            }
        }
    }
    void EndDialogue()
    {
        ShieldTalkPanel.SetActive(false);
        ShieldCamera.SetActive(false);
        PlayerCapsule.SetActive(true);
        OtherUI.SetActive(true);
        currentDialogueIndex = 0;
    }
    void StartDialogue()
    {
        ShieldTalkPanel.SetActive(true);
        ShieldCamera.SetActive(true);
        PlayerCapsule.SetActive(false);
        OtherUI.SetActive(false);
    }
    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            enteredTrigger.Invoke();
            isInsideTrigger = true;

        }
    }

    void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            exitedTrigger.Invoke();
            isInsideTrigger = false;

        }
    }
}


