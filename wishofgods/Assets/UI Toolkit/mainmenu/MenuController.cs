using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;
using UnityEngine.SceneManagement;

public class MenuController : MonoBehaviour
{
    public Button startButton;
    public Button quitButton;
    public Label messageText;

    public string levelname;

    void Start()
    {
        var root = GetComponent<UIDocument>().rootVisualElement;

        startButton = root.Q<Button>("StartButton");
        quitButton = root.Q<Button>("QuitButton");
        messageText = root.Q<Label>("test");

        startButton.clicked += StartButtonPressed;
        quitButton.clicked += QuitButtonPressed;
    }

    void StartButtonPressed()
    {
        Debug.Log("Loading");
        SceneManager.LoadScene(levelname);
    }
    void QuitButtonPressed()
    {
        Debug.Log("bye bye");
        messageText.text = "Pls dont leave me :(";
        messageText.style.display = DisplayStyle.Flex;
    }
}
