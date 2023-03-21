using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;
using UnityEngine.UI;
using System.Diagnostics;
using TMPro;
using System;

// This Script is modified from the tutorial found at this link:
// "Make an Awesome Launcher for all your Games!" by Code Monkey
// https://www.youtube.com/watch?v=dELZXHlYqj4
public class LauncherHandler : MonoBehaviour
{
    private Process process;
    public Canvas messageCanvas;
    public TMP_Text messageText;
    private bool uploadProcessLaunched = false;

    public void LaunchGameExe()
    {
        process = Process.Start(Application.dataPath + "/../Game/VARTA Project.exe");
        messageCanvas.gameObject.SetActive(true);
        messageText.text = "Game Launched";
    }

    public void UploadFile()
    {
        string path = Application.dataPath + "\\..\\Game\\VARTA Project_Data\\StreamingAssets\\Stories\\PracticeStories";
        if (Directory.Exists(path))
        {
            process = Process.Start(path);
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (process != null && process.HasExited)
        {
            process = null;
            messageCanvas.gameObject.SetActive(false);
        }
        if (Input.GetKeyDown(KeyCode.Escape) && uploadProcessLaunched)
        {
            messageCanvas.gameObject.SetActive(false);
        }
    }

    void Awake()
    {
        messageCanvas.gameObject.SetActive(false);
    }

    public void ShowUploadMessage()
    {
        uploadProcessLaunched = true;
        messageCanvas.gameObject.SetActive(true);
        messageText.text = "Drag your .txt file(s) into the opened window.\nPress ESC to return to options.";
    }
}
