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
    public class EquationHandlerTests
    {
        [TestMethod()]
        public void DestroyTest()
        {
            System.Windows.Controls.StackPanel panel = new System.Windows.Controls.StackPanel();
            panel.Children.Add(new System.Windows.UIElement());
            EquationHandler eq = new EquationHandler(new System.Windows.Controls.StackPanel());
            eq.Destroy();
            Assert.AreEqual(null, eq.Equations);
        }
    }
}