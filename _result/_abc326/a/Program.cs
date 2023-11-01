using System.Runtime.CompilerServices;
using System.Text;
using Library;

class AtCoder
{
    static void Main(string[] args)
    {
        using var io = new IOManager(Console.OpenStandardInput(), Console.OpenStandardOutput());

        var a = io.ReadInt();
        var b = io.ReadInt();
        
        io.WriteBool(!(a - b > 3 || a - b < -2));
    }
}

namespace Library
{
    public class IOManager : IDisposable
    {
        private readonly BinaryReader _reader;
        private readonly StreamWriter _writer;
        private bool _disposedValue;
        private byte[] _buffer = new byte[1024];
        private int _length;
        private int _cursor;
        private bool _eof;

        const char ValidFirstChar = '!';
        const char ValidLastChar = '~';

        public IOManager(Stream input, Stream output)
        {
            _reader = new BinaryReader(input);
            _writer = new StreamWriter(output) { AutoFlush = false };
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private char ReadAscii()
        {
            if (_cursor == _length)
            {
                _cursor = 0;
                _length = _reader.Read(_buffer);

                if (_length == 0)
                {
                    if (!_eof)
                    {
                        _eof = true;
                        return char.MinValue;
                    }
                    else
                    {
                        ThrowEndOfStreamException();
                    }
                }
            }

            return (char)_buffer[_cursor++];
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public char ReadChar()
        {
            char c;
            while (!IsValidChar(c = ReadAscii())) { }
            return c;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public string ReadString()
        {
            var builder = new StringBuilder();
            char c;
            while (!IsValidChar(c = ReadAscii())) { }

            do
            {
                builder.Append(c);
            } while (IsValidChar(c = ReadAscii()));

            return builder.ToString();
        }

        public int ReadInt() => (int)ReadLong();

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public long ReadLong()
        {
            long result = 0;
            var isPositive = true;
            char c;

            while (!IsNumericChar(c = ReadAscii())) { }

            if (c == '-')
            {
                isPositive = false;
                c = ReadAscii();
            }

            do
            {
                result *= 10;
                result += c - '0';
            } while (IsNumericChar(c = ReadAscii()));

            return isPositive ? result : -result;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private Span<char> ReadChunk(Span<char> span)
        {
            var i = 0;
            char c;
            while (!IsValidChar(c = ReadAscii())) { }

            do
            {
                span[i++] = c;
            } while (IsValidChar(c = ReadAscii()));

            return span.Slice(0, i);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public double ReadDouble() => double.Parse(ReadChunk(stackalloc char[32]));

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public decimal ReadDecimal() => decimal.Parse(ReadChunk(stackalloc char[32]));

        public int[] ReadIntArray(int n)
        {
            var a = new int[n];
            for (int i = 0; i < a.Length; i++)
            {
                a[i] = ReadInt();
            }
            return a;
        }

        public long[] ReadLongArray(int n)
        {
            var a = new long[n];
            for (int i = 0; i < a.Length; i++)
            {
                a[i] = ReadLong();
            }
            return a;
        }

        public double[] ReadDoubleArray(int n)
        {
            var a = new double[n];
            for (int i = 0; i < a.Length; i++)
            {
                a[i] = ReadDouble();
            }
            return a;
        }

        public decimal[] ReadDecimalArray(int n)
        {
            var a = new decimal[n];
            for (int i = 0; i < a.Length; i++)
            {
                a[i] = ReadDecimal();
            }
            return a;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public void Write<T>(T value) => _writer.Write(value?.ToString());

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public void WriteLine<T>(T value) => _writer.WriteLine(value?.ToString());
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public void WriteBool(bool value) => _writer.WriteLine(value ? "Yes" : "No");

        public void WriteLine<T>(IEnumerable<T> values, char separator)
        {
            var e = values.GetEnumerator();
            if (e.MoveNext())
            {
                if (e.Current is null)
                {
                    return;
                }
                
                _writer.Write(e.Current.ToString());

                while (e.MoveNext())
                {
                    _writer.Write(separator);
                    _writer.Write(e.Current.ToString());
                }
            }

            _writer.WriteLine();
        }

        public void WriteLine<T>(T[] values, char separator) => WriteLine((ReadOnlySpan<T>)values, separator);
        public void WriteLine<T>(Span<T> values, char separator) => WriteLine((ReadOnlySpan<T>)values, separator);

        public void WriteLine<T>(ReadOnlySpan<T> values, char separator)
        {
            for (int i = 0; i < values.Length - 1; i++)
            {
                _writer.Write(values[i]);
                _writer.Write(separator);
            }

            if (values.Length > 0)
            {
                _writer.Write(values[^1]);
            }

            _writer.WriteLine();
        }

        public void Flush() => _writer.Flush();

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private static bool IsValidChar(char c) => ValidFirstChar <= c && c <= ValidLastChar;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private static bool IsNumericChar(char c) => ('0' <= c && c <= '9') || c == '-';

        private void ThrowEndOfStreamException() => throw new EndOfStreamException();

        protected virtual void Dispose(bool disposing)
        {
            if (!_disposedValue)
            {
                if (disposing)
                {
                    _reader.Dispose();
                    _writer.Flush();
                    _writer.Dispose();
                }

                _disposedValue = true;
            }
        }

        public void Dispose()
        {
            Dispose(disposing: true);
            GC.SuppressFinalize(this);
        }
    }
    
}
