using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class NewBehaviourScript : MonoBehaviour {

    private Rigidbody rd;

    public int force = 5;

    private int score = 0;

    public Text text;

    public GameObject wintext;

	// Use this for initialization
	void Start () {

        rd = GetComponent<Rigidbody>();
        text.text = score.ToString();

	}
	
	// Update is called once per frame
	void Update () {
        float h = Input.GetAxis("Horizontal");
        float v = Input.GetAxis("Vertical");
        rd.AddForce(new Vector3(h,0,v)*force);//给X轴施加一个力
	}

    //碰撞检测
    void OnCollisionEnter(Collision collision){

        // collision.collider;//获得碰撞到的游戏物体身上的Collider组件
       // string name = collision.collider.name;
        //print(name);
        if(collision.collider.tag == "pickup")
        {
            Destroy(collision.collider.gameObject);
        }
    }


     void OnTriggerEnter(Collider other)
    {
        if(other.tag == "pickup")
        {
            score++;
            text.text = score.ToString();
            print(score);
            Destroy(other.gameObject);
            if(score == 11)
            {
                wintext.SetActive(true);
            }
        }
    }


}
