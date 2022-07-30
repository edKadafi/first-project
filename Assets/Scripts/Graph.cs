using UnityEngine;
namespace Player
{
    public class Graph : MonoBehaviour
    {
        [SerializeField]
        Transform pointPrefab;
        [SerializeField, Range(10, 1000)]
        int resolution;
        Transform[] _points;
        private Transform parentPos;
        private void Awake()
        {
            parentPos = GameObject.FindGameObjectWithTag("Player").transform;
            _points = new Transform[resolution];    
            var step = 2f / resolution;
            var position = new Vector3(0, 0f, 0f);
            var scale = Vector3.one * step;
            for (int i = 0; i<_points.Length; i++) 
            {
                Transform point = _points[i] = Graph.Instantiate(pointPrefab);
                point.SetParent(this.transform);
                position.x = -1f +((i + 0.5f) * step);
                position.y = -0.5f + position.x * position.x * position.x;
                position.z = -0f;
                point.localScale = scale;
                point.localPosition = position;
            }
        }

        // Start is called before the first frame update
        void Start()
        {
            
        }

        // Update is called once per frame
        void Update()
        {
            float time = Time.time;
            for(int i = 0; i < _points.Length; i++)
            {
                var point = _points[i];
                Vector3 position = point.localPosition;
                position.y = -0.5f + Mathf.Sin(Mathf.PI * (position.x + time));
                point.localPosition = position;
            }
        }
    
    }
}
