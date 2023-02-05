using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour
{

    [SerializeField] float speed, PowerFixator;
    float power = 0;
    //[SerializeField] Transform playerLocation;
    
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        movement();
        Shooting();
    }

    void movement()
    {
        float moveAmount = Input.GetAxis("Horizontal") * speed * Time.deltaTime;
        transform.Translate(moveAmount, 0, 0);
    }
    void Shooting()
    {
        
        if(Input.GetKey(KeyCode.Space) && power<10)
        {
            power = power + PowerFixator*Time.deltaTime;
        }
        if (!Input.GetKey(KeyCode.Space) && power>0)
        {
            power = power - 3*PowerFixator * Time.deltaTime;
        }
        if(power < 0) { power = 0; }
        if(power > 10) { power = 10; }
        Debug.Log(power);
    }
}
