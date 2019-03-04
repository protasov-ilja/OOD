
namespace task3.Streams.Output
{
    interface IOutputStream
    {
		void WriteByte(byte data);
		void WriteBlock(byte srcData, uint dataSize);
    }
}
