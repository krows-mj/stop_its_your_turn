using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class button : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        Apagar();
    }

    // Update is called once per frame
    //void Update(){}

    public void Apagar(){
        gameObject.SetActive(false);
    }
}
