using UnityEngine;

public class GameController : MonoBehaviour
{
    [SerializeField] private Player playerPrefab;
    [SerializeField] private Transform playerSpawn;
    [SerializeField] private UIPanel uiPanel;
    
    private Player _player;
    private void Awake()
    {
        _player = Instantiate(playerPrefab, playerSpawn.position, Quaternion.identity);
    }
    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            uiPanel.OpenDialogue();
        }
    }
}
