using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class DialogSystem : MonoBehaviour
{


    
    List<string> dialog = new List<string>();
    [SerializeField] GameObject dialogBox;
    [SerializeField] TMP_Text dialogText;
    [SerializeField] int index = -1;
    [SerializeField] float displayTime = 2;
    [SerializeField] float typingSpeed = .05f;
    private void Start()
    {
        dialogBox.SetActive(false);
        
        dialog.Clear();

        
        dialog.Add("Hey... Wake up");
        dialog.Add("The Fairy Feast is starting soon");
        dialog.Add("You need to find a way out");
        dialog.Add("Face the dirt to eat your way through the maze");
        dialog.Add("BREAK");

        dialog.Add("Oh no.. i can sense danger");
        dialog.Add("Make sure you stay hidden");
        dialog.Add("Press SPACE to stun them so you can escape");
        dialog.Add("Make sure you hide fast, as they wont stay stunned for long");
        dialog.Add("BREAK");



        //TODO display end game scene here. 
    }

    public void GetNextLine()
    {

        index++;
        dialogBox.SetActive(true);
        StartCoroutine(ShowText());
    }

    IEnumerator ShowText()
    {
        yield return new WaitForSeconds(1f);
        dialogText.text = "";
        if (dialog[index] == "BREAK")
        {
            dialogBox.SetActive(false);

            yield break;
        }
        foreach (char c in dialog[index])
        {
            yield return new WaitForSeconds(typingSpeed);
            dialogText.text += c;
        }
        yield return new WaitForSeconds(displayTime);
        GetNextLine();
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.T))
        {
            GetNextLine();
        }
    }
}
