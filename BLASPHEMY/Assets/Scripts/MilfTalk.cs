using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using TMPro;

public class MilfTalk : MonoBehaviour
{
    public UnityEvent enteredTrigger, exitedTrigger;
    private bool isInsideTrigger;
    public GameObject MilfTalkPanel, PlayerCapsule, OtherUI, MilfCamera, ClosedDooruwu, OpenDooruwu;
    public TMP_Text MilfTalkText;
    private int currentDialogueIndex = 0;
    private string[] dialogues = { "Haven't seen you before cutie, You must be new here", "Watch your step, its pretty dark in there, You know what the devil is like. " + " Boss isn't fond of the light", "Here, I'll give you acess to the big room. Be careful now, and stay out of his sight! My friend inside will tell you more.", "" };

    // Start is called before the first frame update
    void Start()
    {
        MilfTalkPanel.SetActive(false);
        MilfCamera.SetActive(false);
        PlayerCapsule.SetActive(true);
        OtherUI.SetActive(false);
        ClosedDooruwu.SetActive(true);
        OpenDooruwu.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        if (isInsideTrigger && Input.GetKeyDown(KeyCode.E))
        {
            StartDialogue();
            if (currentDialogueIndex < dialogues.Length)
            {
                MilfTalkText.text = dialogues[currentDialogueIndex];
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
        MilfTalkPanel.SetActive(false);
        MilfCamera.SetActive(false);
        PlayerCapsule.SetActive(true);
        OtherUI.SetActive(true);
        ClosedDooruwu.SetActive(false);
        OpenDooruwu.SetActive(true);
        currentDialogueIndex = 0;
    }
    void StartDialogue()
    {
        MilfTalkPanel.SetActive(true);
        MilfCamera.SetActive(true);
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
