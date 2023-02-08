using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class aim_ctrl : MonoBehaviour
{
    private Transform target;
    private Transform uparml;
    private Transform armature;

    // Start is called before the first frame update
    void Start()
    {
        target = GetComponent<Transform>().Find("target");
        armature = GetComponent<Transform>().Find("Armature/Root");
        uparml = GetComponent<Transform>().Find("Armature/Root/spine_1/spine_2/spine_3/torso/upperarm_L");
    }

    // Update is called once per frame
    void Update()
    {
        //set 
        Vector3 screenPosition = new Vector3(Input.mousePosition.x, Input.mousePosition.y, 0);
        Vector3 worldPosition = Camera.main.ScreenToWorldPoint(screenPosition);
        worldPosition.z=0;
        // Debug.Log(worldPosition);
        if(worldPosition.x>transform.position.x)
        {
            armature.localEulerAngles= new Vector3(0f,180f,0f);
            Vector3 dir = worldPosition-uparml.position;
            uparml.up=dir;
            uparml.RotateAround(uparml.position, uparml.up, -90f);
        }
        else
        {
            armature.localEulerAngles=new Vector3(0f,0f,0f);
            Vector3 dir = worldPosition-uparml.position;
            uparml.up=dir;
            uparml.RotateAround(uparml.position, uparml.up, 90f);
        }

    }
}
