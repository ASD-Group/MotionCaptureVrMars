using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Costume2 : MonoBehaviour
{
	[SerializeField]
	private Transform leftLowerArm; // LLA

	[SerializeField]
	private Transform leftUpperArm; // LUA

	[SerializeField]
	private Transform rightLowerArm; // RLA

	[SerializeField]
	private Transform rightUpperArm; // RUA

	[SerializeField]
	private Transform rightUpperLeg; // RUL

	[SerializeField]
	private Transform rightLowerLeg; // RLL

	[SerializeField]
	private Transform leftUpperLeg; // LUL

	[SerializeField]
	private Transform leftLowerLeg; // LLl

	[SerializeField]
	private Transform spine; // B

	[SerializeField]
	private Transform character; // H

	private void Start()
	{

	}

	private void Update()
	{
		if (UdpManager.sensorData2 == null)
		{
			return;
		}

		if (UdpManager.sensorData2.id != "p2")
		{
			return;
		}

		foreach (SensorData sensor in UdpManager.sensorData2.sensors)
		{
			if (sensor.id == "RUA")
			{
				rightUpperArm.transform.rotation = new Quaternion(-sensor.x, -sensor.z, -sensor.y, sensor.w);
				rightUpperArm.transform.rotation *= Quaternion.Euler(/*ó*/0f, /*õ*/90f, /*z*/0f);
			}
			else if (sensor.id == "RLA")
			{
				rightLowerArm.transform.rotation = new Quaternion(-sensor.x, -sensor.z, -sensor.y, sensor.w);
				rightLowerArm.transform.rotation *= Quaternion.Euler(/*ó*/0f, /*õ*/90f, /*z*/0f);
			}
			else if (sensor.id == "LUA")
			{
				leftUpperArm.transform.rotation = new Quaternion(-sensor.x, -sensor.z, -sensor.y, sensor.w);
				leftUpperArm.transform.rotation *= Quaternion.Euler(/*ó*/0f, /*õ*/-90f, /*z*/0f);
			}
			else if (sensor.id == "LLA")
			{
				leftLowerArm.transform.rotation = new Quaternion(-sensor.x, -sensor.z, -sensor.y, sensor.w);
				leftLowerArm.transform.rotation *= Quaternion.Euler(/*ó*/0f, /*õ*/-90f, /*z*/0f);
			}
			else if (sensor.id == "RUL")
			{
				rightUpperLeg.transform.rotation = new Quaternion(-sensor.x, -sensor.z, -sensor.y, sensor.w);
				rightUpperLeg.transform.rotation *= Quaternion.Euler(/*ó*/0f, /*õ*/90f, /*z*/90f);
			}
			else if (sensor.id == "RLL")
			{
				rightLowerLeg.transform.rotation = new Quaternion(-sensor.x, -sensor.z, -sensor.y, sensor.w);
				rightLowerLeg.transform.rotation *= Quaternion.Euler(/*ó*/0f, /*õ*/90f, /*z*/90f);
			}
			else if (sensor.id == "LUL")
			{
				leftUpperLeg.transform.rotation = new Quaternion(-sensor.x, -sensor.z, -sensor.y, sensor.w);
				leftUpperLeg.transform.rotation *= Quaternion.Euler(/*ó*/0f, /*õ*/-90f, /*z*/-90f);
			}
			else if (sensor.id == "LLL")
			{
				leftLowerLeg.transform.rotation = new Quaternion(-sensor.x, -sensor.z, -sensor.y, sensor.w);
				leftLowerLeg.transform.rotation *= Quaternion.Euler(/*ó*/0f, /*õ*/-90f, /*z*/-90f);
			}
			else if (sensor.id == "B")
			{
				spine.transform.rotation = new Quaternion(-sensor.x, -sensor.z, -sensor.y, sensor.w);
				spine.transform.rotation *= Quaternion.Euler(/*ó*/90f, /*õ*/0f, /*z*/0f);
			}
			else if (sensor.id == "H")
			{
				character.transform.rotation = new Quaternion(-sensor.x, -sensor.z, -sensor.y, sensor.w);
				character.transform.rotation *= Quaternion.Euler(/*ó*/90f, /*õ*/0f, /*z*/0f);
			}
		}

	}
}
