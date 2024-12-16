using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Experimental.GlobalIllumination;
using UnityEngine.UI;

public class LightToggle : MonoBehaviour
{
    public GameObject DirectionalLight;
    public GameObject NeonLightPrefab;

    private bool isDirectionalLightOn = true;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void ToggleLight()
    {
        if (isDirectionalLightOn)
        {
            isDirectionalLightOn = false;
            DirectionalLight.SetActive(false);
            NeonLightPrefab.SetActive(true);
        }
        else
        {
            isDirectionalLightOn = true;
            DirectionalLight.SetActive(true);
            NeonLightPrefab.SetActive(false);
        }
    }
}
