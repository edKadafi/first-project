using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[System.Serializable]
public class EnvironmentData
{
    public float[][] positions;
    public float[][] rotations;

    public EnvironmentData(List<Transform> cubes)
    {
        positions = new float[cubes.Count][];
        rotations = new float[cubes.Count][];
        for (int i = 0; i < cubes.Count; i++)
        {
            positions[i] = new float[3];
            positions[i][0] = cubes[i].position.x;
            positions[i][1] = cubes[i].position.y;
            positions[i][2] = cubes[i].position.z;
            
            rotations[i] = new float[4];
            rotations[i][0] = cubes[i].rotation.x;
            rotations[i][1] = cubes[i].rotation.y;
            rotations[i][2] = cubes[i].rotation.z;
            rotations[i][3] = cubes[i].rotation.w;
        }
    }
}
