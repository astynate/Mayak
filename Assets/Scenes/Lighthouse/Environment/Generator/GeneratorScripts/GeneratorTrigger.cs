using System;
using UnityEngine;

public class GeneratorTrigger : MonoBehaviour
{

    public Canvas canvas;
    public Canvas canvas1;
    private bool isWorked = true;
    private float workTime ;
    private int start;



    // Start is called before the first frame update
    void Start()
    {
        System.Random random = new System.Random();
        workTime = random.Next(10, 30);
        start = Environment.TickCount;
        Debug.Log($"{workTime}");
    }

    // Update is called once per frame
    void Update()
    {
        int end = Environment.TickCount;
        if ((end - start) / 1000 > workTime)
        {
            Debug.Log("Время вышло");
            isWorked = false;
        } 
        
       
 
        if (canvas.enabled == true && Input.GetKey(KeyCode.E))
        {
            canvas.enabled = false;
            canvas1.enabled = true;
        }

        if (canvas1.enabled == true && Input.GetKey(KeyCode.Escape))
        {
            canvas.enabled = false;
            canvas1.enabled = false;
        }

    }

    public void OnTriggerEnter(Collider other) => canvas.enabled = true; 
    
    public void OnTriggerExit(Collider other) => canvas.enabled = false; 
    
}
