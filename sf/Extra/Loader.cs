using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;
using System.Threading.Tasks;
using sf.Features;
using sf.Extra;
using sf.Utils;

namespace sf
{
    public class Loader 
    {
        public static GameObject gameObject;
        public static void Load()
        {
            gameObject = new GameObject();
            UnityEngine.Object.DontDestroyOnLoad(gameObject);
            gameObject.AddComponent<Menu>();
            gameObject.AddComponent<Weapons>();
            gameObject.AddComponent<ESP>();
        }

        public static void Unload()
        {
            UnityEngine.Object.Destroy(gameObject);
        }
    }
}
