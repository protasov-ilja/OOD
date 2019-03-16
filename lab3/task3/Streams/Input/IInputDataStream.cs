

namespace task3.Streams.Input
{
    interface IInputDataStream
	{
		bool IsEOF();
		void ReadByte();
		void ReadBlock(byte dstData, uint dataSize);
    }
}
