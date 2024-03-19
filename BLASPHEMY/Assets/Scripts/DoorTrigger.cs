using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using TMPro;


public class DoorTrigger : MonoBehaviour
{
    public UnityEvent enteredTrigger, exitedTrigger, stayInTrigger;
    public TextMeshProUGUI countdownText, DoorText;
    public GameObject UnlockedDoor, CloseDoor, Door;
    private bool isInsideTrigger;
    private Coroutine holdKeyCoroutine;
    // Start is called before the first frame update
    void Update()
    {
        if (isInsideTrigger && Input.GetKeyDown(KeyCode.E) && CloseDoor != null)
        {
            holdKeyCoroutine = StartCoroutine(HoldKeyCoroutine());
        }

        if (Input.GetKeyUp(KeyCode.E))
        {
            if (holdKeyCoroutine != null)
            {
                StopCoroutine(holdKeyCoroutine);
                countdownText.text = ""; // Clear countdown text when key is released
            }
        }
    }
    IEnumerator HoldKeyCoroutine()
    {
        float holdDuration = 0f;
        while (holdDuration < 3f)
        {
            holdDuration += Time.deltaTime;
            UpdateCountdownText(3f - holdDuration); // Update countdown text
            yield return null;
        }

        Door.SetActive(false);
        DoorText.text = "";
        countdownText.text = ""; // Clear countdown text after action is triggered
    }

    void UpdateCountdownText(float remainingTime)
    {
        countdownText.text = "Hold time: " + remainingTime.ToString("F1") + "s";
    }
    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            enteredTrigger.Invoke();
            isInsideTrigger = true;
        }
        if (UnlockedDoor == true)
        {
            DoorText.text = "Locked";

        }
        else if(UnlockedDoor == false)
        {
            DoorText.text = "Hold E";
        }
        

    }

    void OnTriggerStay(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            stayInTrigger.Invoke();
        }
    }


    void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            exitedTrigger.Invoke();
            isInsideTrigger = false;
            if (holdKeyCoroutine != null)
            {
                StopCoroutine(holdKeyCoroutine);
                countdownText.text = ""; // Clear countdown text when exiting trigger
            }
        }
        DoorText.text = "";
    }
}