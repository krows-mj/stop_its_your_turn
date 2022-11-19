using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Menu : MonoBehaviour
{
    [SerializeField] private GameObject Menuss;
    // Start is called before the first frame update
    void Start()
    {
        OnMenu();  
    }

    // Update is called once per frame
    //void Update(){}
    public void OnMenu(){
        Menuss.SetActive(true);
    }
    public void offMenu(){
        Menuss.SetActive(false);
    }
    public void ExitGame(){
        Application.Quit();
    }
}
