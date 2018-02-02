using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class birdscript : MonoBehaviour {

    private bool clicked = false;
    public Camera cam;
    public Rigidbody2D rigidbody2;
    public GameObject nextBird;
    public GameObject loseScreen;
    public Text birdAmount;
    public static int birdCount = 3;
    // Use this for initialization
    void Start ()
    {
        birdAmount.text = "Birds left: " + birdCount;
    }
	
	// Update is called once per frame
	void Update ()
    {
		if(clicked == true)
        {
            Vector3 mousePos = Input.mousePosition;
            rigidbody2.position = cam.ScreenToWorldPoint(new Vector3(mousePos.x, mousePos.y, 10));
        }
	}
    private void OnMouseDown()
    {
        clicked = true;
        rigidbody2.isKinematic = true;
    }
    private void OnMouseUp()
    {
        clicked = false;
        rigidbody2.isKinematic = false;
        StartCoroutine(Release());
    }

    IEnumerator Release()
    {
        yield return new WaitForSeconds(0.15f);
        GetComponent<SpringJoint2D>().enabled = false;
        this.enabled = false;
        birdCount--;
        birdAmount.text = "Birds left: " + birdCount;
        yield return new WaitForSeconds(2f);
        if (nextBird != null)
        {
            nextBird.SetActive(true);
        }
        else
        {
            yield return new WaitForSeconds(5f);
            loseScreen.SetActive(true);
            coinscript.coinCount = 0;
        }
    }
}
