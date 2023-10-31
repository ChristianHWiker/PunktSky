using System;
using System.Collections;
using System.Collections.Generic;
using System.Globalization;
using UnityEngine;

public class PointCloud : MonoBehaviour
{
    [SerializeField] private TextAsset vertexData;

    Vector3[] vertices = new Vector3[1115322];

    public GameObject myPrefab;

    // Start is called before the first frame update
    void Start()
    {

        readTextFile();
       
    }

    void readTextFile()
    {
        if (!vertexData)
            Debug.LogWarning("no txt file");

        string[] splitfile = new[] { "\r\n", "\n", "\r" };
        char[] splitchars = new[] { ' ', '\t' };

        string[] vertexLines = vertexData.text.Split(splitfile, System.StringSplitOptions.RemoveEmptyEntries);

        for (int i = 1; i < vertices.Length + 1;)
        {
            var xyz = vertexLines[i].Split(splitchars, StringSplitOptions.RemoveEmptyEntries);

            float x = float.Parse(xyz[0], CultureInfo.InvariantCulture)/1000;
            float y = float.Parse(xyz[1], CultureInfo.InvariantCulture)/1000;
            float z = float.Parse(xyz[2], CultureInfo.InvariantCulture)/1000;

            Debug.Log("x:" + x + "y:" + y + "z:" + z);

            vertices[i - 1] = new Vector3(x, z, y);

            Instantiate(myPrefab, vertices[i-1], Quaternion.identity);

            i = i + 1000;
        }

    }
}
