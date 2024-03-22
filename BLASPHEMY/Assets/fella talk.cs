using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using TMPro;

public class fellatalk : MonoBehaviour
{
    public UnityEvent enteredTrigger, exitedTrigger;
    private bool isInsideTrigger;
    public GameObject FellaTalkPanel, PlayerCapsule, OtherUI, FellaCamera;
    public TMP_Text FellaTalkText;
    private int currentDialogueIndex = 0;
    private string[] dialogues = { "hey", "go break window", "" };

    // Start is called before the first frame update
    void Start()
    {
        FellaTalkPanel.SetActive(false);
        FellaCamera.SetActive(false);
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
                FellaTalkText.text = dialogues[currentDialogueIndex];
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
        FellaTalkPanel.SetActive(false);
        FellaCamera.SetActive(false);
        PlayerCapsule.SetActive(true);
        OtherUI.SetActive(true);
        currentDialogueIndex = 0;
    }
    void StartDialogue()
    {
        FellaTalkPanel.SetActive(true);
        FellaCamera.SetActive(true);
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
