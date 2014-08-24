using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace PortalPatrol
{
    /// <summary>
    /// How to serialize a class.
    /// </summary>
    [Serializable]
    public class myObject
    {
        public int n1 = 0;
        public int n2 = 0;
        public string str = null;
    }
}

/* This code is what goes into Program.cs or wherever the actual serialization occurs.
 * 
 * myObject obj = new myObject();
            obj.n1 = 1;
            obj.n2 = 24;
            obj.str = "Some String";
            IFormatter formatter = new BinaryFormatter();
            Stream stream = new FileStream("MyFile.bin", FileMode.Create, FileAccess.Write, FileShare.None);
            formatter.Serialize(stream, obj);
            stream.Close();
 * 
 */

