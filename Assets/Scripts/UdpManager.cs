using System;
using System.Collections;
using System.Collections.Generic;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using UnityEngine;

[Serializable]
public class SensorData
{
	public string id;
	public float w;
	public float x;
	public float y;
	public float z;
}

[Serializable]
public class MasterData
{
	public string id;
	public SensorData[] sensors;
}

public class Udp
{
	private static UdpClient udpClient = new UdpClient();
	private static IPEndPoint remoteIpEndPoint = new IPEndPoint(IPAddress.Any, 0);

	public static void SendPacket(string ip, int port, string text = "packet")
	{
		Byte[] sendBytes = Encoding.ASCII.GetBytes(text);

		udpClient.Send(sendBytes, sendBytes.Length, ip, port);
	}

	public static string GetPacket()
	{
		Byte[] receiveBytes = udpClient.Receive(ref remoteIpEndPoint);
		string message = Encoding.ASCII.GetString(receiveBytes);

		return message;
	}
}

public class UdpManager : MonoBehaviour
{
	[SerializeField]
	private string ipCostume1;

	[SerializeField]
	private string ipCostume2;

	[SerializeField]
	private int port = 8888;

	public static MasterData sensorData1;
	public static MasterData sensorData2;
	public static string message;

	private void Start()
	{
		Udp.SendPacket(ipCostume1, port);
		Udp.SendPacket(ipCostume2, port);

		Task.Run(() =>
		{
			while (true)
			{
				//message = Udp.GetPacket();
				//for (int i = message.Length - 1; i >= 0; i--)
				//{
				//	if (message[i] == '}')
				//	{
				//		message = message.Substring(0, i + 1);
				//		break;
				//	}
				//}
				//MasterData masterData = JsonUtility.FromJson<MasterData>(message);
				//if (masterData.id == "p1")
				//{
				//	sensorData1 = masterData;
				//}
				//else if (masterData.id == "p2")
				//{
				//	sensorData2 = masterData;
				//}
			}
		});

	}
	private void Update()
	{
		for (int j = 0; j < 2; j++)
		{
			message = Udp.GetPacket();
			for (int i = message.Length - 1; i >= 0; i--)
			{
				if (message[i] == '}')
				{
					message = message.Substring(0, i + 1);
					break;
				}
			}
			MasterData masterData = JsonUtility.FromJson<MasterData>(message);
			if (masterData.id == "p1")
			{
				sensorData1 = masterData;
			}
			else if (masterData.id == "p2")
			{
				sensorData2 = masterData;
			}
		}
		
	}
}
