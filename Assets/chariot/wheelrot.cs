using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class wheelrot : MonoBehaviour
{
    private Vector3 prevPos;
    private Transform armature;
    public Transform pivot;
    private Transform wheelF;
    private Transform wheelB;
    bool facingLeft = true;

    // Start is called before the first frame update
    void Start()
    {
        armature = GetComponent<Transform>().Find("Armature/root");
        wheelF = GetComponent<Transform>().Find("Armature/root/wheelF");
        wheelB = GetComponent<Transform>().Find("Armature/root/wheelB");
        prevPos = transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        float dist_moved = transform.position.x-prevPos.x;
        // if(dist_moved<-0.01 && !facingLeft)
        // {
        //     facingLeft=true;
        //     // armature.localEulerAngles = new Vector3(0f,0f,0f);
        //     // armature.position = new Vector3(pivot.position.x, armature.position.y, armature.position.z);
        //     armature.RotateAround(pivot.position, Vector3.up, 180f);
        // }
        // else if(dist_moved>0.01 && facingLeft)
        // {
        //     facingLeft=false;
        //     // armature.localEulerAngles = new Vector3(0f,180f,0f);
        //     // armature.position = new Vector3(pivot.position.x, armature.position.y, armature.position.z);;
        //     armature.RotateAround(pivot.position, Vector3.up, 180f);
        // }

        float radius = 1/wheelF.lossyScale.x;
        // Debug.Log("radius:"+ radius);
        // Debug.Log("dist:"+dist_moved);
        wheelF.RotateAround(wheelF.position, wheelF.forward, 0.04f*(28.64789f)*Mathf.Abs(dist_moved)/radius);
        // Debug.Log("rot_deg:"+((28.64789f)*Mathf.Abs(dist_moved)/radius));
        radius = 1/wheelB.lossyScale.x;
        wheelB.RotateAround(wheelB.position, wheelB.forward, 0.04f*(28.64789f)*Mathf.Abs(dist_moved)/radius);
                



        prevPos = transform.position;
    }
}
