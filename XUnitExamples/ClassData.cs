using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace XUnitExamples
{
    public class ClassTestDataForAdd : IEnumerable<object[]>
    {
        public IEnumerator<object[]> GetEnumerator()
        {
            yield return new object[] { 1, '/', 1, 1.0 };
            yield return new object[] { 1, '/', 2, 0.5 };
            yield return new object[] { 1, '/', 2, 0.5 };
            yield return new object[] { 1, '/', 0, new DivideByZeroException() };
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }
    }
    public class ClassTestDataForCollections : IEnumerable<object[]>
    {
        public IEnumerator<object[]> GetEnumerator()
        {
            yield return new object[] { 8 };
            yield return new object[] { 9 };
            yield return new object[] { 10 };
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }
    }
}
