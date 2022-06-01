using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;
using UnityEngine.SceneManagement;

public class UIControllerPF : MonoBehaviour
{
    Button btn;

    // Start is called before the first frame update
    void Start()
    {
        VisualElement root = GetComponent<UIDocument>().rootVisualElement;
        btn = root.Q<Button>("btn");

        btn.clicked += ReloadGame;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void ReloadGame()
    {
        SceneManager.LoadScene("MainMenu");
    }
}
