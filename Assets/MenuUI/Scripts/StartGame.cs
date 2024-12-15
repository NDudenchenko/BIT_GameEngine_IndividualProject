using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StartGame : MonoBehaviour
{
    public GameObject Player;
    public GameObject PlayerCamera;
    public GameObject PlayerUI;
    public GameObject MenuCamera;
    public GameObject MenuUI;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void SetupGameStart()
    {
        Player.SetActive(true);
        PlayerCamera.SetActive(true);
        PlayerUI.SetActive(true);
        MenuCamera.SetActive(false);
        MenuUI.SetActive(false);
    }
}
