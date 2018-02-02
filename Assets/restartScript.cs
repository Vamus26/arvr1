using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class restartScript : MonoBehaviour {
    public Button restartButton;

    // Use this for initialization
    void Start () {
        Button btn = restartButton.GetComponent<Button>();
        btn.onClick.AddListener(TaskOnClick);
    }
	
    void TaskOnClick()
    {
        coinscript.coinCount = 0;
        SceneManager.LoadScene("avian");
    }
}
