using Microsoft.VisualStudio.TestTools.UnitTesting;
using P1;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace P1.Tests
{
    [TestClass()]
    public class AxisTests
    {
        [TestMethod()]
        public void DestroyTest()
        {
            System.Windows.Controls.Canvas parent = new System.Windows.Controls.Canvas();
            parent.Children.Add(new System.Windows.UIElement());
            X_Axis Axis = new X_Axis(parent, (0, 0), 10, 1);
            Axis.Destroy();
            Assert.IsTrue(Axis.IsDestroyed);
            Assert.AreEqual(0, parent.Children.Count);
        }
    }
}