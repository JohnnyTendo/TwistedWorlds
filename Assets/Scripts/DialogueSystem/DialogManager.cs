using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DialogManager : MonoBehaviour
{
    #region Singleton

    public static DialogManager instance;

    void Awake()
    {
        instance = this;
        //Time.timeScale = 1;
    }
    #endregion

    public GameObject dialogBox;
    public Animator animator;
    Text messageText;
    Text messageTitle;
    bool dialogIsActive;
    Queue<string> messages;

    private void Start()
    {
        messages = new Queue<string>();
        for (int i = 0; i < dialogBox.transform.childCount - 1; i++)
        {
            if (dialogBox.transform.GetChild(i).transform.name == "MessageTitle")
            {
                messageTitle = dialogBox.transform.GetChild(i).transform.GetComponent<Text>();
            }
        }
        for (int i = 0; i < dialogBox.transform.childCount - 1; i++)
        {
            if (dialogBox.transform.GetChild(i).transform.name == "MessageText")
            {
                messageText = dialogBox.transform.GetChild(i).transform.GetComponent<Text>();
            }
        }
    }

    private void Update()
    {
        if (dialogIsActive)
        {
            if (Input.GetKeyDown("space"))
            {
                DisplayNextMessage();
            }
        }
    }

    public void StartDialog(Dialog dialogue)
    {
        messageTitle.text = dialogue.title;
        dialogIsActive = true;
        //Time.timeScale = 0;
        messages.Clear();

        foreach (string message in dialogue.messages)
        {
            messages.Enqueue(message);
        }
        DisplayNextMessage();
    }

    public void DisplayNextMessage()
    {
        animator.SetBool("isOpen", true);
        if (messages.Count == 0)
        {
            EndDialog();
            return;
        }

        string message = messages.Dequeue();
        StopAllCoroutines();
        StartCoroutine(TypeMessage(message));

    }

    System.Collections.IEnumerator TypeMessage(string message)
    {
        messageText.text = "";
        foreach (char letter in message.ToCharArray())
        {
            messageText.text += letter;
            yield return null;
        }
    }

    public void EndDialog()
    {
        animator.SetBool("isOpen", false);
        dialogIsActive = false;
        //Time.timeScale = 1;
    }
}
