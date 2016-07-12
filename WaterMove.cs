using UnityEngine;
using System.Collections;

public class WaterMove : MonoBehaviour {

    public float scale = 10f;
    public float speed = 1f;
    public float noiseStrength = 4f;
    public float noiseWalk = 1f;

    public Vector2 Scroll1 = new Vector2(0.05f, 0.05f);
    public Vector2 Scroll2 = new Vector2(0.05f, 0.05f);
    Vector2 Offset1 = new Vector2(0f, 0f);
    Vector2 Offset2 = new Vector2(0f, 0f);

    private Vector3[] baseHeight;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {

        Mesh mesh = GetComponent<MeshFilter>().mesh;

        if (baseHeight == null)
            baseHeight = mesh.vertices;

        Vector3[] vertices = new Vector3[baseHeight.Length];
        for (int i = 0; i < vertices.Length; i++)
        {
            Vector3 vertex = baseHeight[i];
            vertex.y += Mathf.Sin(Time.time * speed + baseHeight[i].x + baseHeight[i].y + baseHeight[i].z) * scale;
            vertex.y += Mathf.PerlinNoise(baseHeight[i].x + noiseWalk, baseHeight[i].y + Mathf.Sin(Time.time * 0.1f)) * noiseStrength;
            vertices[i] = vertex;
        }
        mesh.vertices = vertices;
        mesh.RecalculateNormals();

        Offset1 += Scroll1 * Time.deltaTime;
        Offset2 += Scroll2 * Time.deltaTime;
        GetComponent<Renderer>().material.SetTextureOffset("_MainTex", Offset1);
        GetComponent<Renderer>().material.SetTextureOffset("_BumpMap", Offset2);

    }
}
