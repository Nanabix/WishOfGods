using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;
using UnityEngine.SceneManagement;

public class UIController : MonoBehaviour
{
    public Button startButton;
    public Button quitButton;
    public Label messageText;

    public string levelName;

    void Start()
    {
        var root = GetComponent<UIDocument>().rootVisualElement;

        startButton = root.Q <Button> ("StartGame");
        quitButton = root.Q<Button>("QuitGame");
        messageText = root.Q<Label>("Label");

        startButton.clicked += StartButtonPressed;
        quitButton.clicked += QuitButtonPressed;
    }

    void StartButtonPressed()
    {
        SceneManager.LoadScene(levelName);
    }

    void QuitButtonPressed()
    {
        messageText.text = "Pls dont leave, I have Attachment Issues";
        messageText.style.visibility = Visibility.Visible;
    }

}
