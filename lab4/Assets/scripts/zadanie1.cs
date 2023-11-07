using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class RandomCubesGenerator : MonoBehaviour
{
    List<Vector3> positions = new List<Vector3>();
    public float delay = 3.0f;
    int objectCounter = 0;
    public int ile = 10;
    public Material[] materials;
    // obiekt do generowania
    public GameObject block;

    void Start()
    {
        // maksymale wspolrzedne x i z powierzchni (plane), na ktorej znajduje sie obiekt

        Renderer planeRenderer = GetComponent<Renderer>();
        Bounds planeBounds = planeRenderer.bounds;
        float maxPlaneX = planeBounds.extents.x;
        float maxPlaneZ = planeBounds.extents.z;

        // w momecie uruchomienia generuje 10 kostek w losowych miejscach
        List<int> pozycje_x = new List<int>(Enumerable.Range(0, (int)plane_x).OrderBy(x => Guid.NewGuid()).Take(ile));
        List<int> pozycje_z = new List<int>(Enumerable.Range(0, (int)plane_z).OrderBy(x => Guid.NewGuid()).Take(ile));

        for (int i = 0; i < ile; i++)
        {
            this.positions.Add(new Vector3(pozycje_x[i], 1, pozycje_z[i]));
        }
        foreach (Vector3 elem in positions)
        {
            Debug.Log(elem);
        }
        // uruchamiamy coroutine
        StartCoroutine(GenerujObiekt());
    }

    void Update()
    {

    }

    IEnumerator GenerujObiekt()
    {
        Debug.Log("wywo³ano coroutine");
        foreach (Vector3 pos in positions)
        {
            GameObject obj = Instantiate(this.block, this.positions.ElementAt(this.objectCounter++), Quaternion.identity);
            int randomMaterial = UnityEngine.Random.Range(0, materials.Length);
            obj.GetComponent<Renderer>().material = materials[randomMaterial];
            yield return new WaitForSeconds(this.delay);
        }
        // zatrzymujemy coroutine
        StopCoroutine(GenerujObiekt());
    }
}