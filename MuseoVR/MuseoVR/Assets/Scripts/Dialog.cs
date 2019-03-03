using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(AudioSource))]
public class Dialog : MonoBehaviour {

    [SerializeField]
    string Title;
    [SerializeField]
    string Description;
    [SerializeField]
    string Character;

    [SerializeField]
    int Year;

    [SerializeField]
    GameObject DialogBox;

    //Texto del canvas
    private Text Title_Edit;
    private Text Year_Edit;
    private Text Description_Edit;
    private Text Character_Edit;

    //Escritura de texto
    public float Delay = 0.1f;
    private string currentText = "";
    Coroutine lastRoutine = null;

    //Reproduccion de audio
    private AudioSource audioData;

    void Start()
    {
        audioData = GetComponent<AudioSource>();
    }

    private void OnTriggerEnter(Collider other)
    {
        DialogBox.transform.Find("Title").GetComponent<Text>().text = Title;
        DialogBox.transform.Find("Year").GetComponent<Text>().text = Year.ToString();
        DialogBox.transform.Find("Character").GetComponent<Text>().text = Character;

        if (other.tag == "Hand")
        {
            DialogBox.SetActive(true);
            lastRoutine = StartCoroutine(DrawText());
            audioData.Play();
        }
    }

    private void OnTriggerExit(Collider other)
    {
        audioData.Stop();
        HideDialogBox();
        StopCoroutine(lastRoutine);
        currentText = "";
        DialogBox.transform.Find("Description").GetComponent<Text>().text = "";
    }

    IEnumerator DrawText()
    {
        for (int i = 0; i < Description.Length; i++)
        {
            currentText = Description.Substring(0, i);
            DialogBox.transform.Find("Description").GetComponent<Text>().text = currentText;
            yield return new WaitForSeconds(Delay);         
        }
    }


    void HideDialogBox()
    {
        DialogBox.SetActive(false);
    }

}
