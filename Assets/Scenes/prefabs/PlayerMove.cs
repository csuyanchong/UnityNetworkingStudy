using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;
public class PlayerMove : NetworkBehaviour
{
    public GameObject bulletPrefab;
    public override void OnStartLocalPlayer()
    {
        GetComponent<MeshRenderer>().material.color = Color.red;
    }
    float x,z;
    // Update is called once per frame
    void Update()
    {
        if (!isLocalPlayer)
            return;
         x = Input.GetAxis("Horizontal") * 0.1f;
         z = Input.GetAxis("Vertical") * 0.1f;

        transform.Translate(x, 0, z);

        if (Input.GetKeyDown(KeyCode.Space))
        {
            CmdFire();
        }
        
    }
    [Command]
    void CmdFire()
    {
        // create the bullet object from the bullet prefab
        var bullet = (GameObject)Instantiate(
            bulletPrefab,
            transform.position - transform.forward,
            Quaternion.identity);

        // make the bullet move away in front of the player
        bullet.GetComponent<Rigidbody>().velocity = -transform.forward * 4;

        NetworkServer.Spawn(bullet);
        // make bullet disappear after 2 seconds
        Destroy(bullet, 2.0f);
    }
}
