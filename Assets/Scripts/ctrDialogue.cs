using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ctrDialogue : MonoBehaviour
{
    [SerializeField] private GameObject panelDialogue;
    [SerializeField] private Text textAutor;
    [SerializeField] private Text textDialogue;
    [SerializeField] private float timeText;

    [System.Serializable]
    public struct CDialogue{
        public string autor;
        [TextArea(2,2)]public string dialogue;
    }
    [SerializeField] private CDialogue[] Dialogues;

    [SerializeField] private bool dialogueinit;
    [SerializeField] private int lineDialogue;
    // Start is called before the first frame update
    void Start()
    {
        //StartDialogue();   
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown("space") && dialogueinit){
            if(textDialogue.text == Dialogues[lineDialogue].dialogue){
                NextDialogue();
            }else{
                StopAllCoroutines();
                textDialogue.text= Dialogues[lineDialogue].dialogue;
            }
        }
    }

    [ContextMenu("StartDialogue")]
    public void StartDialogue(){
        onPanel();
        dialogueinit= true;
        lineDialogue= 0;
        StartCoroutine(ShowLine());
    }
    private IEnumerator ShowLine(){
        textDialogue.text= string.Empty;
        textAutor.text= Dialogues[lineDialogue].autor;
        foreach(char c in Dialogues[lineDialogue].dialogue){
            textDialogue.text += c;
            yield return new WaitForSeconds(timeText);
        }
    }
    private void NextDialogue(){
        lineDialogue++;
        if(lineDialogue < Dialogues.Length){
            StartCoroutine(ShowLine());
        }else{
            offPanel();
        }
    }

    private void onPanel(){
        panelDialogue.SetActive(true);
    }
    private void offPanel(){
        dialogueinit= false;
        textAutor.text= string.Empty;
        textDialogue.text= string.Empty;
        panelDialogue.SetActive(false);
    }
}
