using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.SceneManagement;

public class ctrDialogue : MonoBehaviour
{
    [Header("Valores")]
    [SerializeField] private float tension;
    [SerializeField] private float ganando;

    [Header("Control Dialogos")]
    [SerializeField] private GameObject panelDialogue;
    [SerializeField] private TMP_Text textAutor;
    [SerializeField] private TMP_Text textDialogue;
    [SerializeField] private Image burbuja;
    [SerializeField] private float timeText;

    [Header("Auxiliar")]
    [SerializeField] private Sprite BurbujaDefault;
    [SerializeField] private ButtonController ctrbutton;
    [SerializeField] private TMP_Text option1;
    [SerializeField] private TMP_Text option2;
    [SerializeField] private GameObject PanelFin;
    //[SerializeField] private Sprite burbujaP;
    //[SerializeField] private Sprite burbujaC;
    private bool fin;
    private bool ElInterludio;
    
    [System.Serializable]
    public struct CDialogue{
        public string autor;
        [TextArea(2,2)]public string dialogue;
    }
    [Header("Los dialogos")]
    [SerializeField] private CDialogue[] Dialogues;
    //Conversaciones
    [SerializeField] private CDialogue[] A;
    [SerializeField] private CDialogue[] AA;
    [SerializeField] private CDialogue[] AAA;
    [SerializeField] private CDialogue[] AAAA;
    [SerializeField] private CDialogue[] AAAB;
    [SerializeField] private CDialogue[] AAB;
    [SerializeField] private CDialogue[] AABB;
    [SerializeField] private CDialogue[] AABBA;
    [SerializeField] private CDialogue[] AABBB;
    [SerializeField] private CDialogue[] AB;
    [SerializeField] private CDialogue[] ABA;
    [SerializeField] private CDialogue[] ABAA;
    [SerializeField] private CDialogue[] ABAB;
    [SerializeField] private CDialogue[] ABB;
    [SerializeField] private CDialogue[] ABBA;
    [SerializeField] private CDialogue[] ABBB;
    [SerializeField] private CDialogue[] B;
    [SerializeField] private CDialogue[] BA;
    [SerializeField] private CDialogue[] BAA;
    [SerializeField] private CDialogue[] BAAA;
    [SerializeField] private CDialogue[] BAAB;
    [SerializeField] private CDialogue[] BAB;
    [SerializeField] private CDialogue[] BABA;
    [SerializeField] private CDialogue[] BABB;
    [SerializeField] private CDialogue[] BB;
    [SerializeField] private CDialogue[] BBA;
    [SerializeField] private CDialogue[] BBAA;
    [SerializeField] private CDialogue[] BBAB;
    [SerializeField] private CDialogue[] BBB;
    [SerializeField] private CDialogue[] BBBA;
    [SerializeField] private CDialogue[] BBBB;
    [SerializeField] private CDialogue[] IA;
    [SerializeField] private CDialogue[] IB;
    [SerializeField] private CDialogue[] IC;

    //Fin variables de conversaciones

    private CDialogue[] dialogueAux; //lo que se va a ejecutar
    private bool dialogueinit;
    private int lineDialogue;
    // Start is called before the first frame update
    void Start()
    {
        PanelFin.SetActive(false);
        ElInterludio= false;
        fin= false;
        //StartDialogue();
        tension= 50;
        ganando= 50;
        dialogueAux= Dialogues;
        ctrbutton.setOption1("A");
        ctrbutton.setOption2("B");
        option1.text= "Quiero. Fue tu culpa.";
        option2.text= "No quiero. No se puede todo.";
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
        //burbuja.sprite= (dialogueAux[lineDialogue].burbujaText != null)? dialogueAux[lineDialogue].burbujaText: BurbujaDefault;
        if(dialogueAux[lineDialogue].autor =="C:"){
            textAutor.text= "Contrincante";
            //burbuja.sprite= burbujaC; 
        }else{
            textAutor.text= "Protagonista";
            //burbuja.sprite= burbujaP;
        }
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
        //textAutor.text= string.Empty;
        //textDialogue.text= string.Empty;
        //panelDialogue.SetActive(false);
        if(fin == false){    
            ctrbutton.MostrarOpciones();
        }else{
            PanelFin.SetActive(true);
        }
        if(ElInterludio){
            Interludio();
        }
    }

    public void ControlDialogo(string cod){
        cod=(cod=="D1")? ctrbutton.getOption1(): ctrbutton.getOption2();
        switch (cod){
            case "A":
                PartidaA();
                break;
            case "AA":
                PartidaAA();
                break;
            case "AAA":
                PartidaAAA();
                break;
            case "AAAA":
                PartidaAAAA();
                break;
            case "AAAB":
                PartidaAAAB();
                break;
            case "AAB":
                PartidaAAB();
                break;
            case "AABB":
                PartidaAABB();
                break;
            case "AABBA":
                PartidaAABBA();
                break;
            case "AABBB":
                PartidaAABBB();
                break;
            case "AB":
                PartidaAB();
                break;
            case "ABA":
                PartidaABA();
                break;
            case "ABAA":
                PartidaABAA();
                break;
            case "ABAB":
                PartidaABAB();
                break;
            case "ABB":
                PartidaABB();
                break;
            case "ABBA":
                PartidaABBA();
                break;
            case "ABBB":
                PartidaABBB();
                break;
            case "B":
                PartidaB();
                break;
            case "BA":
                PartidaBA();
                break;
            case "BAA":
                PartidaBAA();
                break;
            case "BAAA":
                PartidaBAAA();
                break;
            case "BAAB":
                PartidaBAAB();
                break;
            case "BAB":
                PartidaBAB();
                break;
            case "BABA":
                PartidaBABA();
                break;
            case "BABB":
                PartidaBABB();
                break;
            case "BB":
                PartidaBB();
                break;
            case "BBA":
                PartidaBBA();
                break;
            case "BBAA":
                PartidaBBAA();
                break;
            case "BBAB":
                PartidaBBAB();
                break;
            case "BBB":
                PartidaBBB();
                break;
            case "BBBA":
                PartidaBBBA();
                break;
            case "BBBB":
                PartidaBBBB();
                break;
            case "INTERLUDIO":
                Interludio();
                break;
            default:
                Debug.Log("Error en la partida");
                break;
        } 
    }

    private void PartidaA(){
        //Envio de datos
        tension += 5;
        ganando -= 10; 
        dialogueAux= A;
        ctrbutton.setOption1("AA");
        ctrbutton.setOption2("AB");
        option1.text= "Tomá.";
        option2.text= "Disculpame.";
        //Secuencia
    }
    private void PartidaAA(){
        //Envio de datos
        tension += 5;
        ganando += 0; 
        dialogueAux= AA;
        ctrbutton.setOption1("AAA");
        ctrbutton.setOption2("AAB");
        option1.text= "Quiero... ver lo que tenés.";
        option2.text= "No se quiere.";
        //Secuencia
    }
    private void PartidaAAA(){
        //Envio de datos
        tension += 5;
        ganando += 0; 
        dialogueAux= AAA;
        ctrbutton.setOption1("AAAA");
        ctrbutton.setOption2("AAAB");
        option1.text= "...Perdí. Juguemos otra.";
        option2.text= "...Nunca dije que quería el truco. Dije que quería ver lo que tenés.";
        //Secuencia
    }
    private void PartidaAAAA(){
        //Envio de datos
        tension -= 15;
        ganando -= 10; 
        dialogueAux= AAAA;
        // PRIMER INTERLUDIO
        ElInterludio= true;
    }
    private void PartidaAAAB(){
        //Envio de datos
        tension += 10;
        ganando -= 10; 
        dialogueAux= AAAB;
        // PRIMER INTERLUDIO
        ElInterludio= true;
    }
    private void PartidaAAB(){
        //Envio de datos
        tension += 0;
        ganando -= 5; 
        dialogueAux= AAB;
        ctrbutton.setOption1("INTERLUDIO");
        ctrbutton.setOption2("AABB");
        option1.text= "Ok.";
        option2.text= "No mostraste el envido.";
        //Secuencia
    }
    private void PartidaAABB(){
        //Envio de datos
        tension += 0;
        ganando += 0; 
        dialogueAux= AABB;
        ctrbutton.setOption1("AABBA");
        ctrbutton.setOption2("AABBB");
        option1.text= "No, no mostraste el envido, tenías que hacerlo.";
        option2.text= "Sí, ya pasó.";
        //Secuencia
    }
    private void PartidaAABBA(){
        //Envio de datos
        tension += 10;
        ganando += 10; 
        dialogueAux= AABBA;
        // PRIMER INTERLUDIO
        ElInterludio= true;
    }
    private void PartidaAABBB(){
        //Envio de datos
        tension -= 15;
        ganando += 0; 
        dialogueAux= AABBB;
        // PRIMER INTERLUDIO
        ElInterludio= true;
    }
    private void PartidaAB(){
        //Envio de datos
        tension -= 10;
        ganando += 0; 
        dialogueAux= AB;
        ctrbutton.setOption1("ABA");
        ctrbutton.setOption2("ABB");
        option1.text= "Sí... Sólo un juego...";
        option2.text= "Más vale que es un juego para vos.";
        //Secuencia
    }
    private void PartidaABA(){
        //Envio de datos
        tension += 0;
        ganando -= 5; 
        dialogueAux= ABA;
        ctrbutton.setOption1("ABAA");
        ctrbutton.setOption2("ABAB");
        option1.text= "Juegos... ¿por qué dejamos de hacerlos?";
        option2.text= "Juegos... Bah. Todo es una basura.";
        //Secuencia
    }
    private void PartidaABAA(){
        //Envio de datos
        tension -= 10;
        ganando -= 0; 
        dialogueAux= ABAA;
        // PRIMER INTERLUDIO
        ElInterludio= true;
    }
    private void PartidaABAB(){
        //Envio de datos
        tension += 5;
        ganando += 0; 
        dialogueAux= ABAB;
        // PRIMER INTERLUDIO
        ElInterludio= true;
    }
    private void PartidaABB(){
        //Envio de datos
        tension += 5;
        ganando -= 5; 
        dialogueAux= AAB;
        ctrbutton.setOption1("ABBA");
        ctrbutton.setOption2("ABBB");
        option1.text= "Tenés razón. Me tengo que calmar...";
        option2.text= "¡No! ¡Ya estoy podrido de tus ‘calmémonos’!";
        //Secuencia
    }
    private void PartidaABBA(){
        //Envio de datos
        tension -= 10;
        ganando -= 0; 
        dialogueAux= ABBA;
        // PRIMER INTERLUDIO
        ElInterludio= true;
    }
    private void PartidaABBB(){
        //Envio de datos
        tension += 15;
        ganando += 0; 
        dialogueAux= ABBB;
        // PRIMER INTERLUDIO
        ElInterludio= true;
    }
    private void PartidaB(){
        //Envio de datos
        tension -= 5;
        ganando -= 5; 
        dialogueAux= B;
        ctrbutton.setOption1("BA");
        ctrbutton.setOption2("BB");
        option1.text= "¿Qué opinás de esto?";
        option2.text= "Y sí...";
        //Secuencia
    }
    private void PartidaBA(){
        //Envio de datos
        tension -= 0;
        ganando -= 0; 
        dialogueAux= BA;
        ctrbutton.setOption1("BAA");
        ctrbutton.setOption2("BAB");
        option1.text= "Truco... si tenés las agallas.";
        option2.text= "Es sólo un juego.";
        //Secuencia
    }
    private void PartidaBAA(){
        //Envio de datos
        tension += 5;
        ganando += 5; 
        dialogueAux= BAA;
        ctrbutton.setOption1("BAAA");
        ctrbutton.setOption2("BAAB");
        option1.text= "Facilita me la dejaste, ¿eh?";
        option2.text= "Gallina. Cómo siempre.";
        //Secuencia
    }
    private void PartidaBAAA(){
        //Envio de datos
        tension -= 10;
        ganando += 0; 
        dialogueAux= BAAA;
        // PRIMER INTERLUDIO
        ElInterludio= true;
    }
    private void PartidaBAAB(){
        //Envio de datos
        tension += 10;
        ganando += 0; 
        dialogueAux= BAAB;
        // PRIMER INTERLUDIO
        ElInterludio= true;
    }
    private void PartidaBAB(){
        //Envio de datos
        tension -= 5;
        ganando += 0; 
        dialogueAux= BAB;
        ctrbutton.setOption1("BABA");
        ctrbutton.setOption2("BABB");
        option1.text= "Obvio, un juego entre compas.";
        option2.text= "Sí, es un juego. Un juego de mierda.";
        //Secuencia
    }
    private void PartidaBABA(){
        //Envio de datos
        tension -= 10;
        ganando -= 5; 
        dialogueAux= BABA;
        // PRIMER INTERLUDIO
        ElInterludio= true;
    }
    private void PartidaBABB(){
        //Envio de datos
        tension += 15;
        ganando -= 5; 
        dialogueAux= BABB;
        // PRIMER INTERLUDIO
        ElInterludio= true;
    }
    private void PartidaBB(){
        //Envio de datos
        tension -= 5;
        ganando += 0; 
        dialogueAux= BB;
        ctrbutton.setOption1("BBA");
        ctrbutton.setOption2("BBB");
        option1.text= "Opino que te vayas a cagar.";
        option2.text= "Truco.";
        //Secuencia
    }
    private void PartidaBBA(){
        //Envio de datos
        tension += 10;
        ganando -= 5; 
        dialogueAux= BBA;
        // PRIMER INTERLUDIO
        ElInterludio= true;     
    }
    private void PartidaBBAA(){
        //Envio de datos
        tension -= 10;
        ganando += 0; 
        dialogueAux= BBAA;
        // PRIMER INTERLUDIO
        ElInterludio= true; 
    }
    private void PartidaBBAB(){
        //Envio de datos
        tension += 20;
        ganando += 0; 
        dialogueAux= BBAB;
        // PRIMER INTERLUDIO
        ElInterludio= true;
    }
    private void PartidaBBB(){
        //Envio de datos
        tension += 0;
        ganando += 5; 
        dialogueAux= BBB;
        ctrbutton.setOption1("BBBA");
        ctrbutton.setOption2("BBBB");
        option1.text= "No pensé que caerías, ja.";
        option2.text= "Pero, che. Si no te la jugás, no ganás.";
        //Secuencia
    }
    private void PartidaBBBA(){
        //Envio de datos
        tension -= 5;
        ganando += 0; 
        dialogueAux= BBBA;
        // PRIMER INTERLUDIO
        ElInterludio= true;
    }
    private void PartidaBBBB(){
        //Envio de datos
        tension += 0;
        ganando += 5; 
        dialogueAux= BBBB;
        // PRIMER INTERLUDIO
        ElInterludio= true;
    }
    private void Interludio(){
        fin= true;
        ElInterludio= false;
        if(tension >= 50){
            dialogueAux= IA;
        }else{
            if(tension <= 40){
                dialogueAux= IB;
            }else{
                dialogueAux= IC;
            }
        }
    }

    [ContextMenu("Reiniciar")]
    public void Reiniciar(){
        //Debug.Log(SceneManager.GetActiveScene().name);
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    public void Salir(){
        Application.Quit();
    }
}
