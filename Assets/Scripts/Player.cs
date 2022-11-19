using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    [SerializeField] private float speedX, speedY;
    [SerializeField] private bool mouse;
    private float horizontal, vertical;
    // Start is called before the first frame update
    void Start()
    {
        mouse= true;
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown("r")){
            mouse= !mouse;
        }
        if(mouse){
            horizontal += speedX * Input.GetAxis("Mouse X");
            vertical -= speedY * Input.GetAxis("Mouse Y");
            transform.eulerAngles = new Vector3(vertical, horizontal, 0.0f);
        }
    }
}
