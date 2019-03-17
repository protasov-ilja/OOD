using System.IO;

namespace Task1.Painter
{
	public interface IDesigner
    {
		PictureDraft CreateDraft(TextReader strm);
    }
}
