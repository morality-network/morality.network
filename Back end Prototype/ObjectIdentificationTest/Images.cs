using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ObjectIdentificationTest
{
    public class Images
    {
        private List<Bitmap> _images;
        public Bitmap[] ImageList => _images?.ToArray();
        private List<string> _classifiers;
        public string[] Classifiers => _classifiers?.ToArray();
        private Dictionary<string, int> _mappedClassifiers;
        public int[] ClassifiersAsNumber => GetClassifiersAsNumbers();
        public List<string> OrderedDistinctClassifiers => _classifiers.Distinct().ToList();

        public Images()
        {
            ResetLists();
        }

        private void ResetLists()
        {
            _images = new List<Bitmap>();
            _mappedClassifiers = new Dictionary<string, int>();
            _classifiers = new List<string>();
        }

        private int[] GetClassifiersAsNumbers()
        {
            var values = new int[_classifiers.Count()];
            var tmpOrderedClassifiers = OrderedDistinctClassifiers;
            for (int i=0;i< _classifiers.Count();i++)
            {
                values[i] = tmpOrderedClassifiers.FindIndex(a => a == _classifiers[i]);
            }
            return values;
        }

        public bool AddImage(Bitmap image, string classifier)
        {
            if (image != null && !string.IsNullOrEmpty(classifier))
            {
                _images.Add(image);
                _classifiers.Add(classifier);
                if (_mappedClassifiers.Keys.Contains(classifier))
                {
                    _mappedClassifiers[classifier] = _mappedClassifiers[classifier] + 1;
                }
                else
                {
                    _mappedClassifiers.Add(classifier, 1);
                }
                return true;
            }
            return false;
        }

        public static double[] MapClassifiers(List<string> strClassifiers)
        {
            var values = new double[strClassifiers.Count()];
            var tmpOrderedClassifiers = strClassifiers
                .Distinct()
                .OrderBy(x => x)
                .ToList();
            for (int i = 0; i < strClassifiers.Count(); i++)
            {
                values[i] = tmpOrderedClassifiers.FindIndex(a => a == strClassifiers[i]);
            }
            return values;
        }

        public int GetDistinctClassifierCount()
        {
            return _classifiers.Distinct().Count();
        }
    }
}
