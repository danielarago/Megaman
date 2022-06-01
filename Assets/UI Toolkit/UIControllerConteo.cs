using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;
using UnityEngine.SceneManagement;

public class UIControllerConteo : MonoBehaviour
{
    Label text;
    GameObject[] enemies;

    // Start is called before the first frame update
    void Start()
    {
        VisualElement root = GetComponent<UIDocument>().rootVisualElement;
        text = root.Q<Label>("txt");
        enemies = GameObject.FindGameObjectsWithTag("Enemy");
    }

    // Update is called once per frame
    void Update()
    {
        enemies = GameObject.FindGameObjectsWithTag("Enemy");
        generarTexto();

        if (enemies.Length == 0)
        {
            Time.timeScale = 0;
            SceneManager.LoadScene("EndMenu");
        }
    }

    void generarTexto()
    {
        text.text = enemies.Length.ToString();
    }
}
