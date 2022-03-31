using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class UIMainMenu : MonoBehaviour
{
    public TMP_InputField inputField;
   
    // Start is called before the first frame update
    void Start()
    {
        inputField.interactable = true;
        MainManager.instance.playerName = inputField.GetComponent<TMP_InputField>().text;
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void StartNew()
    {
        SceneManager.LoadScene(1);

    }

    public void GetPlayerName()
    {
        string playerName = inputField.GetComponent<TMP_InputField>().text;
        
        Debug.Log("Playername is " + playerName);
    }

    public void SavePlayerName()
    {
        MainManager.instance.SaveName();
    }

}
