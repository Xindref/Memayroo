using UnityEngine;
using System.Collections;

public class FloorLevelFog : MonoBehaviour {

    public float floorLevel;
    private bool isFloor1;
    public Color normalColor;
    public Color floor1Color;
    public float normalDensity = 0f;
    public float floor1Density = .1f;

    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

        if ((transform.position.z < floorLevel) != isFloor1)
        {
            isFloor1 = transform.position.z < floorLevel;
            if (isFloor1) SetFog1();
            if (!isFloor1) SetNormal();
        }

    }

    void SetNormal()
    {
        RenderSettings.fogColor = normalColor;
        RenderSettings.fogDensity = normalDensity;
    }

    void SetFog1()
    {
        RenderSettings.fogColor = floor1Color;
        RenderSettings.fogDensity = floor1Density;
    }
}