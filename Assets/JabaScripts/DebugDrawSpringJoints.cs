// The MIT License (MIT)
//
// Copyright (c) 2015 Jabavu W. Adams.
//
// Permission is hereby granted, free of charge, to any person obtaining a copy
// of this software and associated documentation files (the "Software"), to deal
// in the Software without restriction, including without limitation the rights
// to use, copy, modify, merge, publish, distribute, sublicense, and/or sell
// copies of the Software, and to permit persons to whom the Software is
// furnished to do so, subject to the following conditions:
//
// The above copyright notice and this permission notice shall be included in
// all copies or substantial portions of the Software.
//
// THE SOFTWARE IS PROVIDED "AS IS", WITHOUT WARRANTY OF ANY KIND, EXPRESS OR
// IMPLIED, INCLUDING BUT NOT LIMITED TO THE WARRANTIES OF MERCHANTABILITY,
// FITNESS FOR A PARTICULAR PURPOSE AND NONINFRINGEMENT. IN NO EVENT SHALL THE
// AUTHORS OR COPYRIGHT HOLDERS BE LIABLE FOR ANY CLAIM, DAMAGES OR OTHER
// LIABILITY, WHETHER IN AN ACTION OF CONTRACT, TORT OR OTHERWISE, ARISING FROM,
// OUT OF OR IN CONNECTION WITH THE SOFTWARE OR THE USE OR OTHER DEALINGS IN
// THE SOFTWARE.

// DebugDrawSpringJoints.cs

using UnityEngine;
using System.Collections;

public class DebugDrawSpringJoints : MonoBehaviour 
{
	public Color stretchedColor = Color.red;
	public Color compressedColor = Color.green;
	public Color neutralColor = Color.cyan;


	void Update() 
	{
		foreach (SpringJoint spring in GetComponents<SpringJoint>()) 
		{
			Vector3 p0 = transform.TransformPoint(spring.anchor);

			Vector3 p1 = spring.connectedBody.transform.TransformPoint(
				spring.connectedAnchor);

			// Draw the spring with varying colours depending on whether
			// it's stretched, compressed, or neither.

			float currentLength = Vector3.Distance(p0, p1);
			Color springColor;

			if (currentLength > spring.maxDistance)
			{
				springColor = stretchedColor;
			}
			else if (currentLength < spring.minDistance)
			{
				springColor = compressedColor;
			}
			else
			{
				springColor = neutralColor;
			}


			Debug.DrawLine(p0, p1, springColor);
		}
	}
}
