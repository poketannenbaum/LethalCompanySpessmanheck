using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

namespace spessmancheeto
{
    public static class AssetBundleExtension
    {
        public static T LoadPersistentAsset<T>(this AssetBundle bundle, string name)
        {
            UnityEngine.Object @object = bundle.LoadAsset(name);
            bool flag = @object != null;   
            T result;
            if (flag)
            {
                @object.hideFlags = HideFlags.DontUnloadUnusedAsset;
                result = (T)((object)@object);
            }
            else
            {
                result = default(T);
            }
            return result;
        }
    }

    public class BundleUtilities
    {

        public static byte[] GetResourceBytes(string filename)
        {
            Assembly executingAssembly = Assembly.GetExecutingAssembly();
            foreach (string text in executingAssembly.GetManifestResourceNames())
            {
                bool flag = text.Contains(filename);
                if (flag)
                {
                    using (Stream manifestResourceStream = executingAssembly.GetManifestResourceStream(text))
                    {
                        bool flag2 = manifestResourceStream == null;
                        if (flag2)
                        {
                            return null;
                        }
                        byte[] array = new byte[manifestResourceStream.Length];
                        manifestResourceStream.Read(array, 0, array.Length);
                        return array;
                    }
                }
            }
            return null;
        }


        public static AssetBundle LoadBundleFromInternalAssembly(string filename)
        {
            return AssetBundle.LoadFromMemory(BundleUtilities.GetResourceBytes(filename));
        }
    }
}

