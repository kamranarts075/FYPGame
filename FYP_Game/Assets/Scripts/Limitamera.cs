using UnityEngine;

public class Limitamera : MonoBehaviour
{
    public GameObject player;

    private void LateUpdate()
    {
        transform.position = new Vector3(player.transform.position.x, 130, player.transform.position.z);
    }
}
