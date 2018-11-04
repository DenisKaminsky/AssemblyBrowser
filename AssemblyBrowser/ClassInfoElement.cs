using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AssemblyBrowser
{
    public sealed class ClassInfoElement
    {
        private string _classification;
        private List<IField> _elements;

        public string Classification
        {
            get
            {
                return _classification;
            }

            set
            {
                _classification = value;
            }
        }

        public List<IField> ClassificationElements
        {
            get
            {
                return _elements;
            }

            set
            {
                _elements = value;
            }
        }

        public void AddClassificationElement(IField element)
        {
            ClassificationElements.Add(element);
        }

        public ClassInfoElement(string classification, List<IField> elements)
        {
            Classification = classification;
            ClassificationElements = elements;
        }
    }
}
