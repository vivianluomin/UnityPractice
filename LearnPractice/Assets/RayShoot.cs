using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RayShoot : MonoBehaviour {

    private Camera camera;

	// Use this for initialization
	void Start () {
        camera = GetComponent<Camera>();//访问相同对象上附加的其他组件
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
	}

    void OnGUI()
    {
        int size = 12;
        float posX = camera.pixelWidth / 2 - size / 4;
        float posY = camera.pixelHeight / 2 - size / 2;
        GUI.Label(new Rect(posX, posY, size, size), "*");
    }
	
	// Update is called once per frame
	void Update () {
        if (Input.GetMouseButtonDown(0))
        {
            Vector3 ponit = new Vector3(camera.pixelWidth / 2, camera.pixelHeight / 2, 0);
            Ray ray = camera.ScreenPointToRay(ponit);
            RaycastHit hit;
            if(Physics.Raycast(ray,out hit))
            {
                Debug.Log("Hit " + hit.point);
                GameObject hitOject = hit.transform.gameObject;
                ReactiveTarget target = hitOject.GetComponent<ReactiveTarget>();
                if (target != null)
                {
                    target.ReactHit();
                }
                else
                {
                    StartCoroutine(SphereIndicator(hit.point));
                }   
               
                
            }
        }
	}

    private IEnumerator SphereIndicator(Vector3 pos)
    {
        GameObject sphere = GameObject.CreatePrimitive(PrimitiveType.Sphere);
        sphere.transform.position = pos;

        yield return new WaitForSeconds(1);
        Destroy(sphere);
        
    }
}
