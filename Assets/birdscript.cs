using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class birdscript : MonoBehaviour {

    private bool clicked = false;
    public Camera cam;
    public Rigidbody2D rigidbody;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		if(clicked == true)
        {
            Vector3 mousePos = Input.mousePosition;
            rigidbody.position = cam.ScreenToWorldPoint(new Vector3(mousePos.x, mousePos.y, 10));
        }
	}
    private void OnMouseDown()
    {
        clicked = true;
        rigidbody.isKinematic = true;
    }
    private void OnMouseUp()
    {
        clicked = false;
        rigidbody.isKinematic = false;
        StartCoroutine(Release());
    }

    IEnumerator Release()
    {
        yield return new WaitForSeconds(0.15f);
        GetComponent<SpringJoint2D>().enabled = false;
    }
}
