using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[System.Serializable]
public class EnvironmentData
{
    public float[][] positions;
    public float[][] rotations;
    public float[][] colors;

    public EnvironmentData(List<Transform> cubes)
    {
        positions = new float[cubes.Count][];
        rotations = new float[cubes.Count][];
        colors = new float[cubes.Count][];
        for (int i = 0; i < cubes.Count; i++)
        {
            var trans = cubes[i].GetComponent<Transform>();
            var color = cubes[i].GetComponent<Renderer>().material;
            positions[i] = new float[3];
            positions[i][0] = trans.position.x;
            positions[i][1] = trans.position.y;
            positions[i][2] = trans.position.z;
            
            rotations[i] = new float[4];
            rotations[i][0] = trans.rotation.x;
            rotations[i][1] = trans.rotation.y;
            rotations[i][2] = trans.rotation.z;
            rotations[i][3] = trans.rotation.w;

            colors[i] = new float[4];
            colors[i][0] = color.color.a;
            colors[i][1] = color.color.b;
            colors[i][2] = color.color.g;
            colors[i][3] = color.color.r;
        }
    }
}
