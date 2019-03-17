using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using Task1.Painter;

namespace Task1Tests.PictureDrafts
{
	[TestClass]
	public class PictureDraftTests
    {
		[TestMethod]
		public void CanCreatePictureDraftAndAddShapeInIt()
		{
			var draft = new PictureDraft();
			var testShape = new TestShape();
			Assert.AreEqual(draft.ShapeCount, 0);
			draft.AddShape(testShape);

			Assert.AreEqual(draft.ShapeCount, 1);
		}

		[TestMethod]
		public void CanGetShapeByIndex()
		{
			var draft = new PictureDraft();
			var testShape = new TestShape();
			Assert.AreEqual(draft.ShapeCount, 0);
			draft.AddShape(testShape);
			Assert.AreEqual(draft.ShapeCount, 1);
			Assert.AreEqual(draft.GetShapeByIndex(0), testShape);
		}

		[TestMethod]
		public void CantGetShapeIfIndexLessThanZero()
		{
			var draft = new PictureDraft();
			var testShape = new TestShape();
			Assert.AreEqual(draft.ShapeCount, 0);
			draft.AddShape(testShape);
			Assert.AreEqual(draft.ShapeCount, 1);
			Assert.ThrowsException<ArgumentOutOfRangeException>(() => draft.GetShapeByIndex(-1));
		}

		[TestMethod]
		public void CantGetShapeIfIndexMoreOrEqualThanShapesCount()
		{
			var draft = new PictureDraft();
			Assert.ThrowsException<ArgumentOutOfRangeException>(() => draft.GetShapeByIndex(0));
			var testShape = new TestShape();
			Assert.AreEqual(draft.ShapeCount, 0);
			draft.AddShape(testShape);
			Assert.AreEqual(draft.ShapeCount, 1);
			Assert.ThrowsException<ArgumentOutOfRangeException>(() => draft.GetShapeByIndex(1));
			Assert.ThrowsException<ArgumentOutOfRangeException>(() => draft.GetShapeByIndex(2));
		}
	}
}
