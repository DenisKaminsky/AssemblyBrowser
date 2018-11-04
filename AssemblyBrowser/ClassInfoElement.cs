using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AssemblyBrowser
{
    //класс - описание категории(нужен для tree view)
    public sealed class ClassInfoElement
    {
        //имя категории
        private string _classification;
        //элементы категории
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
