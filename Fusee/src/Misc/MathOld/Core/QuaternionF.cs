#region Copyright(C) Notice
//	Fusee.Math math library. Based on the Sharp3D math library originally developed by
//	Copyright (C) 2003-2004  
//	Eran Kampf
//	tentacle@zahav.net.il
//	http://www.ekampf.com/Fusee.Math/
//
//	This library is free software; you can redistribute it and/or
//	modify it under the terms of the GNU Lesser General Public
//	License as published by the Free Software Foundation; either
//	version 2.1 of the License, or (at your option) any later version.
//
//	This library is distributed in the hope that it will be useful,
//	but WITHOUT ANY WARRANTY; without even the implied warranty of
//	MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE.  See the GNU
//	Lesser General Public License for more details.
//
//	You should have received a copy of the GNU Lesser General Public
//	License along with this library; if not, write to the Free Software
//	Foundation, Inc., 59 Temple Place, Suite 330, Boston, MA  02111-1307  USA
#endregion
using System;
using System.ComponentModel;
using System.Diagnostics;
using System.Collections;
using System.IO;
using System.Text.RegularExpressions;
using System.Runtime.Serialization;
using System.Security.Permissions;
using System.Runtime.InteropServices;

namespace Fusee.Math.Core
{
	/// <summary>
	/// Represents a single-precision floating-point quaternion.
	/// </summary>
	/// <remarks>
	/// <para>
	/// A quaternion can be thought of as a 4-Dimentional vector of form:
	/// q = [w, x, y, z] = w + xi + yj +zk.
	/// </para>
	/// <para>
	/// A Quaternion is often written as q = s + V where S represents
	/// the scalar part (w component) and V is a 3D vector representing
	/// the imaginery coefficients (x,y,z components).
	/// </para>
	/// </remarks>
	[Serializable]
	[StructLayout(LayoutKind.Sequential)]
	[TypeConverter(typeof(QuaternionFConverter))]
	public struct QuaternionF : ICloneable, ISerializable
	{
		#region Private Fields
		private float _w;
		private float _x;
		private float _y;
		private float _z;
		#endregion

		#region Constructors
		/// <summary>
		/// Initializes a new instance of the <see cref="QuaternionF"/> class with the specified coordinates.
		/// </summary>
		/// <param name="w">The quaternions's W coordinate.</param>
		/// <param name="x">The quaternions's X coordinate.</param>
		/// <param name="y">The quaternions's Y coordinate.</param>
		/// <param name="z">The quaternions's Z coordinate.</param>
		public QuaternionF(float w, float x, float y, float z)
		{
			_w = w;
			_x = x;
			_y = y;
			_z = z;
		}
		/// <summary>
		/// Initializes a new instance of the <see cref="QuaternionF"/> class with the specified coordinates.
		/// </summary>
		/// <param name="w">A scalar.</param>
		/// <param name="v">A <see cref="Vector3F"/> instance.</param>
		public QuaternionF(float w, Vector3F v)
		{
			_w = w;
			_x = v.X;
			_y = v.Y;
			_z = v.Z;
		}
		/// <summary>
		/// Initializes a new instance of the <see cref="QuaternionF"/> class with the specified coordinates.
		/// </summary>
		/// <param name="coordinates">An array containing the coordinate parameters.</param>
		public QuaternionF(float[] coordinates)
		{
			Debug.Assert(coordinates != null);
			Debug.Assert(coordinates.Length >= 4);

			_w = coordinates[0];
			_x = coordinates[1];
			_y = coordinates[2];
			_z = coordinates[3];
		}
		/// <summary>
		/// Initializes a new instance of the <see cref="QuaternionF"/> class using coordinates from a given <see cref="QuaternionF"/> instance.
		/// </summary>
		/// <param name="q">A <see cref="QuaternionF"/> to get the coordinates from.</param>
		public QuaternionF(QuaternionF q)
		{
			_w = q.W;
			_x = q.X;
			_y = q.Y;
			_z = q.Z;
		}
		/// <summary>
		/// Initializes a new instance of the <see cref="QuaternionF"/> class with serialized data.
		/// </summary>
		/// <param name="info">The object that holds the serialized object data.</param>
		/// <param name="context">The contextual information about the source or destination.</param>
		private QuaternionF(SerializationInfo info, StreamingContext context)
		{
			_w = info.GetSingle("W");
			_x = info.GetSingle("X");
			_y = info.GetSingle("Y");
			_z = info.GetSingle("Z");
		}
		#endregion

		#region Constants
		/// <summary>
		/// single-precision floating point zero quaternion.
		/// </summary>
		public static readonly QuaternionF Zero      = new QuaternionF(0, 0, 0, 0);
		/// <summary>
		/// single-precision floating point identity quaternion.
		/// </summary>
		public static readonly QuaternionF Identity  = new QuaternionF(1, 0, 0, 0);
		/// <summary>
		/// single-precision floating point X-Axis quaternion.
		/// </summary>
		public static readonly QuaternionF XAxis		= new QuaternionF(0, 1, 0, 0);
		/// <summary>
		/// single-precision floating point Y-Axis quaternion.
		/// </summary>
		public static readonly QuaternionF YAxis		= new QuaternionF(0, 0, 1, 0);
		/// <summary>
		/// single-precision floating point Z-Axis quaternion.
		/// </summary>
		public static readonly QuaternionF ZAxis		= new QuaternionF(0, 0, 0, 1);
		/// <summary>
		/// single-precision floating point W-Axis quaternion.
		/// </summary>
		public static readonly QuaternionF WAxis		= new QuaternionF(1, 0, 0, 0);
		#endregion

		#region Public Properties
		/// <summery>
		/// Gets or sets the w-coordinate of this quaternion.
		/// </summery>
		/// <value>The w-coordinate of this quaternion.</value>
		public float W
		{
			get { return _w; }
			set { _w = value;}
		}
		/// <summery>
		/// Gets or sets the x-coordinate of this quaternion.
		/// </summery>
		/// <value>The x-coordinate of this quaternion.</value>
		public float X
		{
			get { return _x; }
			set { _x = value;}
		}
		/// <summery>
		/// Gets or sets the y-coordinate of this quaternion.
		/// </summery>
		/// <value>The y-coordinate of this quaternion.</value>
		public float Y
		{
			get { return _y; }
			set { _y = value;}
		}
		/// <summery>
		/// Gets or sets the z-coordinate of this quaternion.
		/// </summery>
		/// <value>The z-coordinate of this quaternion.</value>
		public float Z
		{
			get { return _z; }
			set { _z = value;}
		}
		#endregion

		#region ICloneable Members
		/// <summary>
		/// Creates an exact copy of this <see cref="QuaternionF"/> object.
		/// </summary>
		/// <returns>The <see cref="QuaternionF"/> object this method creates, cast as an object.</returns>
		object ICloneable.Clone()
		{
			return new QuaternionF(this);
		}
		/// <summary>
		/// Creates an exact copy of this <see cref="QuaternionF"/> object.
		/// </summary>
		/// <returns>The <see cref="QuaternionF"/> object this method creates.</returns>
		public QuaternionF Clone()
		{
			return new QuaternionF(this);
		}
		#endregion

		#region ISerializable Members
		/// <summary>
		/// Populates a <see cref="SerializationInfo"/> with the data needed to serialize this object.
		/// </summary>
		/// <param name="info">The <see cref="SerializationInfo"/> to populate with data. </param>
		/// <param name="context">The destination (see <see cref="StreamingContext"/>) for this serialization.</param>
		//[SecurityPermissionAttribute(SecurityAction.Demand, SerializationFormatter=true)]
		public void GetObjectData(SerializationInfo info, StreamingContext context)
		{
			info.AddValue("W", _w);
			info.AddValue("X", _x);
			info.AddValue("Y", _y);
			info.AddValue("Z", _z);
		}
		#endregion

		#region Public Static Parse Methods
		/// <summary>
		/// Converts the specified string to its <see cref="QuaternionF"/> equivalent.
		/// </summary>
		/// <param name="s">A string representation of a <see cref="QuaternionF"/></param>
		/// <returns>A <see cref="QuaternionF"/> that represents the vector specified by the <paramref name="s"/> parameter.</returns>
		public static QuaternionF Parse(string s)
		{
			Regex r = new Regex(@"\((?<w>.*),(?<x>.*),(?<y>.*),(?<z>.*)\)", RegexOptions.None);
			Match m = r.Match(s);
			if (m.Success)
			{
				return new QuaternionF(
					float.Parse(m.Result("${w}")),
					float.Parse(m.Result("${x}")),
					float.Parse(m.Result("${y}")),
					float.Parse(m.Result("${z}"))
					);
			}
			else
			{
				throw new ParseException("Unsuccessful Match.");
			}
		}
		#endregion

		#region Public Static Quaternion Arithmetics
		/// <summary>
		/// Adds two quaternions.
		/// </summary>
		/// <param name="a">A <see cref="QuaternionF"/> instance.</param>
		/// <param name="b">A <see cref="QuaternionF"/> instance.</param>
		/// <returns>A new <see cref="QuaternionF"/> instance containing the sum.</returns>
		public static QuaternionF Add(QuaternionF a, QuaternionF b)
		{
			return new QuaternionF(a.W + b.W, a.X + b.X, a.Y + b.Y, a.Z + b.Z);
		}
		/// <summary>
		/// Adds two quaternions and put the result in the third quaternion.
		/// </summary>
		/// <param name="a">A <see cref="QuaternionF"/> instance.</param>
		/// <param name="b">A <see cref="QuaternionF"/> instance.</param>
		/// <param name="result">A <see cref="QuaternionF"/> instance to hold the result.</param>
		public static void Add(QuaternionF a, QuaternionF b, ref QuaternionF result)
		{
			result.W = a.W + b.W;
			result.X = a.X + b.X;
			result.Y = a.Y + b.Y;
			result.Z = a.Z + b.Z;
		}

		/// <summary>
		/// Subtracts a quaternion from a quaternion.
		/// </summary>
		/// <param name="a">A <see cref="QuaternionF"/> instance.</param>
		/// <param name="b">A <see cref="QuaternionF"/> instance.</param>
		/// <returns>A new <see cref="QuaternionF"/> instance containing the difference.</returns>
		public static QuaternionF Subtract(QuaternionF a, QuaternionF b)
		{
			return new QuaternionF(a.W - b.W, a.X - b.X, a.Y - b.Y, a.Z - b.Z);
		}
		/// <summary>
		/// Subtracts a quaternion from a quaternion and puts the result into a third quaternion.
		/// </summary>
		/// <param name="a">A <see cref="QuaternionF"/> instance.</param>
		/// <param name="b">A <see cref="QuaternionF"/> instance.</param>
		/// <param name="result">A <see cref="QuaternionF"/> instance to hold the result.</param>
		public static void Subtract(QuaternionF a, QuaternionF b, ref QuaternionF result)
		{
			result.W = a.W - b.W;
			result.X = a.X - b.X;
			result.Y = a.Y - b.Y;
			result.Z = a.Z - b.Z;
		}
		/// <summary>
		/// Multiplies quaternion <paramref name="a"/> by quaternion <paramref name="b"/>.
		/// </summary>
		/// <param name="a">A <see cref="QuaternionF"/> instance.</param>
		/// <param name="b">A <see cref="QuaternionF"/> instance.</param>
		/// <returns>A new <see cref="QuaternionF"/> containing the result.</returns>
		public static QuaternionF Multiply(QuaternionF a, QuaternionF b)
		{
			QuaternionF result = new QuaternionF();
			result.W = a.W * b.W - a.X * b.X - a.Y * b.Y - a.Z * b.Z;
			result.X = a.W * b.X + a.X * b.W + a.Y * b.Z - a.Z * b.Y;
			result.Y = a.W * b.Y + a.Y * b.W + a.Z * b.X - a.X * b.Z;
			result.Z = a.W * b.Z + a.Z * b.W + a.X * b.Y - a.Y * b.X;

			return result;
		}
		/// <summary>
		/// Multiplies quaternion <paramref name="a"/> by quaternion <paramref name="b"/> and put the result in a third quaternion.
		/// </summary>
		/// <param name="a">A <see cref="QuaternionF"/> instance.</param>
		/// <param name="b">A <see cref="QuaternionF"/> instance.</param>
		/// <param name="result">A <see cref="QuaternionF"/> instance to hold the result.</param>
		public static void Multiply(QuaternionF a, QuaternionF b, ref QuaternionF result)
		{
			result.W = a.W * b.W - a.X * b.X - a.Y * b.Y - a.Z * b.Z;
			result.X = a.W * b.X + a.X * b.W + a.Y * b.Z - a.Z * b.Y;
			result.Y = a.W * b.Y + a.Y * b.W + a.Z * b.X - a.X * b.Z;
			result.Z = a.W * b.Z + a.Z * b.W + a.X * b.Y - a.Y * b.X;
		}
		/// <summary>
		/// Multiplies a quaternion by a scalar.
		/// </summary>
		/// <param name="q">A <see cref="QuaternionF"/> instance.</param>
		/// <param name="s">A scalar.</param>
		/// <returns>A <see cref="QuaternionF"/> instance to hold the result.</returns>
		public static QuaternionF Multiply(QuaternionF q, float s)
		{
			QuaternionF result = new QuaternionF(q);
			result.W *= s;
			result.X *= s;
			result.Y *= s;
			result.Z *= s;

			return result;
		}
		/// <summary>
		/// Multiplies a quaternion by a scalar and put the result in a third quaternion.
		/// </summary>
		/// <param name="q">A <see cref="QuaternionF"/> instance.</param>
		/// <param name="s">A scalar.</param>
		/// <param name="result">A <see cref="QuaternionF"/> instance to hold the result.</param>
		public static void Multiply(QuaternionF q, float s, ref QuaternionF result)
		{
			result.W = q.W * s;
			result.X = q.X * s;
			result.Y = q.Y * s;
			result.Z = q.Z * s;
		}
		/// <summary>
		/// Divides a quaternion by a scalar.
		/// </summary>
		/// <param name="q">A <see cref="QuaternionF"/> instance.</param>
		/// <param name="s">A scalar.</param>
		/// <returns>A <see cref="QuaternionF"/> instance to hold the result.</returns>
		public static QuaternionF Divide(QuaternionF q, float s)
		{
			if(s == 0) 
			{
				throw new DivideByZeroException( "Dividing quaternion by zero" );
			}

			QuaternionF result = new QuaternionF(q);

			result.W /= s;
			result.X /= s;
			result.Y /= s;
			result.Z /= s;

			return result;
		}
		/// <summary>
		/// Divides a quaternion by a scalar and put the result in a third quaternion.
		/// </summary>
		/// <param name="q">A <see cref="QuaternionF"/> instance.</param>
		/// <param name="s">A scalar.</param>
		/// <param name="result">A <see cref="QuaternionF"/> instance to hold the result.</param>
		public static void Divide(QuaternionF q, float s, ref QuaternionF result)
		{
			if(s == 0) 
			{
				throw new DivideByZeroException( "Dividing quaternion by zero" );
			}

			result.W = q.W / s;
			result.X = q.X / s;
			result.Y = q.Y / s;
			result.Z = q.Z / s;
		}
	
		/// <summary>
		/// Calculates the dot product of two quaternions.
		/// </summary>
		/// <param name="a">A <see cref="QuaternionF"/> instance.</param>
		/// <param name="b">A <see cref="QuaternionF"/> instance.</param>
		/// <returns>The dot product value.</returns>
		public static float Dot(QuaternionF a, QuaternionF b)
		{
			return a.W * b.W + a.X * b.X + a.Y * b.Y + a.Z * b.Z;
		}
		/// <summary>
		/// Calculates the logarithm of a given quaternion.
		/// </summary>
		/// <param name="a">A <see cref="QuaternionF"/> instance.</param>
		/// <returns>The quaternion's logarithm.</returns>
		public static QuaternionF Log(QuaternionF a)
		{
			QuaternionF result = new QuaternionF(0.0f,0.0f,0.0f,0.0f);

			if (MathFunctions.Abs(a.W) < 1.0f)
			{
				float angle = (float)System.Math.Acos(a.W);
				float sin = (float)System.Math.Sin(angle);

				if (MathFunctions.Abs(sin) >= 0.0f)
				{
					float coeff = angle / sin;
					result.X = coeff * a.X;
					result.Y = coeff * a.Y;
					result.Z = coeff * a.Z;
				}
				else
				{
					result.X = a.X;
					result.Y = a.Y;
					result.Z = a.Z;
				}
			}

			return result;
		}
		/// <summary>
		/// Calculates the exponent of a quaternion.
		/// </summary>
		/// <param name="a">A <see cref="QuaternionF"/> instance.</param>
		/// <returns>The quaternion's exponent.</returns>
		public QuaternionF Exp(QuaternionF a)
		{
			QuaternionF result = new QuaternionF(0.0f,0.0f,0.0f,0.0f);

			float angle = (float)System.Math.Sqrt(a.X*a.X + a.Y*a.Y + a.Z*a.Z);
			float sin = (float)System.Math.Sin(angle);

			if (MathFunctions.Abs(sin) > 0.0f)
			{
				float coeff = angle / sin;
				result.X = coeff * a.X;
				result.Y = coeff * a.Y;
				result.Z = coeff * a.Z;
			}
			else
			{
				result.X = a.X;
				result.Y = a.Y;
				result.Z = a.Z;
			}

			return result;
		}
		/// <summary>
		/// Converts a given <see cref="QuaternionF"/> to a matrix.
		/// </summary>
		/// <param name="q">A <see cref="QuaternionF"/> instance.</param>
		/// <returns>A new <see cref="Matrix4F"/> instance.</returns>
		public static Matrix4F QuaternionToMatrix(QuaternionF q) 
		{
			float x = q.X;
			float y = q.Y;
			float z = q.Z;
			float w = q.W;
			float xx = x * x;
			float yy = y * y;
			float zz = z * z;
			float xy = x * y;
			float xz = x * z;
			float yz = y * z;
			float wx = w * x;
			float wy = w * y;
			float wz = w * z;
			return new Matrix4F(
				1.0f - 2.0f * yy - 2.0f * zz,	2.0f * xy - 2.0f * wz,     
				2.0f * xz + 2.0f * wy,			0.0f,
				2.0f * xy + 2.0f * wz,			1.0f - 2.0f * xx - 2.0f * zz,
				2.0f * yz - 2.0f * wx,			0.0f,
				2.0f * xz - 2.0f * wy,			2.0f * yz + 2.0f * wx,     
				1.0f - 2.0f * xx - 2.0f * yy,	0.0f,
				0.0f,							0.0f,                    
				0.0f,							1.0f);
		}
		
		/// <summary>
		/// Turn an axis and an angle to a quaternion.
		/// </summary>
		/// <param name="axis">A unit <see cref="Vector3F"/> instance.</param>
		/// <param name="angle">An angle.</param>
		/// <returns>A new <see cref="QuaternionF"/> instance.</returns>
		public static QuaternionF FromAxisAngle(Vector3F axis, float angle) 
		{
			float halfAngle = angle / 2.0f;
			float sin = (float)System.Math.Sin(halfAngle);
			return new QuaternionF((float)System.Math.Cos(halfAngle), axis.X * sin, axis.Y * sin, axis.Z * sin);
		}
		#endregion

		#region Public Methods
		/// <summary>
		/// Gets the modulus of the quaternion.
		/// </summary>
		/// <returns>
		/// The modulus of the quaternion:  sqrt(w*w + x*x + y*y + z*z).
		/// </returns>
		public float GetModulus()
		{
			return (float)System.Math.Sqrt(_w*_w + _x*_x + _y*_y + _z*_z);
		}
		/// <summary>
		/// Gets the squared modulus of the quaternion.
		/// </summary>
		/// <returns>
		/// The squared modulus of the quaternion:  (w*w + x*x + y*y + z*z).
		/// </returns>
		public float GetModulusSquared()
		{
			return (_w*_w + _x*_x + _y*_y + _z*_z);
		}
		/// <summary>
		/// Gets the conjugate of the quaternion.
		/// </summary>
		/// <returns>
		/// The conjugate of the quaternion.
		/// </returns>
		public QuaternionF GetConjugate()
		{
			return new QuaternionF(_w, -_x, -_y, -_z);
		}
		/// <summary>
		/// Inverts the quaternion.
		/// </summary>
		public void Inverse()
		{
			float norm = GetModulusSquared();
			if (norm > 0)
			{
				float invNorm = 1.0f / norm;
				_w *=  invNorm;
				_x *= -invNorm;
				_y *= -invNorm;
				_z *= -invNorm;
			}
			else
			{
				throw new QuaternionNotInvertibleException("Quaternion "+this.ToString()+" is not invertable");
			}
		}
		
		/// <summary>
		/// Normelizes the quaternion.
		/// </summary>
		public void Normalize()
		{
			float norm = GetModulus();
			if (norm == 0)
			{
				throw new DivideByZeroException("Trying to normalize a quaternion with modulus of zero.");
			}

			_w /= norm;
			_x /= norm;
			_y /= norm;
			_z /= norm;
		}
		/// <summary>
		/// Clamps quaternion values to zero using a given tolerance value.
		/// </summary>
		/// <param name="tolerance">The tolerance to use.</param>
		/// <remarks>
		/// The quaternion values that are close to zero within the given tolerance are set to zero.
		/// </remarks>
		public void ClampZero(float tolerance)
		{
			_x = MathFunctions.Clamp(_x, 0.0f, tolerance);
			_y = MathFunctions.Clamp(_y, 0.0f, tolerance);
			_z = MathFunctions.Clamp(_z, 0.0f, tolerance);
			_w = MathFunctions.Clamp(_w, 0.0f, tolerance);
		}
		/// <summary>
		/// Clamps quaternion values to zero using the default tolerance value.
		/// </summary>
		/// <remarks>
		/// The quaternion values that are close to zero within the given tolerance are set to zero.
		/// The tolerance value used is <see cref="MathFunctions.EpsilonF"/>
		/// </remarks>
		public void ClampZero()
		{
			_x = MathFunctions.Clamp(_x, 0.0f);
			_y = MathFunctions.Clamp(_y, 0.0f);
			_z = MathFunctions.Clamp(_z, 0.0f);
			_w = MathFunctions.Clamp(_w, 0.0f);
		}
		#endregion

		#region Overrides
		/// <summary>
		/// Returns the hashcode for this instance.
		/// </summary>
		/// <returns>A 32-bit signed integer hash code.</returns>
		public override int GetHashCode()
		{
			return _w.GetHashCode() ^ _x.GetHashCode() ^ _y.GetHashCode() ^ _z.GetHashCode();
		}
		/// <summary>
		/// Returns a value indicating whether this instance is equal to
		/// the specified object.
		/// </summary>
		/// <param name="obj">An object to compare to this instance.</param>
		/// <returns><see langword="true"/> if <paramref name="obj"/> is a <see cref="QuaternionF"/> and has the same values as this instance; otherwise, <see langword="false"/>.</returns>
		public override bool Equals(object obj)
		{
			if (obj is QuaternionF)
			{
				QuaternionF q = (QuaternionF)obj;
				return (_w == q.W) && (_x == q.X) && (_y == q.Y) && (_z == q.Z);
			}
			return false;
		}

		/// <summary>
		/// Returns a string representation of this object.
		/// </summary>
		/// <returns>A string representation of this object.</returns>
		public override string ToString()
		{
			return string.Format("({0}, {1}, {2}, {3})", _w, _x, _y, _z);
		}
		#endregion

		#region Comparison Operators
		/// <summary>
		/// Tests whether two specified quaternions are equal.
		/// </summary>
		/// <param name="a">The left-hand quaternion.</param>
		/// <param name="b">The right-hand quaternion.</param>
		/// <returns><see langword="true"/> if the two quaternions are equal; otherwise, <see langword="false"/>.</returns>
		public static bool operator==(QuaternionF a, QuaternionF b)
		{
			return ValueType.Equals(a,b);
		}
		/// <summary>
		/// Tests whether two specified quaternions are not equal.
		/// </summary>
		/// <param name="a">The left-hand quaternion.</param>
		/// <param name="b">The right-hand quaternion.</param>
		/// <returns><see langword="true"/> if the two quaternions are not equal; otherwise, <see langword="false"/>.</returns>
		public static bool operator!=(QuaternionF a, QuaternionF b)
		{
			return !ValueType.Equals(a,b);
		}

		#endregion

		#region Binary Operators
		/// <summary>
		/// Adds two quaternions.
		/// </summary>
		/// <param name="a">A <see cref="QuaternionF"/> instance.</param>
		/// <param name="b">A <see cref="QuaternionF"/> instance.</param>
		/// <returns>A new <see cref="QuaternionF"/> instance containing the sum.</returns>
		public static QuaternionF operator+(QuaternionF a, QuaternionF b)
		{
			return QuaternionF.Add(a,b);
		}
		/// <summary>
		/// Subtracts a quaternion from a quaternion.
		/// </summary>
		/// <param name="a">A <see cref="QuaternionF"/> instance.</param>
		/// <param name="b">A <see cref="QuaternionF"/> instance.</param>
		/// <returns>A new <see cref="QuaternionF"/> instance containing the difference.</returns>
		public static QuaternionF operator-(QuaternionF a, QuaternionF b)
		{
			return QuaternionF.Subtract(a,b);
		}
		/// <summary>
		/// Multiplies quaternion <paramref name="a"/> by quaternion <paramref name="b"/>.
		/// </summary>
		/// <param name="a">A <see cref="QuaternionF"/> instance.</param>
		/// <param name="b">A <see cref="QuaternionF"/> instance.</param>
		/// <returns>A new <see cref="QuaternionF"/> containing the result.</returns>
		public static QuaternionF operator*(QuaternionF a, QuaternionF b)
		{
			return QuaternionF.Multiply(a,b);
		}
		/// <summary>
		/// Multiplies a quaternion by a scalar.
		/// </summary>
		/// <param name="q">A <see cref="QuaternionF"/> instance.</param>
		/// <param name="s">A scalar.</param>
		/// <returns>A <see cref="QuaternionF"/> instance to hold the result.</returns>
		public static QuaternionF operator*(QuaternionF q, float s)
		{
			return QuaternionF.Multiply(q,s);
		}
		/// <summary>
		/// Multiplies a quaternion by a scalar.
		/// </summary>
		/// <param name="q">A <see cref="QuaternionF"/> instance.</param>
		/// <param name="s">A scalar.</param>
		/// <returns>A <see cref="QuaternionF"/> instance to hold the result.</returns>
		public static QuaternionF operator*(float s, QuaternionF q)
		{
			return QuaternionF.Multiply(q,s);
		}
		/// <summary>
		/// Divides a quaternion by a scalar.
		/// </summary>
		/// <param name="q">A <see cref="QuaternionF"/> instance.</param>
		/// <param name="s">A scalar.</param>
		/// <returns>A <see cref="QuaternionF"/> instance to hold the result.</returns>
		public static QuaternionF operator/(QuaternionF q, float s)
		{
			return QuaternionF.Divide(q,s);
		}
		/// <summary>
		/// Divides a scalar by a quaternion.
		/// </summary>
		/// <param name="q">A <see cref="QuaternionF"/> instance.</param>
		/// <param name="s">A scalar.</param>
		/// <returns>A <see cref="QuaternionF"/> instance to hold the result.</returns>
		public static QuaternionF operator/(float s, QuaternionF q)
		{
			return QuaternionF.Multiply(q, 1/s);
		}
		#endregion

		#region Array Indexing Operator
		/// <summary>
		/// Indexer ( [w, x, y, z] ).
		/// </summary>
		public float this[int index] 
		{
			get	
			{
				switch( index ) 
				{
					case 0:
						return _w;
					case 1:
						return _x;
					case 2:
						return _y;
					case 3:
						return _z;
					default:
						throw new IndexOutOfRangeException();
				}
			}
			set 
			{
				switch( index ) 
				{
					case 0:
						_w = value;
						break;
					case 1:
						_x = value;
						break;
					case 2:
						_y = value;
						break;
					case 3:
						_z = value;
						break;
					default:
						throw new IndexOutOfRangeException();
				}
				return;
			}
		}
		#endregion

		#region Conversion Operators
		/// <summary>
		/// Converts the quaternion to an array of single-precision floating point numbers.
		/// </summary>
		/// <param name="q">A <see cref="QuaternionF"/> instance.</param>
		/// <returns>An array of single-precision floating point numbers.</returns>
		/// <remarks>The array is [w, x, y, z].</remarks>
		public static explicit operator float[](QuaternionF q)
		{
			float[] floats = new float[4];
			floats[0] = q.W;
			floats[1] = q.X;
			floats[2] = q.Y;
			floats[3] = q.Z;
			return	floats;
		}
		/// <summary>
		/// Converts the quaternion to an array of single-precision floating point numbers.
		/// </summary>
		/// <param name="q">A <see cref="QuaternionF"/> instance.</param>
		/// <returns>An array of single-precision floating point numbers.</returns>
		/// <remarks>The array is [w, x, y, z].</remarks>
		public static explicit operator FloatArrayList(QuaternionF q)
		{
			FloatArrayList floats = new FloatArrayList(4);
			floats[0] = q.W;
			floats[1] = q.X;
			floats[2] = q.Y;
			floats[3] = q.Z;
			return	floats;
		}

		#endregion
	}

	#region QuaternionFConverter class
	/// <summary>
	/// Converts a <see cref="QuaternionF"/> to and from string representation.
	/// </summary>
	public class QuaternionFConverter : ExpandableObjectConverter
	{
		/// <summary>
		/// Returns whether this converter can convert an object of the given type to the type of this converter, using the specified context.
		/// </summary>
		/// <param name="context">An <see cref="ITypeDescriptorContext"/> that provides a format context.</param>
		/// <param name="sourceType">A <see cref="Type"/> that represents the type you want to convert from.</param>
		/// <returns><b>true</b> if this converter can perform the conversion; otherwise, <b>false</b>.</returns>
		public override bool CanConvertFrom(ITypeDescriptorContext context, Type sourceType)
		{
			if (sourceType == typeof(string))
				return true;

			return base.CanConvertFrom (context, sourceType);
		}
		/// <summary>
		/// Returns whether this converter can convert the object to the specified type, using the specified context.
		/// </summary>
		/// <param name="context">An <see cref="ITypeDescriptorContext"/> that provides a format context.</param>
		/// <param name="destinationType">A <see cref="Type"/> that represents the type you want to convert to.</param>
		/// <returns><b>true</b> if this converter can perform the conversion; otherwise, <b>false</b>.</returns>
		public override bool CanConvertTo(ITypeDescriptorContext context, Type destinationType)
		{
			if (destinationType == typeof(string))
				return true;

			return base.CanConvertTo (context, destinationType);
		}
		/// <summary>
		/// Converts the given value object to the specified type, using the specified context and culture information.
		/// </summary>
		/// <param name="context">An <see cref="ITypeDescriptorContext"/> that provides a format context.</param>
		/// <param name="culture">A <see cref="System.Globalization.CultureInfo"/> object. If a null reference (Nothing in Visual Basic) is passed, the current culture is assumed.</param>
		/// <param name="value">The <see cref="Object"/> to convert.</param>
		/// <param name="destinationType">The Type to convert the <paramref name="value"/> parameter to.</param>
		/// <returns>An <see cref="Object"/> that represents the converted value.</returns>
		public override object ConvertTo(ITypeDescriptorContext context, System.Globalization.CultureInfo culture, object value, Type destinationType)
		{
			if ((destinationType == typeof(string)) && (value is QuaternionF))
			{
				QuaternionF q = (QuaternionF)value;
				return q.ToString();
			}

			return base.ConvertTo (context, culture, value, destinationType);
		}
		/// <summary>
		/// Converts the given object to the type of this converter, using the specified context and culture information.
		/// </summary>
		/// <param name="context">An <see cref="ITypeDescriptorContext"/> that provides a format context.</param>
		/// <param name="culture">The <see cref="System.Globalization.CultureInfo"/> to use as the current culture. </param>
		/// <param name="value">The <see cref="Object"/> to convert.</param>
		/// <returns>An <see cref="Object"/> that represents the converted value.</returns>
		/// <exception cref="ParseException">Failed parsing from string.</exception>
		public override object ConvertFrom(ITypeDescriptorContext context, System.Globalization.CultureInfo culture, object value)
		{
			if (value.GetType() == typeof(string))
			{
				return QuaternionF.Parse((string)value);
			}

			return base.ConvertFrom (context, culture, value);
		}

		/// <summary>
		/// Returns whether this object supports a standard set of values that can be picked from a list.
		/// </summary>
		/// <param name="context">An <see cref="ITypeDescriptorContext"/> that provides a format context.</param>
		/// <returns><b>true</b> if <see cref="GetStandardValues"/> should be called to find a common set of values the object supports; otherwise, <b>false</b>.</returns>
		public override bool GetStandardValuesSupported(ITypeDescriptorContext context)
		{
			return true;
		}

		/// <summary>
		/// Returns a collection of standard values for the data type this type converter is designed for when provided with a format context.
		/// </summary>
		/// <param name="context">An <see cref="ITypeDescriptorContext"/> that provides a format context that can be used to extract additional information about the environment from which this converter is invoked. This parameter or properties of this parameter can be a null reference.</param>
		/// <returns>A <see cref="TypeConverter.StandardValuesCollection"/> that holds a standard set of valid values, or a null reference (Nothing in Visual Basic) if the data type does not support a standard set of values.</returns>
		public override System.ComponentModel.TypeConverter.StandardValuesCollection GetStandardValues(ITypeDescriptorContext context)
		{
			StandardValuesCollection svc = 
				new StandardValuesCollection(new object[6] {QuaternionF.Zero, QuaternionF.Identity, QuaternionF.XAxis, QuaternionF.YAxis, QuaternionF.ZAxis, QuaternionF.WAxis} );

			return svc;
		}
	}
	#endregion


}
