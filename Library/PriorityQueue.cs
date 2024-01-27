namespace Library;

public class PriorityQueue<T>
    {
        readonly List<T> heap = new List<T>();
        readonly Comparison<T> cmp;

        /// <summary>
        /// デフォルトの比較子を使用してインスタンスを初期化します．
        /// </summary>
        /// <remarks>この操作は O(1) で実行されます．</remarks>
        public PriorityQueue()
        {
            cmp = Comparer<T>.Default.Compare;
        }

        /// <summary>
        /// デリゲートで表されるような比較関数を使用してインスタンスを初期化します．
        /// </summary>
        /// <param name="comparison"></param>
        /// <remarks>この操作は O(1) で実行されます．</remarks>
        public PriorityQueue(Comparison<T> comparison)
        {
            cmp = comparison;
        }

        /// <summary>
        /// 指定された比較子を使用してインスタンスを初期化します．
        /// </summary>
        /// <param name="comparer"></param>
        /// <remarks>この操作は O(1) で実行されます．</remarks>
        public PriorityQueue(IComparer<T> comparer)
        {
            cmp = comparer.Compare;
        }

        /// <summary>
        /// 優先度付きキューに要素を追加します．
        /// </summary>
        /// <param name="item">優先度付きキューに追加される要素</param>
        /// <remarks>最悪計算量 O(log N) で実行されます．</remarks>
        public void Enqueue(T item)
        {
            var pos = heap.Count;
            heap.Add(item);
            while (pos > 0)
            {
                var par = (pos - 1) / 2;
                if (cmp(heap[par], item) <= 0)
                    break;
                heap[pos] = heap[par];
                pos = par;
            }

            heap[pos] = item;
        }

        /// <summary>
        /// 優先度付きキューから最も価値が低い要素を削除し，返します．
        /// </summary>
        /// <returns>優先度付きキューから削除された要素．</returns>
        /// <remarks>最悪計算量 O(log N) で実行されます．</remarks>
        public T Dequeue()
        {
            var ret = heap[0];
            var pos = 0;
            var x = heap[heap.Count - 1];

            while (pos * 2 + 1 < heap.Count - 1)
            {
                var lch = pos * 2 + 1;
                var rch = pos * 2 + 2;
                if (rch < heap.Count - 1 && cmp(heap[rch], heap[lch]) < 0) lch = rch;
                if (cmp(heap[lch], x) >= 0)
                    break;
                heap[pos] = heap[lch];
                pos = lch;
            }

            heap[pos] = x;
            heap.RemoveAt(heap.Count - 1);
            return ret;
        }

        /// <summary>
        ///  優先度付きキューに含まれる最も価値が低い要素を削除せずに返します．
        /// </summary>
        /// <returns>優先度付きキューに含まれる最も価値が低い要素．</returns>
        /// <remarks>この操作は O(1) で実行されます．</remarks>
        public T Peek()
        {
            return heap[0];
        }

        /// <summary>
        /// 優先度付きキュー内の要素の数を取得します．
        /// </summary>
        /// <returns>優先度付キュー内にある要素の数</returns>
        /// <remarks>最悪計算量 O(1) で実行されます．</remarks>
        public int Count
        {
            get { return heap.Count; }
        }

        /// <summary>
        /// 優先度付きキュー内に要素が存在するかどうかを O(1) で判定します．
        /// </summary>
        /// <returns>優先度付キュー内にある要素が存在するならば true，そうでなければ　false．</returns>
        /// <remarks>この操作は O(1) で実行されます．</remarks>
        public bool Any()
        {
            return heap.Count > 0;
        }

        /// <summary>
        /// 優先度付きキューに含まれる要素を昇順に並べて返します．
        /// </summary>
        /// <remarks>この操作は計算量 O(N log N)で実行されます．</remarks>
        public T[] Items
        {
            get
            {
                var ret = heap.ToArray();
                Array.Sort(ret, cmp);
                return ret;
            }
        }
    }
    