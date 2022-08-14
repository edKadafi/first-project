using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Proiect.GamePlay.Inanimates.Cubes
{
    public static class CubeHandler
    {
        public static void paintPlayer(GameObject cube, GameObject player)
        {
            var cylinder = player.GetComponentInChildren<SkinnedMeshRenderer>();
            cylinder.GetComponent<SkinnedMeshRenderer>().material.color = cube.GetComponent<MeshRenderer>().material.color;
        }
    }
}

