using Proiect.Player;
using Proiect.Player.DebugUtils;
using UnityEngine;


namespace Proiect.GamePlay.Inanimates.Cubes
{
    public class CubeTrigger : MonoBehaviour
    {
        [SerializeField] private GameObject cube;
        private MainPlayer player;
        private int Id;

        private void Awake()
        {
            player = FindObjectOfType<MainPlayer>();
        }

        private void OnTriggerEnter(Collider other)
        {
            CubeHandler.paintPlayer(gameObject, other.gameObject);
            var g = FindObjectOfType<DebugUtils>();
            g.objects.RemoveAt(g.objects.IndexOf(gameObject.transform));
            DisposeCube();
        }

        private void DisposeCube()
        {
            Destroy(gameObject);
        }

        public void setId(int id)
        {
            Id = id;
        }
    }
}

