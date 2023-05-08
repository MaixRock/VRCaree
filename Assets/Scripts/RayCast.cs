using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;



public class RayCast : MonoBehaviour
{
	public float rayLength;
	public LayerMask layermask;
	public GameObject Object;

	private void Update()
	{
		if (Input.GetMouseButtonDown(0) && !EventSystem.current.IsPointerOverGameObject())
		{
			RaycastHit hit;
			Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
			if (Physics.Raycast(ray, out hit, rayLength, layermask))
			{
				Debug.Log(hit.collider.name);
				Instantiate(Object, ray.GetPoint(hit.distance), new Quaternion(0, 0, 0, 0));
			}
		}

	}

}