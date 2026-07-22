using UnityEngine;

public class Camera2D : MonoBehaviour
{
    public Transform targetPlayer;

    void Start()
    {
        
    }

    void Update()
    {
        if (targetPlayer != null)
        {
            transform.position = new Vector3(targetPlayer.position.x + 6f, 0f, -10f);
        }
    }
}