using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class DialogSystem : MonoBehaviour
{


    
    List<string> dialog = new List<string>();
    [SerializeField] GameObject dialogBox;
    [SerializeField] TMP_Text dialogText;
    [SerializeField] int index;
    [SerializeField] float displayTime = 2;
    [SerializeField] float typingSpeed = .05f;
    [SerializeField] AudioClip[] clips;
    AudioSource source;


    private void Start()
    {
        source = GetComponent<AudioSource>();
        dialogBox.SetActive(false);

        dialog.Clear();

        PopulateStory();

        StartStory();

    }

    private void PopulateStory()
    {
        dialog.Add("Hey... Wake up");
        dialog.Add("The Fairy Feast is starting soon");
        dialog.Add("You need to find a way out: (Move with WASD)");
        dialog.Add("Face the dirt to eat your way through the maze");
        dialog.Add("BREAK");

        dialog.Add("Oh no.. i can sense danger");
        dialog.Add("Make sure you stay hidden");
        dialog.Add("Press SPACE to stun them so you can escape");
        dialog.Add("Make sure you hide fast, as they wont stay stunned for long");
        dialog.Add("BREAK");

        //TODO display end game scene here. 
        
    }


    void StartStory()
    {
      
    
        GetNextLine();
    }

    void PlayAudio()
    {
        source.clip = clips[UnityEngine.Random.Range(0, clips.Length)];
        source.Play();
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
        Invoke("PlayAudio", 1f);
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

    //private void Update()
    //{

    //    if (Input.GetKeyDown(KeyCode.T))
    //    {
    //        GetNextLine();
    //    }
    //}

 
}
