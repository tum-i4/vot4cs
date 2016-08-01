using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleCalculator
{
    //    public interface IReadOnlyList<out T> : IReadOnlyCollection<T> {
    //    T this[int index] { get; }
    //    }
    //    public interface IReadOnlyCollection<out T> : IEnumerable<T> {
    //        int Count { get; }
    //    }
    //    public interface IEnumerable<out T> : IEnumerable {
    //        IEnumerator<T> GetEnumerator();
    //    }
    /*
     * http://twistedoakstudios.com/blog/Post774_anonymous-implementation-classes-a-design-pattern-for-c
     */
    public sealed class AnonymousReadOnlyList<T> : IReadOnlyList<T>
    {
        private readonly Func<int> _count;
        private readonly Func<int, T> _item;
        private readonly IEnumerable<T> _iterator;
        public AnonymousReadOnlyList(Func<int> count, Func<int, T> item, IEnumerable<T> iterator = null)
        {
            if (count == null)
                throw new ArgumentNullException("count");
            if (item == null)
                throw new ArgumentNullException("item");
            this._count = count;
            this._item = item;
            this._iterator = iterator ?? DefaultIterator(count, item);
        }

        private static IEnumerable<T> DefaultIterator(Func<int> count, Func<int, T> item)
        {
            var n = count();
            for (var i = 0; i < n; i++)
                yield return item(i);
        }

        public int Count
        {
            get
            {
                return _count();
            }
        }

        public T this[int index]
        {
            get
            {
                return _item(index);
            }
        }

        public IEnumerator<T> GetEnumerator()
        {
            return _iterator.GetEnumerator();
        }

        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }
}

    public static class ListInterfaces
    {
        public static IReadOnlyList<TOut> Select<TIn, TOut>(this IReadOnlyList<TIn> list, Func<TIn, TOut> projection)
        {
            return new AnonymousReadOnlyList<TOut>(count: () => list.Count, item: i => projection(list[i]),
                iterator: list.AsEnumerable().Select(projection));
        }

        public static IReadOnlyList<TOut> Select<TIn, TOut>(this IReadOnlyList<TIn> list,
            Func<TIn, int, TOut> projection)
        {
            return new AnonymousReadOnlyList<TOut>(count: () => list.Count, item: i => projection(list[i], i),
                iterator: list.AsEnumerable().Select(projection));
        }

        public static IReadOnlyList<T> Reverse<T>(this IReadOnlyList<T> list)
        {
            return new AnonymousReadOnlyList<T>(count: () => list.Count, item: i => list[list.Count - 1 - i]);
        }

        public static IReadOnlyList<TOut> Zip<TIn1, TIn2, TOut>(this IReadOnlyList<TIn1> list1,
            IReadOnlyList<TIn2> list2, Func<TIn1, TIn2, TOut> projection)
        {
            return new AnonymousReadOnlyList<TOut>(count: () => Math.Min(list1.Count, list2.Count),
                item: i => projection(list1[i], list2[i]), iterator: list1.AsEnumerable().Zip(list2, projection));
        }

        public static IReadOnlyList<int> Range(this int count)
        {
            return new AnonymousReadOnlyList<int>(count: () => count, item: i => i, iterator: Enumerable.Range(0, count));
        }

        public static void TestList()
        {
            List<String> list = new List<string>()
            {
                "a",
                "b",
                "c",
                "d",
                "e",
                "f",
                "g"
            }

                ;
            var reversed = list.AsReadOnly().Reverse();
            Console.WriteLine(reversed);
            var list2 = new List<string>()
            {
                "a",
                "c",
                "a",
                "F",
                "A"
            }

                ;
            Console.WriteLine(list.Distinct(new LambdaComparer<string>((a, b) => a == b)));
        }

    }

    public class LambdaComparer<T> : IEqualityComparer<T>
    {
        private readonly Func<T, T, bool> _lambdaComparer;
        private readonly Func<T, int> _lambdaHash;

        public LambdaComparer(Func<T, T, bool> lambdaComparer)
            : this(lambdaComparer, EqualityComparer<T>.Default.GetHashCode)
        {
        }

        public LambdaComparer(Func<T, T, bool> lambdaComparer, Func<T, int> lambdaHash)
        {
            if (lambdaComparer == null)
                throw new ArgumentNullException("lambdaComparer");
            if (lambdaHash == null)
                throw new ArgumentNullException("lambdaHash");
            _lambdaComparer = lambdaComparer;
            _lambdaHash = lambdaHash;
        }

        public bool Equals(T x, T y)
        {
            return _lambdaComparer(x, y);
        }

        public int GetHashCode(T obj)
        {
            return _lambdaHash(obj);
        }
    }
}