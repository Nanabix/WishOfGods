using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using Ink.Runtime;
using UnityEngine.InputSystem;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class DialogueManager : MonoBehaviour
{
    [Header("Variables")]
    [SerializeField] private float typingSpeed = 0.02f;

    [Header("Dialogue UI")]
    [SerializeField] private GameObject dialoguePanel;
    [SerializeField] private GameObject continueIcon;
    [SerializeField] private TextMeshProUGUI dialogueText;
    [SerializeField] private TextMeshProUGUI displayNameText;
    [SerializeField] private Animator portraitAnimator;
    private Animator layoutAnimator;

    [Header("Choices UI")]
    [SerializeField] private GameObject[] choices;
    private TextMeshProUGUI[] choicesText;

    [Header("Player Input")]
    public TMP_InputField inputField;

    private Story currentStory;
    private Coroutine displayTextCoroutine;
    public bool dialogueIsPlaying { get; private set; }
    private bool canContinueToNextLine = false;

    private static DialogueManager instance;

    private const string SPEAKER_TAG = "speaker";
    private const string PORTRAIT_TAG = "portrait";
    private const string LAYOUT_TAG = "layout";

    private void Awake()
    {
        if (instance != null) { Debug.LogWarning("Found more than one Manager in this scene"); }
        instance = this;
    }

    public static DialogueManager GetInstance()
    {
        return instance;
    }

    private void Start()
    {
        dialogueIsPlaying = false;
        dialoguePanel.SetActive(false);
        inputField.gameObject.SetActive(false);

        layoutAnimator = dialoguePanel.GetComponent<Animator>();

        
        
        choicesText = new TextMeshProUGUI[choices.Length];
        int index = 0;
        //check choices
        foreach (GameObject choice in choices)
        {
            choicesText[index] = choice.GetComponentInChildren<TextMeshProUGUI>();
            index++;
        }
    }
    private void Update()
    {
        // return right away if dialogue isn't playing
        if (!dialogueIsPlaying)
        {
            return;
        }

        // handle continuing to the next line in the dialogue when submit is pressed
        if (canContinueToNextLine
            && currentStory.currentChoices.Count == 0 
            && Input.GetKeyDown(KeyCode.Space))
        {
            ContinueStory();
        }
    }

    public void EnterDialogueMode(TextAsset inkJSON)
    {
        //enter dialogue mode and get overlay
        currentStory = new Story(inkJSON.text);
        dialogueIsPlaying = true;
        dialoguePanel.SetActive(true);
        //defaults
        displayNameText.text = "Bob";
        portraitAnimator.Play("default");
        layoutAnimator.Play("right");
        ContinueStory();
    }

    private IEnumerator ExitDialogueMode()
    {

        yield return new WaitForSeconds(0.2f);

        dialogueIsPlaying = false;
        dialoguePanel.SetActive(false);
        dialogueText.text = "";
    }

    private void ContinueStory()
    {
        
        if (currentStory.canContinue)
        {
            if(displayTextCoroutine != null)
            {
                StopCoroutine(displayTextCoroutine);
            }
            displayTextCoroutine= StartCoroutine(DisplayText(currentStory.Continue()));
            DisplayChoices();
            //currentStory.BindExternalFunction("get_name", GetName);
            //handle tags
            HandleTags(currentStory.currentTags);
        }
        else
        {
            StartCoroutine(ExitDialogueMode());
        }
    }

    private void HandleTags(List<string> currentTags)
    {
        foreach (string tag in currentTags)
        {
            //handle tags from ink/ json
            //form type:value
            string[] splitTag = tag.Split(':');
            if (splitTag.Length != 2)
            {
                Debug.LogError("Tag could not be approipriatly parsed: " + tag);
            }
            //trim values of spaces
            string tagKey = splitTag[0].Trim();
            string tagValue = splitTag[1].Trim();

            switch (tagKey)
            {
                case SPEAKER_TAG:
                    displayNameText.text = tagValue;
                    break;
                case PORTRAIT_TAG:
                    portraitAnimator.Play(tagValue);
                    break;
                case LAYOUT_TAG:
                    layoutAnimator.Play(tagValue);
                    break;
                default:
                    Debug.LogWarning("Tag can currently not be handled" + tag);
                    break;
            }
        }
    }

    //typing effect
    private IEnumerator DisplayText(string line)
    {
        dialogueText.text = "";
        continueIcon.SetActive(false);
        canContinueToNextLine = false;

        bool isAddingRichTextTag = false;

        foreach (char letter in line.ToCharArray())
        {
            //skip typing effect
            if (Input.GetKeyDown(KeyCode.Space))
            {
                dialogueText.text = line;
                break;
            }

            //rich text handeling
            if(letter == '<' || isAddingRichTextTag)
            {
                isAddingRichTextTag = true;
                dialogueText.text += letter;
                if (letter == '>')
                {
                    isAddingRichTextTag = false;
                }
            }
            else 
            {
                dialogueText.text += letter;
                yield return new WaitForSeconds(typingSpeed);
            }
            
            
        }
        
        continueIcon.SetActive(true);
        canContinueToNextLine = true;
    }

    /// <summary>
    /// in UI choices List, set DialogueController in ChoiceX
    /// check DialogueController if everything is assigned
    /// Animators on PortraitImage and DialoguePanel
    /// </summary>
    private void DisplayChoices()
    {
        // always set supported choices! and assign choices to index
        // get ScrollView to work, multiple Choices can scroll with mouse and w/s 
        
        List<Choice> currentChoices = currentStory.currentChoices;
        if (currentChoices.Count > choices.Length)
        {
            Debug.LogError("More choices were given than the Ui supports." + currentChoices.Count);
        }

        int index = 0;
        foreach (Choice choice in currentChoices)
        {
            choices[index].gameObject.SetActive(true);
            choicesText[index].text = choice.text;
            index++;
        }
     
        for (int i = index; i < choices.Length; i++)
        {
            choices[i].gameObject.SetActive(false);
        }
        StartCoroutine(SelectFirstChoice());
    }


    private IEnumerator SelectFirstChoice()
    {
        //first choice must be null/ not assigned
        EventSystem.current.SetSelectedGameObject(null);
        yield return new WaitForEndOfFrame();
        EventSystem.current.SetSelectedGameObject(choices[0].gameObject);
    }
    public void MakeChoice(int choiceIndex)
    {
        if (canContinueToNextLine)
        {
            currentStory.ChooseChoiceIndex(choiceIndex);
            //why does Space not work?
            Input.GetKeyDown(KeyCode.Space);
            ContinueStory();
        }
        

    }

    //try to get player input 
    public string GetName()
    {
        inputField.gameObject.SetActive(true);
        inputField.onEndEdit.AddListener(delegate {
            inputField.gameObject.SetActive(false);
        });
        return inputField.text;
    }

    private IEnumerator waitForKeyPress(KeyCode key)
    {
        bool done = false;
        while (!done) // "while true", but with a bool to break out naturally
        {
            if (Input.GetKeyDown(key))
            {
                done = true; // breaks the loop
            }
            yield return null; // wait until next frame, then continue execution from here (loop continues)
        }
    }
}
