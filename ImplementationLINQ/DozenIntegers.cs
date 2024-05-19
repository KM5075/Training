using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ImplementationLINQ
{
    public class DozenIntegers : IEnumerable<int>
    {
        private const int MAX = 12;

        private int[] data = new int[MAX];

        public void Set(int index, int value)
        {
            if( index >= MAX || 0 > index) { throw new ArgumentOutOfRangeException("index"); }
            data[index] = value;
        }

        public int Get(int index)
        {
            if (index >= MAX || 0 > index) { throw new ArgumentOutOfRangeException("index"); }
            return data[index];
        }

        // 自身のEnumeratorを返す
        public IEnumerator<int> GetEnumerator()
        {
            return new Enumerator(this);
        }

        // IEnumerableのGetEnumeratorも実装する。
        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }

        // GetEnumeratorで返されるEnumeratorクラス
        public class Enumerator : IEnumerator<int>
        {
            DozenIntegers source;// GetEnumeratorを呼ばれたDozenIntegersオブジェクト

            int index = -1;

            public Enumerator(DozenIntegers source)
            {
                this.source = source;
            }

            // 現在の位置から次の位置に移動する。
            public bool MoveNext()
            {
                if(index > MAX) 
                    return false;

                ++index;

                // 最大値を超えていなければデータがあるのでTrueを返す。
                return MAX > index;
            }

            // 現在の位置のデータを取得して返す。
            public int Current { get { return source.Get(index); } }

            // IEnumeratorのCurrentも実装する。
            object IEnumerator.Current { get { return Current; } }

            // Enumeratorを使い終わったあとの処理。ここでは何もしない。
            public void Dispose() { }

            // 最初の位置に戻る
            public void Reset() { throw new NotImplementedException(); }
        }
    }
}
