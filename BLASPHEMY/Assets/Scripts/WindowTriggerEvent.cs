using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using TMPro;

public class WindowTriggerEvent : MonoBehaviour
{
    public UnityEvent enteredTrigger, exitedTrigger, stayInTrigger;
    public GameObject objectToActivate;
    public GameObject objectToDeactivate;
    public TextMeshProUGUI countdownText;
    private bool isInsideTrigger;
    private Coroutine holdKeyCoroutine;

    void Update()
    {
        if (isInsideTrigger && Input.GetKeyDown(KeyCode.E))
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

        TriggerAction();
        countdownText.text = ""; // Clear countdown text after action is triggered
    }

    void UpdateCountdownText(float remainingTime)
    {
        countdownText.text = "Hold time: " + remainingTime.ToString("F1") + "s";
    }

    void TriggerAction()
    {
        if (objectToActivate != null)
        {
            objectToActivate.SetActive(true);
            if (objectToDeactivate != null)
            {
                objectToDeactivate.SetActive(false);
            }
        }
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            enteredTrigger.Invoke();
            isInsideTrigger = true;
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
    }
}

