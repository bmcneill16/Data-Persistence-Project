using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class UIMainMenu : MonoBehaviour
{
    public TMP_InputField inputField;
   
    public void NewPlayerName(string name)
    {
        SaveManager.instance.playerName = name;
    }
    // Start is called before the first frame update
    void Start()
    {
        inputField.interactable = true;
        
    }

    // Update is called once per frame
    void Update()
    {
        SavePlayerName();
    }

    public void StartNew()
    {
        SceneManager.LoadScene(1);

    }

    public void GetPlayerName()
    {
        SaveManager.instance.playerName = inputField.GetComponent<TMP_InputField>().text;
        
        

    }

    public void SavePlayerName()
    {
        if (Input.GetKeyDown(KeyCode.Return))
        {
            SaveManager.instance.SaveName();
        }
    }

}
