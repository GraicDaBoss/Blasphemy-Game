using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class ShieldPlayer : MonoBehaviour
{
    public GameObject shieldObject;
    public float shieldDuration = 6f;
    public float cooldownDuration = 5f;
    public TextMeshProUGUI shieldText;

    private bool isCooldown = false;
    private bool isShieldActive = false;

    void Start()
    {
        UpdateShieldText();
    }

    void Update()
    {
        if (!isCooldown && !isShieldActive && Input.GetKeyDown(KeyCode.Q))
        {
            StartCoroutine(ActivateShield());
        }
    }

    IEnumerator ActivateShield()
    {
        isCooldown = true;
        isShieldActive = true;
        shieldObject.SetActive(true); // Activate the shield object

        float shieldTimer = shieldDuration;
        while (shieldTimer > 0 && isShieldActive)
        {
            shieldTimer -= Time.deltaTime;
            UpdateShieldText(shieldTimer, 0f);
            yield return null;
        }

        isShieldActive = false;
        shieldObject.SetActive(false); // Deactivate the shield object

        float cooldownTimer = cooldownDuration;
        while (cooldownTimer > 0 && isCooldown)
        {
            cooldownTimer -= Time.deltaTime;
            UpdateShieldText(0f, cooldownTimer);
            yield return null;
        }

        isCooldown = false;
        UpdateShieldText();
    }

    void UpdateShieldText(float shieldTimeRemaining = 0f, float cooldownTimeRemaining = 0f)
    {
        if (isCooldown && !isShieldActive)
        {
            shieldText.text = "Shield Cooldown: " + Mathf.CeilToInt(cooldownTimeRemaining).ToString();
        }
        else if (isShieldActive)
        {
            shieldText.text = "Shield Left: " + Mathf.CeilToInt(shieldTimeRemaining).ToString();
        }
        else
        {
            shieldText.text = "Shield ready, Press Q to activate";
        }
    }
}






