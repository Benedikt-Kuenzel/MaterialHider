using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace XOAProductions.Utility
{
    /// <summary>
    /// keeps the original materials of the renderer as a backup 
    /// so we can later turn the renderer visible again without issues.
    /// </summary>
    public class MaterialHiderBackup : MonoBehaviour
    {
        //backup for the previous materials 
        public List<Material> savedMaterials = new List<Material>();

        //id so we can mark groups to toggle them
        //helps if you add 2 hierarchies of renderers that have been turned invisible
        //and you just want to turn one of them back on
        public string id;
    }
}
 