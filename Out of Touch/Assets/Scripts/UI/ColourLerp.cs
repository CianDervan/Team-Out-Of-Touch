using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ColourLerp : MonoBehaviour {

		public Color[] c;
		Color color;
		float t = 0;
		public float i = 0.025f;
		bool change = false;

		void Awake()
		{
			color = c[0];    
		}

		void Update()
		{
			if (GetComponent<MeshRenderer>() != null)
			{
				//.SetColor("_BaseColor", - when using LWRPipeline.
				//GetComponent<MeshRenderer>().material.color = Color.Lerp(c[0], c[1], t);
				//GetComponent<Image>().color = Color.Lerp(c[0], c[1], t);
				GetComponent<MeshRenderer>().material.SetColor("_BaseColor", Color.Lerp(c[0], c[1], t));
				if (!change)
					t += i;
				else
					t -= i;
				if (t >= 1)
					change = true;
				if (t <= 0)
					change = false;
			}
			else if (GetComponent<Image>() != null)
			{
				//GetComponent<MeshRenderer>().material.color = Color.Lerp(c[0], c[1], t);
				GetComponent<Image>().color = Color.Lerp(c[0], c[1], t);
				if (!change)
					t += i;
				else
					t -= i;
				if (t >= 1)
					change = true;
				if (t <= 0)
					change = false;
			}

			/*if (PauseMenu.gameIsPaused) 
			{
				t = 0;
			}*/
		}
	}
