using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class WindowCounter : MonoBehaviour
{
    public static WindowCounter instance;

    public TMP_Text WindowText;
    public int currentwindows = 0;
    public int totalWindows = 3;
    public GameObject objectToActivate;
    public GameObject objectToActivate2;
    void Awake()
    {
        instance = this;
    }
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }
    public void IncreaseWindows(int v)
    {
        currentwindows += v;
        UpdateWindowText();

        // Check if the counter reaches a certain number and update text accordingly
        if (currentwindows >= totalWindows)
        {
            WindowText.text = "";
            objectToActivate.SetActive(true);
            objectToActivate2.SetActive(true);

        }
    }
    private void UpdateWindowText()
    {
        WindowText.text = "Windows Broken: " + currentwindows.ToString() + " / " + totalWindows.ToString();
    }

}
