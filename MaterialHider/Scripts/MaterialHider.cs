using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace XOAProductions.Utility
{
    /// <summary>
    /// a quick little script that can turn entire hierarchies of renderers invisible/visible
    /// </summary>
    public class MaterialHider
    {

        /// <summary>
        /// Turns the hierarchy of renderers invisible
        /// </summary>
        /// <param name="go">the gameobject who's own renderer and all child renderers should be hidden</param>
        /// <param name="id">assign a id to the parts that will be hidden, so you can later turn only those renderers back on that you want</param>
       public void HideHierarchy(GameObject go, string id)
        {
           Renderer[] renderers =  go.GetComponentsInChildren<Renderer>();
           
           foreach(Renderer r in renderers)
            {
                MaterialHiderBackup backup = r.gameObject.AddComponent<MaterialHiderBackup>();
                backup.id = id;
                backup.savedMaterials = new List<Material>(r.materials);
                Material[] mats = r.materials;

                for(int i = 0; i < r.materials.Length; i++)
                {
                    mats[i] = getInvisibleMaterial();
                }

                r.materials = mats;
            }

        }

       /// <summary>
        /// Makes a previously hidden hierachry visible again
        /// </summary>
        /// <param name="go">the gameobject who's childrenderers and own renderer has been hidden previously</param>
        /// <param name="id">the id that you specified when calling hidehierarchy</param>
       public void DisplayHierarchy(GameObject go, string id)
        {
            MaterialHiderBackup[] backups = go.GetComponentsInChildren<MaterialHiderBackup>();

            foreach(MaterialHiderBackup b in backups)
            {
                if (b.id != id)
                    continue;

                var renderer = b.GetComponent<Renderer>();
                renderer.materials = b.savedMaterials.ToArray();

                
            }

            foreach (MaterialHiderBackup b in backups)
            {
                if (b.id != id)
                    continue;

                Object.Destroy(b);
            }
        }

        /// <summary>
        /// the material that's used to make renderers invisible
        /// </summary>
        /// <returns>an invisible material from Resources/Materials/Invisible.mat</returns>
        public Material getInvisibleMaterial()
        {
            return Resources.Load<Material>("Materials/Invisible");
        }
 
    }
}
