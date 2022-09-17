using Proiect.System.SaveSystem;
using Proiect.Player.DebugUtils;
using UnityEngine;

public class Environment : MonoBehaviour
{
    private DebugUtils _debugUtils;
    private EnvironmentData _environmentData;

    private void Start()
    {
        _debugUtils = FindObjectOfType<DebugUtils>();
    }

    public void LoadEnvironment()
    {
        _environmentData = SaveSystem.LoadEnvironment();
        if (_environmentData != null)
        {
            ApplyEnvironmentData();
        }
        else
        {
            Debug.Log("[MainPlayer] No EnvironmentData available! Using default.");
            return;
        }
    }

    private void ApplyEnvironmentData()
    {
        Debug.Log("[Environment] Applying environment data.");
        
        for (int i = 0; i < _environmentData.positions.Length; i++)
        {
            var aux = new GameObject();
            Vector3 tempPosition = new Vector3(_environmentData.positions[i][0], _environmentData.positions[i][1], _environmentData.positions[i][2]);
            Quaternion tempRotation = new Quaternion(_environmentData.rotations[i][0], _environmentData.rotations[i][1], _environmentData.rotations[i][2], _environmentData.rotations[i][3]);
            aux.transform.SetPositionAndRotation(tempPosition, tempRotation);
            _debugUtils.objects.Add(aux.transform);
            Destroy(aux);
        }
        
        _debugUtils.CreateList(_debugUtils.objects, _environmentData.colors);
    }
}
