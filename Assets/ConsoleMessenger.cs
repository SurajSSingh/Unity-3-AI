using UnityEngine;

public class ConsoleMessenger : MonoBehaviour 
{
    private void OnEnable() 
    {
        // SetActive(true);
        GameObject.FindObjectOfType<SimpleAI>()?.unityEvent.AddListener(DefualtMessage);
    }  

    private void OnDisable() 
    {
        // SetActive(false)
        GameObject.FindObjectOfType<SimpleAI>()?.unityEvent.RemoveListener(DefualtMessage);
    }

    public void DefualtMessage()
    {
        Debug.Log("Hello World");
    } 


    public void ShowMessage(string message)
    {
        Debug.Log(message);
    }
}