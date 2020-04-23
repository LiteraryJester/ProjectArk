using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TMPro;
using UnityEngine;

namespace Assets.GameEntities.UI
{
    public class ModuleLineDisplay : MonoBehaviour
    {
        public string Id;
        public TextMeshProUGUI ModuleName;
        public TextMeshProUGUI ModuleValue;
        public TextMeshProUGUI ModuleInProductionValue;
        private string _name;

        public void Init(string name)
        {
            _name = name;
        }
        void Start()
        {
            ModuleName.text = _name;
            ModuleValue.text = "0";
            ModuleInProductionValue.text = "0";
        }
    }
}
