using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class EndGame : MonoBehaviour
{

    List<string> dialog = new List<string>();
    [SerializeField] GameObject dialogBox;
    [SerializeField] TMP_Text dialogText;
    [SerializeField] int index;
    [SerializeField] float displayTime = 2;
    [SerializeField] float typingSpeed = .05f;
    Transform player;


    private void Start()
    {
        player = FindObjectOfType<PlayerMovement>().transform;
        dialogBox.SetActive(false);

        dialog.Clear();

        PopulateEnding();

    }

    private void PopulateEnding()
    {
        dialog.Add("You Finally made it");
        dialog.Add("We were about to start without you");
        dialog.Add("There is so much food here, you wont go hungry");
        dialog.Add("BREAK");

        dialog.Add("Oh thank you.. but... but... i'm.... Full!!!!");

        dialog.Add("BREAK");

        

    }


    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            DisablePlayerControl();
            StartStory();
        }
    }
    void DisablePlayerControl()
    {
        MonoBehaviour[] scripts = player.GetComponents<MonoBehaviour>();

        foreach (var s in scripts)
        {
            s.enabled = false;
        }
    }

    void StartStory()
    {

        GetNextLine();
    }
    public void GetNextLine()
    {

        index++;

        StartCoroutine(ShowText());
    }

    IEnumerator ShowText()
    {

        if (index >= dialog.Count)
        {
            print("END OF TUTORIAL");
            dialogBox.SetActive(false);
            yield break;
        }

        dialogText.text = "";

        if (dialog[index] == "BREAK")
        {
            dialogBox.SetActive(false);

            yield break;
        }

        dialogBox.SetActive(true);
        yield return new WaitForSeconds(1f);

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
        if (Input.GetKeyDown(KeyCode.Return))
        {
            DisablePlayerControl();
            StartStory();
        }
    }

}
