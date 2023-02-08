using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class horse_flip : MonoBehaviour
{
    private Vector3 prevPos;

    public Transform pivot;
    bool facingLeft = true;

    // Start is called before the first frame update
    void Start()
    {
        prevPos = transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        float dist_moved = transform.position.x-prevPos.x;
        Debug.Log(dist_moved);
        if(dist_moved<-0.0001 && !facingLeft)
        {
            facingLeft=true;
            // armature.localEulerAngles = new Vector3(0f,0f,0f);
            // armature.position = new Vector3(pivot.position.x, armature.position.y, armature.position.z);
            transform.RotateAround(pivot.position, Vector3.up, 180f);
        }
        else if(dist_moved>0.0001 && facingLeft)
        {
            facingLeft=false;
            // armature.localEulerAngles = new Vector3(0f,180f,0f);
            // armature.position = new Vector3(pivot.position.x, armature.position.y, armature.position.z);;
            transform.RotateAround(pivot.position, Vector3.up, 180f);
        }
        prevPos = transform.position;
    }
}
