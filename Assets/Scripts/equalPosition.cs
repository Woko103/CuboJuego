using UnityEngine;

public class equalPosition : MonoBehaviour {
    public Rigidbody player;
    private void FixedUpdate() {
        transform.position = new Vector3(transform.position.x, transform.position.y, player.transform.position.z);
    }
}