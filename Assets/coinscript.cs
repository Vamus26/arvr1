using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class coinscript : MonoBehaviour {

    public Rigidbody2D rigidbody2;
    public static int coinCount = 0;
    public Camera cam;
    public GameObject winScreen;
    private void Start()
    {
        coinCount++;
    }
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            RaycastHit hit;
            Ray ray = cam.ScreenPointToRay(Input.mousePosition);
            if (Physics.Raycast(ray, out hit))
            {
                if(hit.collider.gameObject.tag == "coin")
                {
                    coinCount--;
                    Destroy(hit.collider.gameObject);
                }
            }
        }
        if (coinCount == 0)
        {
            winScreen.SetActive(true);
            StartCoroutine(Restart());
        }

    }
    IEnumerator Restart()
    {
        yield return new WaitForSeconds(2f);
    }
        /*    private void OnMouseUp()
            {
                Debug.Log("you win!");
                coinCount--;
                if (coinCount <= 0)
                    Debug.Log("you win!");
                Destroy(gameObject);

            }*/
    }
