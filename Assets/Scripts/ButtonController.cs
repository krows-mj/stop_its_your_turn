using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButtonController : MonoBehaviour
{
    private Animator anim;
    [SerializeField] private string Option1;
    [SerializeField] private string Option2;

    private GameObject Op1Obj;
    private Animator Op1Anim;
    private GameObject Op2Obj;
    private Animator Op2Anim;

    private void Awake(){
        Op1Obj= transform.GetChild(0).gameObject;
        Op2Obj= transform.GetChild(1).gameObject;
        Op1Anim= Op1Obj.GetComponent<Animator>();
        Op2Anim= Op2Obj.GetComponent<Animator>();
    }
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    //void Update(){}

    public void MostrarOpciones(){
        onButton();
        //Op1Anim.SetTrigger("act");
        //Op2Anim.SetTrigger("act");
    }
    public void OcultarOpciones(){
        Op1Anim.SetTrigger("act");
        Op2Anim.SetTrigger("act");
        offButon();
    }

    public string getOption1(){
        return Option1;
    }
    public void setOption1(string resp){
        Option1= resp;
    }
    public string getOption2(){
        return Option2;
    }
    public void setOption2(string resp){
        Option2= resp;
    }
    public void offButon(){
        Op1Obj.SetActive(false);
        Op2Obj.SetActive(false);
    }
    public void onButton(){
        Op1Obj.SetActive(true);
        Op2Obj.SetActive(true);
    }


}
