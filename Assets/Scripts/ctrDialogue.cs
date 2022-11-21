using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ctrDialogue : MonoBehaviour
{
    [Header("Valores")]
    [SerializeField] private float tencion;
    [SerializeField] private float ganando;

    [Header("Control Dialogos")]
    [SerializeField] private GameObject panelDialogue;
    [SerializeField] private Text textAutor;
    [SerializeField] private Text textDialogue;
    [SerializeField] private float timeText;

    
    [System.Serializable]
    public struct CDialogue{
        public string autor;
        [TextArea(2,2)]public string dialogue;
    }
    [Header("Los dialogos")]
    [SerializeField] private CDialogue[] Dialogues;

    private CDialogue[] dialogueAux; //lo que se va a ejecutar
    private bool dialogueinit;
    private int lineDialogue;
    // Start is called before the first frame update
    void Start()
    {
        //StartDialogue();
        dialogueAux= Dialogues;   
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown("space") && dialogueinit){
            if(textDialogue.text == dialogueAux[lineDialogue].dialogue){
                NextDialogue();
            }else{
                StopAllCoroutines();
                textDialogue.text= dialogueAux[lineDialogue].dialogue;
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
        textAutor.text= dialogueAux[lineDialogue].autor;
        foreach(char c in dialogueAux[lineDialogue].dialogue){
            textDialogue.text += c;
            yield return new WaitForSeconds(timeText);
        }
    }
    private void NextDialogue(){
        lineDialogue++;
        if(lineDialogue < dialogueAux.Length){
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

    private void ControlDialogo(){
        //ayuda xD 
    }
}
