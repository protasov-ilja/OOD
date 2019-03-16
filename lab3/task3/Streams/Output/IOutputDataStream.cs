
using System;

namespace task3.Streams.Output
{
    interface IOutputDataStream
	{
		// Записывает в поток данных байт
		// Выбрасывает исключение std::ios_base::failure в случае ошибки
		void WriteByte(byte data);
		// Записывает в поток блок данных размером size байт, 
		// располагающийся по адресу srcData,
		// В случае ошибки выбрасывает исключение std::ios_base::failure
		void WriteBlock(Action srcData, uint size);
    }
}
