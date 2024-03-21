using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class WindowCounter : MonoBehaviour
{
    public static WindowCounter instance;
    public Image healthBar2;
    public TMP_Text WindowText;
    public int currentwindows = 0;
    public int totalWindows = 3;
    public int windowHealth = 3;
    public GameObject objectToActivate;
    public GameObject objectToActivate2;
    public GameObject Boss;
    public float fartsAgain;

    void Awake()
    {
        instance = this;
    }
    // Start is called before the first frame update
    void Start()
    {
        
        currentwindows = 0;
    }

    // Update is called once per frame
    void Update()
    {
        healthBar2.fillAmount = Mathf.Clamp((float)windowHealth / totalWindows, 0, 1);

        

    }


    public void IncreaseWindows(int v)
    {
        currentwindows += v;
        UpdateWindowText();
        windowHealth = totalWindows - currentwindows;

        // Check if the counter reaches a certain number and update text accordingly
        if (currentwindows >= totalWindows)
        {
            WindowText.text = "";
            objectToActivate.SetActive(true);
            objectToActivate2.SetActive(true);
            Boss.SetActive(false);

        }
    }
    private void UpdateWindowText()
    {
        WindowText.text = "Windows Broken: " + currentwindows.ToString() + " / " + totalWindows.ToString();
    }

}
