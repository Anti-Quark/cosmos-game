using UnityEngine;
using System.Collections;
using LibNoise;
using LibNoise.Generator;
using LibNoise.Operator;

public class PlanetGenerate : MonoBehaviour {
	
	public int resolution = 512;
	public int octaves = 5;
	public bool seamless = true;
	public float frequency = 0.3f;
	public float amplitude = 5.0f;
	private Perlin noise;

	// Use this for initialization
	void Start () {
		noise = new Perlin();

		Mesh mesh = GetComponent<MeshFilter>().mesh;
		Vector3[] vertices = mesh.vertices;
		int i = 0;
		while (i < vertices.Length) {
			Vector3 pos = vertices[i] * 200;
			vertices[i] = vertices[i] * (float)(100 + noise.GetValue(pos.x, pos.y, pos.z) * 2);
			i++;
		}
		mesh.vertices = vertices;
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
