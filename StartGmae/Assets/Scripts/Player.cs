using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour {

    public float acce = 10f;
    public float jumpHieght = 0f;
    public float gavity = -9.8f;
    private bool jump = false;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        Vector3 now = transform.position;
        if (jump)
        {
            if (now.y < jumpHieght)
            {
                transform.position =(new Vector3(0, now.y + acce, now.z));
            }
            else
            {
                jump = false;
            }
            
        }
        else
        {
                if (now.y <= -9.5)
                {
                    jump = true;
                }
                else
                {
                transform.position=(new Vector3(0, now.y + gavity, now.z));
            }
        }
        
      
	}
}
