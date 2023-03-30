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

    // This function is called when the user clicks the buttom to launch the game.
    public void LaunchGameExe()
    {
        process = Process.Start(Application.dataPath + "/../Game/VARTA Project.exe");
        messageCanvas.gameObject.SetActive(true);
        messageText.text = "Game Launched";
    }

    // This function is called when the user click the button to upload a document.
    // It launches the explorer window to allow the user move a document to the games StreamingAssets folder.
    // The game will then read the document from that folder.
    // Any document can be uploaded, but only .txt files will be read by the game.
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
        // This checks if the game is closed. If it is it allows the user to use the launcher again.
        if (process != null && process.HasExited)
        {
            process = null;
            messageCanvas.gameObject.SetActive(false);
        }
        // This lets the user access the launcher again if the game process is closed but it did not
        // close the launcher blocker canvas.
        if (Input.GetKeyDown(KeyCode.Escape) && uploadProcessLaunched)
        {
            messageCanvas.gameObject.SetActive(false);
        }
    }

    // This tells the launcher to close the blocker canvas when it first starts.
    void Awake()
    {
        messageCanvas.gameObject.SetActive(false);
    }

    // This function is called when the user clicks the button to upload a document.
    // It is meant to block the user from using the launcher while the explorer window is open.
    // It is not currently working. The launcher does not recognize when the explorer window is opened.
    public void ShowUploadMessage()
    {
        uploadProcessLaunched = true;
        messageCanvas.gameObject.SetActive(true);
        messageText.text = "Drag your .txt file(s) into the opened window.\nPress ESC to return to options.";
    }
}
