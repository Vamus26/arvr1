using UnityEngine;
using UnityEngine.UI;
public class coinscript : MonoBehaviour {

    public Rigidbody2D rigidbody2;
    public static int coinCount = 0;
    public Camera cam;
    public GameObject winScreen;
    public Text coinAmount;
    private void Start()
    {
        coinCount++;
        coinAmount.text = "Coins left: " + coinCount;
    }
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            Ray ray = cam.ScreenPointToRay(Input.mousePosition);
            RaycastHit2D hit = Physics2D.Raycast(ray.origin, ray.direction);
            if (hit.collider != null && hit.collider.gameObject.tag == "coin")
            {
                coinCount--;
                coinAmount.text = "Coins left: " + coinCount;
                Destroy(hit.collider.gameObject);
            }
        }
        if (coinCount == 0)
            winScreen.SetActive(true);
    }

 }
