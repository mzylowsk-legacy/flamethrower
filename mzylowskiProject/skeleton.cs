using UnityEngine;
using System.Collections.Generic;


public class skeleton : MonoBehaviour {
	
	private float lineOfSight = 60.0f;
	private float fireRange = 25.0f;

	private float health = 500.0f;
	private bool alive = true;
	float speed = 8.0f;
	float rotationSpeed = 5.0f;
	private GameObject target;

	public GameObject miecz;
	public GameObject minigun;
	
	// Use this for initialization
	void Start () {
		animation.Play();
		miecz.SetActiveRecursively(false);
	}
	
	// Update is called once per frame
	void Update () {
		if (!alive) return;
		target = GameObject.FindWithTag("Player");
		
		if (target == null)
			return;	
		
		RaycastHit ray;
		Vector3 orig = transform.position;
		orig.y += 1.0f;
		
		Vector3 direction = transform.TransformDirection(Vector3.forward);
		Vector3 rayDirection = target.transform.position - orig;

		if (Physics.Raycast(orig, rayDirection, out ray, fireRange)
				&& ray.collider.tag == "Player")
		{
				minigun.SetActiveRecursively(true);
		
				animation.CrossFade("waitingforbattle");
			
				var rot = Quaternion.LookRotation(rayDirection, Vector3.up);
				transform.rotation = Quaternion.Slerp(transform.rotation, rot, Time.deltaTime * rotationSpeed);
			
				BroadcastMessage("Fire");
		}
		else if (Physics.Raycast(orig, rayDirection, out ray, lineOfSight)
			&& ray.collider.tag == "Player")
		{
			animation.CrossFade("run");
			var rot = Quaternion.LookRotation(rayDirection, Vector3.up);
			transform.rotation = Quaternion.Slerp(transform.rotation, rot, Time.deltaTime * rotationSpeed);
			var controller = GetComponentInChildren<CharacterController>();
			controller.SimpleMove(transform.TransformDirection(Vector3.forward * speed));

		}

		else
		{
			animation.CrossFade("idle");	
		}
	}
	
	void ApplyDamage(float damage)
	{
		if (!alive) return;

		health -= damage;
		if (health <= 0)
		{
				animation.CrossFade("die");
				alive = false;
				Destroy(gameObject, 8);
				target = GameObject.FindWithTag("Player");
		}
	}
}
