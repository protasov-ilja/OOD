

namespace task3.Streams.Input
{
    interface IInputStream
    {
		bool IsEOF();
		void ReadByte();
		void ReadBlock(byte dstData, uint dataSize);
    }
}
