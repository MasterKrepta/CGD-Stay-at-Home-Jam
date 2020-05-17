using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class DialogSystem : MonoBehaviour
{


    
    List<string> transmissions = new List<string>();
    [SerializeField] GameObject dialogBox;
    [SerializeField] TMP_Text dialogText;
    [SerializeField] int index = -1;
    [SerializeField] float displayTime = 2;
    [SerializeField] float typingSpeed = .05f;
    private void Start()
    {
        dialogBox.SetActive(false);
        
        transmissions.Clear();

        
        transmissions.Add("Hey... Wake up");
        transmissions.Add("The Fairy Feast is starting soon");
        transmissions.Add("You need to find a way out");
        transmissions.Add("Face the dirt to eat your way through the maze");
        transmissions.Add("BREAK");

        transmissions.Add("Oh no.. i can sense danger");
        transmissions.Add("Make sure you stay hidden");
        transmissions.Add("Press SPACE to stun them so you can escape");
        transmissions.Add("Make sure you hide fast, as they wont stay stunned for long");
        transmissions.Add("BREAK");



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
        if (transmissions[index] == "BREAK")
        {
            dialogBox.SetActive(false);

            yield break;
        }
        foreach (char c in transmissions[index])
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
