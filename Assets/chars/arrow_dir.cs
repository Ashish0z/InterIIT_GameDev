using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class arrow_dir : MonoBehaviour
{   
    public Transform bone;
    GameObject player;
    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
        // bone = GetComponent<Transform>().Find("target");
    }

    // Update is called once per frame
    void Update()
    {
        //Vector3 mousepos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        Vector3 playerPos = player.transform.position;
        playerPos.z = 0;
        //mousepos.z=0;
        //Debug.Log(mousepos);
        bone.position=playerPos;
    }
}
