using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bazooka : MonoBehaviour
{
    public float shootForce;
    public float fireTime = .33f;
    public float projectileLifeTime = 5f;
    public Transform muzzlePoint;
    public GameObject projectile;
    

    private float timeToFire;
    // Start is called before the first frame update
    void Start()
    {
        timeToFire = 0f;
    }

    // Update is called once per frame
    void Update()
    {
        timeToFire -= Time.deltaTime;

        if (Input.GetMouseButton(0) && (timeToFire <= 0f))
        {
            Quaternion rocketRot = Quaternion.Euler(muzzlePoint.rotation.eulerAngles.x + 90, muzzlePoint.rotation.eulerAngles.y - 90, muzzlePoint.rotation.eulerAngles.z);
            GameObject currProjectile = (GameObject)Instantiate(projectile, muzzlePoint.position, muzzlePoint.rotation);
            currProjectile.transform.Rotate(new Vector3(-90, 0, 0));
            currProjectile.GetComponent<Rigidbody>().AddForce(muzzlePoint.up * shootForce);
            Destroy(currProjectile, projectileLifeTime);
            timeToFire = fireTime;
        }
    }
}
