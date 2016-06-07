﻿/*
	Author: Dominik Steffen
	E-Mail: dominik.steffen@hs-furtwangen.de, dominik.steffen@gmail.com
	Bachelor Thesis Summer Semester 2013
	'Computer Science in Media'
	Project: LinqForGeometry
	Professors:
	Mr. Prof. C. Müller
	Mr. Prof. W. Walter
*/

namespace LinqForGeometry.Core.Handles
{

    /// <summary>
    /// This is a handle struct for an 'Edge'.
    /// If invalid, the handle is -1. If the value is 0 it is a valid handle. (Because it's a possible valid array index)
    /// </summary>
    public struct HandleEdge
    {
        internal int _DataIndex;

        /// <summary>
        /// Constructor for this struct.
        /// </summary>
        /// <param name="index">An array style index pointing to the real data container</param>
        internal HandleEdge(int index)
        {
            _DataIndex = index;
        }

        /// <summary>
        /// Implicitly converts the Handle to an integer value.
        /// </summary>
        /// <param name="handle">Expects a 'HandleFace' struct as param.</param>
        /// <returns>Returns an int 'adress' value.</returns>
        public static implicit operator int(HandleEdge handle)
        {
            return handle._DataIndex;
        }

        /// <summary>
        /// This 'object' is valid when the _DataIndex is >= 0
        /// </summary>
        public bool isValid
        {
            get { return _DataIndex >= 0; }
        }
    }
}