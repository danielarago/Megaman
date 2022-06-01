using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;
using UnityEngine.SceneManagement;



public class UIController : MonoBehaviour
{
    Button msgBtn;
    Button startBtn;
    Label msgText;
    VisualElement root;
        
    // Start is called before the first frame update
    void Start()
    {
        root = GetComponent<UIDocument>().rootVisualElement;
        msgBtn = root.Q<Button>("msg-btn");
        startBtn = root.Q<Button>("start-btn");
  

        startBtn.clicked += StartGame;


    }

    // Update is called once per frame
    void Update()
    {
        
    }

    
    void StartGame()
    {
        SceneManager.LoadScene("SampleScene");
        root.style.display = DisplayStyle.None;
    }
}
